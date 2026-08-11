using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Infrastructure.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERP.Infrastructure.Services
{
    public class SavingInvoiceLocal : BackgroundService, ISavingInvoiceQueue
    {
        private readonly ILogger<SavingInvoiceLocal> _Logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Channel<InvoiceTask> _Channel;
        public SavingInvoiceLocal(IServiceScopeFactory scopeFactory, ILogger<SavingInvoiceLocal> logger)
        {
            _scopeFactory = scopeFactory;
            _Logger = logger;

            var options = new BoundedChannelOptions(500)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = false,
                SingleReader = false
            };

            _Channel = Channel.CreateBounded<InvoiceTask>(options);
        }
        public async ValueTask QueueInvoiceAsync(InvoiceTask task, CancellationToken cancellationToken = default)

        {

            ArgumentNullException.ThrowIfNull(task);

            await _Channel.Writer.WriteAsync(task, cancellationToken);

            _Logger.LogInformation("Invoice queued for PDF building.");

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _Logger.LogInformation("Creating Invoice ...");
            int workerCount = 3;
            var workers = new Task[workerCount];

            for (int i = 0; i < workerCount; i++)
            {
                int workerId = i + 1;
                workers[i] = ProcessInvoicesAsync(workerId, stoppingToken);
            }

            await Task.WhenAll(workers);
        }
        private async Task ProcessInvoicesAsync(int workerId, CancellationToken stoppingToken)
        {
            await foreach (var invoice in _Channel.Reader.ReadAllAsync(stoppingToken))
            {
                if (invoice.invoice == null || invoice.items == null || invoice.items.Count < 0)
                {
                    _Logger.LogError("[Worker {WorkerId}] Invalid Data To Build Invoice Pdf. Skipping item.", workerId);
                    continue;
                }

                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var pdfBuilder = scope.ServiceProvider.GetRequiredService<IBuildPdf>();
                        var file = scope.ServiceProvider.GetRequiredService<IFileStorageService>();
                        var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

                        Stream result = pdfBuilder.BuildPdf(invoice.invoice, invoice.items);
                        await file.SaveFileAsync(result, $"INV-{invoice.invoice.Id}.pdf", "Invoices");
                        _Logger.LogInformation("[Worker {WorkerId}] PDF built successfully for Invoice.", workerId);

                        await hubContext.Clients.User(invoice.UserId).SendAsync("ReceiveInvoicePdf", new
                        {
                            InvoiceId = invoice.invoice.Id,
                            Status = "Completed",
                            Message = $"الفاتورة رقم #{invoice.invoice.Id} جاهزة للتحميل الآن."
                        }, cancellationToken: stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _Logger.LogError(ex, "[Worker {WorkerId}] Error processing invoice ",
                        workerId);
                }
            }
        }
    }
}
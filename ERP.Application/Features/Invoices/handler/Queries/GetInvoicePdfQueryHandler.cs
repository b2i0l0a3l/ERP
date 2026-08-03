using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;


namespace ERP.Application.Features.Invoices.Queries
{
    public class GetInvoicePdfQueryHandler : IRequestHandler<GetInvoicePdfQuery, Result<byte[]>>
    {

        private readonly IBuildPdf _Pdf;
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IInvoiceItemRepo _invoiceItemRepo;

        public GetInvoicePdfQueryHandler(IBuildPdf pdf,IInvoiceRepo invoiceRepo, IInvoiceItemRepo invoiceItemRepo)
        {
            _Pdf = pdf;
            _invoiceRepo = invoiceRepo;
            _invoiceItemRepo = invoiceItemRepo;
        }


        public async ValueTask<Result<byte[]>> Handle(GetInvoicePdfQuery request, CancellationToken cancellationToken)
        {
            Result<InvoiceDTO> invoiceResult = await _invoiceRepo.GetById(request.Id);
            if (!invoiceResult.IsSuccess)
                return invoiceResult.Error!;

            Result<List<InvoiceItemDTO>> itemsResult = await _invoiceItemRepo.GetByInvoiceId(request.Id);
            if (!itemsResult.IsSuccess)
                return itemsResult.Error!;

            InvoiceDTO invoice = invoiceResult.Value!;
            List<InvoiceItemDTO> items = itemsResult.Value!;

            try
            {
                byte[] pdfBytes = _Pdf.BuildPdf(invoice, items);
                return pdfBytes;
            }
            catch 
            {
                return new Error("ConverToPDFERRO", ErrorType.General, "An Error happend While Trying to create pdf");
            }
        }

    }
}

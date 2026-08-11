using ERP.Application.Features.Invoices.Requests.Queries;
using ERP.Core.Interfaces;
using ERP.Core.Models.InvoiceModels;
using ERP.Core.shared;
using Mediator;


namespace ERP.Application.Features.Invoices.Queries
{
    public class GetInvoicePdfQueryHandler : IRequestHandler<GetInvoicePdfQuery, Result<InvoicePdfResponseDto>>
    {

        private readonly IBuildPdf _Pdf;
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly ISavingInvoiceQueue _sinv;
        private readonly IInvoiceItemRepo _invoiceItemRepo;
        private readonly ICurrentUserService _CurrentUser;
        private readonly IGetFile _getFile;

        public GetInvoicePdfQueryHandler(IGetFile getFile,ISavingInvoiceQueue sinv,ICurrentUserService currentUser,IBuildPdf pdf,IInvoiceRepo invoiceRepo, IInvoiceItemRepo invoiceItemRepo)
        {
            _sinv = sinv;
            _CurrentUser = currentUser;
            _Pdf = pdf;
            _invoiceRepo = invoiceRepo;
            _invoiceItemRepo = invoiceItemRepo;
            _getFile = getFile;
        }


        public async ValueTask<Result<InvoicePdfResponseDto>> Handle(GetInvoicePdfQuery request, CancellationToken cancellationToken)
        {
            if (!_CurrentUser.IsAuthenticated && _CurrentUser.UserId == null)
                return Errors.UserNotAuthorized;


            var cachedFile = _getFile.GetFile($"INV-{request.Id}.pdf","Invoices");
            if(cachedFile != null)
            {
                return new InvoicePdfResponseDto
                {
                    IsReady = true,
                    PdfBytes =  cachedFile,
                    Message = "invoice Founded."
                };
            }

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
                await _sinv.QueueInvoiceAsync(new InvoiceTask() { invoice = invoice, items = items, UserId = _CurrentUser.UserId! });
                return new InvoicePdfResponseDto
                {
                    IsReady = false,
                    PdfBytes = null,
                    Message = "Creating invoice ..."
                };
            }
            catch
            {
                return new Error("ConverToPDFERRO", ErrorType.General, "An Error happend While Trying to create pdf");
            }
        }

    }
}

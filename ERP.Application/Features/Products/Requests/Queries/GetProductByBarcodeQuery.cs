using ERP.Core.Models.ProductModels;
using ERP.Core.shared;
using MediatR;

namespace ERP.Application.Features.Products.Requests.Queries
{
    public record GetProductByBarcodeQuery : IRequest<Result<ProductDTO>>
    {
        public string Barcode { get; set; } = string.Empty;
    }
}

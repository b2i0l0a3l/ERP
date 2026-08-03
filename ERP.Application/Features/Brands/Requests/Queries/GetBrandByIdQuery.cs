using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Models.BrandModels;
using ERP.Core.shared;
using Mediator;

namespace ERP.Application.Features.Brands.Requests.Queries
{
    public record GetBrandByIdQuery : IRequest<Result<BrandDTO>>
    {
        public int Id { get; set; } 
    }
}
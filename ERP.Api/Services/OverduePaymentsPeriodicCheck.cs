using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Application.Features.Notifications.Requests.Commands;
using ERP.Core.Interfaces;
using Mediator;


namespace ERP.Api.Services
{
    public class OverduePaymentsPeriodicCheck : IPeriodicCheck
{
    private readonly IMediator _mediator;
    
    public string Name => "Overdue Payments Check";

    public OverduePaymentsPeriodicCheck(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _mediator.Send(new CheckOverduePaymentsCommand(), cancellationToken);
    }
}
}
using cgds.Bank.Domain.Models;
using cgds.Bank.GrainInterfaces.Account;
using MediatR;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cgds.Bank.Application.Queries.Account
{
    public class GetHistoryQuery : IRequest<List<OperationHistoryEntry>>
    {
        public int AccountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, List<OperationHistoryEntry>>
    {

        private readonly IGrainFactory _grainFactory;

        public GetHistoryQueryHandler(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }

        public Task<List<OperationHistoryEntry>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            var accountGrain = _grainFactory.GetGrain<IAccountGrain>(request.AccountNumber);
            return accountGrain.GetHistory(request.StartDate, request.EndDate);
        }
    }
}

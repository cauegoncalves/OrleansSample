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
    public class GetBalanceQuery : IRequest<decimal>
    {
        public int AccountNumber { get; set; }
    }

    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, decimal>
    {

        private readonly IGrainFactory _grainFactory;

        public GetBalanceQueryHandler(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }

        public Task<decimal> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            var accountGrain = _grainFactory.GetGrain<IAccountGrain>(request.AccountNumber);
            return accountGrain.GetBalance();
        }
    }
}

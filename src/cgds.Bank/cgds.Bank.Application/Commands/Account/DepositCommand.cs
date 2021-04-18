using cgds.Bank.GrainInterfaces.Account;
using MediatR;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cgds.Bank.Application.Commands.Account
{
    public class DepositCommand : IRequest
    {
        public int AgencyNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }

    public class DepositCommandHandler : IRequestHandler<DepositCommand>
    {

        private readonly IGrainFactory _grainFactory;

        public DepositCommandHandler(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }
        
        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var accountGrain = _grainFactory.GetGrain<IAccountGrain>(request.AgencyNumber, request.AccountNumber);
            await accountGrain.Deposit(request.Amount);
            return Unit.Value;
        }
    }

}
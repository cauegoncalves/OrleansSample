using cgds.Bank.Application.Commands.Account;
using cgds.Bank.Application.Queries.Account;
using cgds.Bank.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cgds.Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("{accountNumber}/deposit")]
        public async Task<IActionResult> Deposit([FromRoute]int accountNumber, [FromBody]AccountOperationRequestDto request)
        {
            var depositCommand = new DepositCommand
            {
                AccountNumber = accountNumber,
                Amount = request.OperationAmount,
                Tags = request.Tags                
            };
            await _mediator.Send(depositCommand).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost("{accountNumber}/withdraw")]
        public async Task<IActionResult> Withdraw([FromRoute]int accountNumber, [FromBody]AccountOperationRequestDto request)
        {
            var withdrawCommand = new WithdrawCommand
            {
                AccountNumber = accountNumber,
                Amount = request.OperationAmount,
                Tags = request.Tags
            };
            await _mediator.Send(withdrawCommand).ConfigureAwait(false);
            return Ok();
        }

        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance([FromRoute]int accountNumber)
        {
            var getBalanceQuery = new GetBalanceQuery
            {
                AccountNumber = accountNumber
            };
            var balance = await _mediator.Send(getBalanceQuery).ConfigureAwait(false);
            return Ok(balance);
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetHistory([FromRoute]int accountNumber)
        {
            return Ok();
        }

    }
}

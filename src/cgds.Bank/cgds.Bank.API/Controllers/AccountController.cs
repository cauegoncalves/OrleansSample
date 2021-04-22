using cgds.Bank.API.Models;
using cgds.Bank.Application.Commands.Account;
using cgds.Bank.Application.Queries.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Deposit([FromRoute]int accountNumber, [FromBody]AccountOperationRequest request)
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
        public async Task<IActionResult> Withdraw([FromRoute]int accountNumber, [FromBody]AccountOperationRequest request)
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

        [HttpPost("{accountNumber}/history")]
        public async Task<IActionResult> GetHistory([FromRoute]int accountNumber, [FromBody]HistoryRequest request)
        {
            var getHistoryQuery = new GetHistoryQuery
            {
                AccountNumber = accountNumber,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            var history = await _mediator.Send(getHistoryQuery).ConfigureAwait(false);
            return Ok(history);
        }

    }
}

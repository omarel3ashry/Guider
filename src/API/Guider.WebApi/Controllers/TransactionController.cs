using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using Guider.Application.UseCases.Transactions.Query.GetTransactionQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PostTransaction(AddTransactionCommand AddTransactionCommand)
        {
            var transaction = await _mediator.Send(AddTransactionCommand);
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<ActionResult<TransactionReturnDto>> getTranscaction(int userId)
        {

            var query = new getTransactionByUserIdQuery() { UserId = userId };
            var response = await _mediator.Send(query);
            return Ok(response);

        }

    }
}

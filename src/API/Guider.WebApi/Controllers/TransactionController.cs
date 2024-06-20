using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


    }
}

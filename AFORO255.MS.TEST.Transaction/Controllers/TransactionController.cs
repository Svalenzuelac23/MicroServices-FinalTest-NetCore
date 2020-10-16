using AFORO255.MS.TEST.Transaction.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(
            ITransactionService service
            )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }               
    }

}
using AFORO255.MS.TEST.Invoices.Model;
using AFORO255.MS.TEST.Invoices.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(
            IInvoiceService service
            )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<IEnumerable<Invoice>>> Get([FromRoute] int invoiceId)
        {
            return Ok(await _service.Get(invoiceId));
        }       
        
    }
}
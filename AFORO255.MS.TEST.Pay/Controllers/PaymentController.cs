using AFORO255.MS.TEST.Pay.DTO;
using AFORO255.MS.TEST.Pay.RabbitMQ.Commands;
using AFORO255.MS.TEST.Pay.Service;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayService _service;
        private readonly IEventBus _bus;

        public PaymentController(
            IPayService service
            , IEventBus bus
            )
        {
            _service = service;
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PaymentRequest request)
        {
            Model.Pay pay = new Model.Pay()
            {
                Amount = request.Amount,
                InvoiceId = request.InvoiceId,
                Date = DateTime.Now
            };

            _service.AddPay(pay);


            //RABBITMQ

            var paymentCommand = new PaymentCreateCommand(
               transactionId: pay.TransactionId,
               invoiceId: pay.InvoiceId,
               amount: pay.Amount,
               date: pay.Date
                );

            _bus.SendCommand(paymentCommand);

            var transactionCommand = new TransactionCreateCommand(
               transactionId: pay.TransactionId,
               invoiceId: pay.InvoiceId,
               amount: pay.Amount,
               date: pay.Date
                );

            _bus.SendCommand(transactionCommand);


            return Ok();
        }
    }
}
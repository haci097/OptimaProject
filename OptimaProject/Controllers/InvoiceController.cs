using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimaProject.Entities.Concrete;
using OptimaProject.Repositories.Abstract;
using System.Collections.Generic;

namespace OptimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost("AddInvoice")]
        public IActionResult AddInvoice(Invoice invoice)
        {
            var result = _invoiceRepository.AddInvoice(invoice);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddInvoiceDetail")]
        public IActionResult AddInvoiceDetail(int invoiceId, List<Detail> details)
        {
            var result = _invoiceRepository.AddInvoiceDetails(invoiceId, details);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetInvoiceDetailList")]
        public IActionResult GetInvoiceDetailList()
        {
            var result = _invoiceRepository.GetInvoiceDetailList();

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetInvoiceList")]
        public IActionResult GetInvoiceList()
        {
            var result = _invoiceRepository.GetInvoiceList();

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}

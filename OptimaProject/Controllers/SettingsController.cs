using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptimaProject.Entities.Concrete;
using OptimaProject.Repositories.Abstract;

namespace OptimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IValidator<Customer> _validator;
        public SettingsController(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        [HttpPost("AddOperationClaim")]
        public IActionResult AddOperationClaim(OperationClaim operationClaim)
        {
            var result = _settingsRepository.AddOperationClaim(operationClaim);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddUserOperationClaim")]
        public IActionResult AddUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            var result = _settingsRepository.AddUserOperationClaim(userOperationClaim);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddDiscount")]
        public IActionResult AddDiscount(Discount discount)
        {
            var result = _settingsRepository.AddDiscount(discount);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UpdateDiscount")]
        public IActionResult UpdateDiscount(Discount discount)
        {
            var result = _settingsRepository.UpdateDiscount(discount);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("DeleteDiscount")]
        public IActionResult DeleteDiscount(Discount discount)
        {
            var result = _settingsRepository.DeleteDiscount(discount);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetDiscountList")]
        public IActionResult GetDiscountList()
        {
            var result = _settingsRepository.GetDiscountList();

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            var result = _settingsRepository.AddProduct(product);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _settingsRepository.UpdateProduct(product);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _settingsRepository.DeleteProduct(product);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList()
        {
            var result = _settingsRepository.GetProductList();

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _settingsRepository.AddCustomer(customer);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _settingsRepository.UpdateCustomer(customer);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("DeleteCustomer")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var result = _settingsRepository.DeleteCustomer(customer);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            var result = _settingsRepository.GetCustomerList();

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

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Securities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthorization]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        IOrderService _orderService;
        ILogger<CustomersController> _logger;

        public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger, IOrderService orderService)
        {
            _customerService = customerService;
            _logger = logger;
            _orderService=orderService;

    }
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                _logger.LogInformation("Yeni müşteri eklendi.");
                return Ok(result);

            }
            return BadRequest(result);
        }
        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);
            if (result.Success)
            {
                _logger.LogInformation("Müşteri silindi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                _logger.LogInformation("Müşteri kaydı güncellendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Get By Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            if (result.Success)
            {
                _logger.LogInformation(id + "ID'li müşteri sorgulandı");
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}/orders")]
        public IActionResult Orders(int id)
        {
            var result = _orderService.GetOrderDetails(id);
            if (result.Success)
            {
                _logger.LogInformation("Müşteri siparişleri listelendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("/orders/{id}")]
        public IActionResult GetByOrderId(int id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                _logger.LogInformation("Sipariş listelendi");
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

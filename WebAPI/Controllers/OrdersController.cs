using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                _logger.LogInformation("Yeni sipariş eklendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);
            if (result.Success)
            {
                _logger.LogInformation("Sipariş silindi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// update order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                _logger.LogInformation("Sipariş güncellendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Get by order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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

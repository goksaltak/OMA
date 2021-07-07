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
    public class OrderDetailsController : ControllerBase
    {
        IOrderDetailService _orderDetailService;
        ILogger<OrderDetailsController> _logger;
        public OrderDetailsController(IOrderDetailService orderDetailService, ILogger<OrderDetailsController> logger)
        {
            _orderDetailService = orderDetailService;
            _logger = logger;
        }
        /// <summary>
        /// Create orderdetail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Add(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Add(orderDetail);
            if (result.Success)
            {
                _logger.LogInformation("Yeni sipariş detayı eklendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Delete orderdetail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _orderDetailService.Delete(id);
            if (result.Success)
            {
                _logger.LogInformation("Sipariş detayı silindi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// update orderdetail
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Update(orderDetail);
            if (result.Success)
            {
                _logger.LogInformation("Sipariş detayı güncellendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
        /// <summary>
        /// Get By orderdetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetOrderDetails(int id)
        {
            var result = _orderDetailService.GetById(id);
            if (result.Success)
            {
                _logger.LogInformation(id+"ID numaralı sipariş detayı listelendi.");
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

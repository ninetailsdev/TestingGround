using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation("getting all from web api");
                return Ok(_repository.GetAllOrders());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogInformation("getting all from web api");
                var order = _repository.GetOrderById(id);

                if(order != null)
                {
                    return Ok(order);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return BadRequest();
            }
        }

    }
}

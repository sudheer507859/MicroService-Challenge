using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IBus bus;

        public OrdersController(IBus bus , IConfiguration configuration)
        {
            this.bus = bus;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            Uri uri = new Uri($"{this.configuration["RabbitMQSettings:BaseURL"]}/{this.configuration["RabbitMQSettings:QueueName"]}");
            var endPoint = await bus.GetSendEndpoint(uri);
            await endPoint.Send(new Order { Price = orderDto.Price, ProductName = orderDto.ProductName, Quantity = orderDto.Quantity });
            return Ok();
        }
    }
}

using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public OrderController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint=publishEndpoint;
        }

        [HttpPost]
        public async Task Index(Order order) 
        {
            await publishEndpoint.Publish(order);
        }
    }
}

using MassTransit;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer
{
    public class OrderConsumer : IConsumer<Order>
    {
        private readonly BaseContext baseContext;
        public OrderConsumer(BaseContext baseContext)
        {
            this.baseContext = baseContext;
        }

        public async Task Consume(ConsumeContext<Order> context)
        {
            this.baseContext.Order.Add(context.Message);
            await this.baseContext.SaveChangesAsync();
        }
    }
}

using MiniApi.Application;
using Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MiniApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly OrderQueries _orderQueries;

        public OrdersController(IMediator mediator, OrderQueries orderQueries)
        {
            _mediator = mediator;
            _orderQueries = orderQueries;
        }


        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="command">创建订单的命令</param>
        /// <returns>创建结果</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(CreateOrderResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(OrderDetailWithSpotResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetOrderDetails(int status)
        {
            var result = await _orderQueries.GetOrderDetailsByUserIdAsync(status);
            return Ok(result);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <returns></returns>
        [HttpPost("Cancel")]
        [Authorize]
        [ProducesResponseType(typeof(CanceleOrderResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CancelOrder(CancelOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoffeeShopApi.Models;

namespace CoffeeShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private static List<OrderModel> orders = new List<OrderModel>();

        // Добавление текущего заказа
        [HttpPost("add")]
        public IActionResult AddOrder([FromBody] OrderModel order)
        {
            // Логика добавления заказа в бд
            orders.Add(order);
            return Ok("Заказ успешно добавлен");
        }

        // Удаление заказа по ID
        [HttpDelete("remove/{orderId}")]
        public IActionResult RemoveOrder(int orderId)
        {
            // Логика удаления заказа по ID из бд
            var removedOrder = orders.RemoveAll(o => o.OrderId == orderId);
            if (removedOrder > 0)
                return Ok("Заказ успешно удален");
            else
                return NotFound("Заказ не найден");
        }

        // Вывод списка всех заказов
        [HttpGet("show")]
        public IActionResult GetAllOrders()
        {
            // Логика получения всех заказов из бд
            return Ok(orders);
        }
    }
}

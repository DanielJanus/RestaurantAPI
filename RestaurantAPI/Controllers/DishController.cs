using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public ActionResult<List<DishDto>> GetByRestaurantId([FromRoute] int restaurantId)
        {
            var result = _dishService.GetByRestaurantId(restaurantId);

            return Ok(result);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> GetByDishId([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            DishDto dish = _dishService.GetByDishId(restaurantId, dishId);

            return Ok(dish);
        }

        [HttpPost]
        public ActionResult Create([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int restaurantId)
        {
            _dishService.DeleteAll(restaurantId);

            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult Delete([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            _dishService.Delete(restaurantId, dishId);

            return NoContent();
        }

        [HttpPut("{dishId}")]
        public ActionResult Update([FromBody] UpdateDishDto dto, [FromRoute] int restaurantId, int dishId)
        {
            _dishService.Update(dto, restaurantId, dishId);

            return Ok();
        }
    }
}

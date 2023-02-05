using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery] RestaurantQuery restaurantQuery)
        {
            var restaurantsDtos = _restaurantService.GetAll(restaurantQuery);

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CreatedAtLeastTwoRestaurants")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult Create([FromBody] CreateRestaurantDto dto)
        {
            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        } 

        [HttpDelete("{id}")]
        [Authorize(Policy = "AtleastTwenty")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "HasNationality")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        {
             _restaurantService.Update(dto, id);

            return Ok();
        }
    }
}

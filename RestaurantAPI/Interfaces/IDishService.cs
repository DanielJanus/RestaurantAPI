using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Interfaces
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        List<DishDto> GetByRestaurantId(int restaurantId);

        DishDto GetByDishId(int restaurantId, int dishId);

        void DeleteAll(int restaurantId);
        void Delete(int restaurantId, int dishId);
        void Update(UpdateDishDto dto, int restaurantId, int dishId);

    }
}

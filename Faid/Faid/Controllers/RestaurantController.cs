using Faid.DTOs;
using Faid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly MyDbContext DbContext;
        private readonly ILogger<RestaurantController> _logger;


        public RestaurantController(MyDbContext context, ILogger<RestaurantController> logger)
        {
            DbContext = context;
            _logger = logger;

        }

        // GET: api/restaurants
        [HttpGet("getAllRestaurant")]
        public IActionResult getAllRestaurant()
        {
            var restaurants = DbContext.Restaurants.ToList();
            if (restaurants == null)
            {
                return NotFound("No orders found.");
            }

            return Ok(restaurants);
        }

        //GET: api/restaurants/{id}
    [HttpGet("{id}")]
    public ActionResult GetRestaurant(int id)
    {
        var restaurant = DbContext.Restaurants.Find(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

        [HttpPut("{restaurantId}")]
        public IActionResult UpdateRestaurant(int restaurantId, [FromBody] Restaurant updatedRestaurant)
        {
            var restaurant = DbContext.Restaurants.Find(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.Name = updatedRestaurant.Name;
            restaurant.OwnerName = updatedRestaurant.OwnerName;
            restaurant.Email = updatedRestaurant.Email;
            restaurant.PhoneNo = updatedRestaurant.PhoneNo;
            restaurant.Address = updatedRestaurant.Address;
            restaurant.FoodType = updatedRestaurant.FoodType;

            DbContext.SaveChanges();

            return Ok();
        }


        //menu

        //===================================
        [HttpGet("{restaurantId}/menu")]
        public IActionResult GetMenu(int restaurantId)
        {
            var menuItems = DbContext.FoodAvailables.Where(m => m.RestaurantId == restaurantId).ToList();
            return Ok(menuItems);
        }

        [HttpPost("{restaurantId}/menu")]
        public IActionResult AddMenuItem(int restaurantId, [FromBody] FoodAvailable newItem)
        {
            newItem.RestaurantId = restaurantId;
            DbContext.FoodAvailables.Add(newItem);
            DbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{restaurantId}/menu/{menuId}")]
        public IActionResult DeleteMenuItem(int restaurantId, int menuId)
        {
            var menuItem = DbContext.FoodAvailables.FirstOrDefault(m => m.RestaurantId == restaurantId && m.FoodId == menuId);
            if (menuItem == null)
            {
                return NotFound();
            }
            DbContext.FoodAvailables.Remove(menuItem);
            DbContext.SaveChanges();
            return Ok();
        }


    }
}


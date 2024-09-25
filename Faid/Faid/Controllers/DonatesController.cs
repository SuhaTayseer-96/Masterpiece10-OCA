using Faid.DTOs;
using Faid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Faid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatesController : ControllerBase
    {
        private readonly MyDbContext DbContext;
        private readonly ILogger<DonatesController> _logger;


        public DonatesController(MyDbContext context, ILogger<DonatesController> logger)
        {
            DbContext = context;
            _logger = logger;

        }

        [HttpPost("FoodDonation")]
        public IActionResult FoodDonation([FromForm] FoodDon request)

        {
            var food = DbContext.FoodDonations.FirstOrDefault();
            if (food == null)
            {
                return NotFound(food);

            }
            var data = new FoodDonation
            {
                FoodType =request.FoodType,
                PickupArrangements = request.PickupArrangements,
                ContactInfo = request.ContactInfo,

            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }



        //Money Donation
        [HttpPost("api/MoneyDonation")]
        public IActionResult MoneyDonation([FromForm] MoneyDon request)

        {
            var money = DbContext.MoneyDonations.FirstOrDefault();
            if (money == null)
            {
                return NotFound(money);

            }
            var data = new MoneyDonation
            {
                DonationAmount = request.DonationAmount,
                DonationFrequency = request.DonationFrequency,  
                FundUsage = request.FundUsage,

            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }


        //Restaurant Donation
        [HttpPost("api/RestDonation")]
        public IActionResult RestaurantDonation([FromForm] RestDon request)

        {
            var rest = DbContext.RestaurantDonations.FirstOrDefault();
            if (rest == null)
            {
                return NotFound(rest);

            }
            var data = new RestaurantDonation
            {
                RestaurantName = request.RestaurantName,
                FoodDonated = request.FoodDonated,
                PickupDetails = request.PickupDetails,
                ContactDetails = request.ContactDetails,    
            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }
    }
}

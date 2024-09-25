using Azure.Core;
using Faid.DTOs;
using Faid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesRequestsForms : ControllerBase
    {
        private readonly MyDbContext DbContext;
        private readonly ILogger<RestaurantController> _logger;


        public ServicesRequestsForms(MyDbContext context, ILogger<RestaurantController> logger)
        {
            DbContext = context;
            _logger = logger;

        }


        [HttpGet("GetAllPartReq")]
        public IActionResult PartnershipRequest()
        {
            var data = DbContext.PartnershipRequests.ToList();
            return Ok(data);
        }
        
        ///Partner form
        [HttpPost("PostPartnership")]
        public IActionResult PartnershipRequest([FromForm] PartnershipReq request)

        {
            var partner = DbContext.PartnershipRequests.FirstOrDefault();
            if (partner == null) {
                return NotFound(partner);

            }
            var data = new PartnershipRequest
            {
                OrganizationType = request.OrganizationType,
                ContactPerson = request.ContactPerson,
                Email = request.Email,
                ContactPhoneNumber = request.ContactPhoneNumber,
                PartnershipGoals = request.PartnershipGoals,

            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }


        [HttpGet("GetAllCollection")]
        public IActionResult FoodCollectionRequest()
        {
            var collection = DbContext.FoodCollectionRequests.ToList();
            return Ok(collection);
        }

        //Food collextion form 
        [HttpPost("api/PostFoodCol")]
        public IActionResult FoodCollectionRequest([FromForm] FoodCollReq request)

        {
            var collection = DbContext.FoodCollectionRequests.FirstOrDefault();
            if (collection == null)
            {
                return NotFound(collection);

            }
            var data = new FoodCollectionRequest
            {
                Name = request.Name,
                Email = request.Email,
                Phone= request.Phone,
                PickupAddress = request.PickupAddress,
                FoodType= request.FoodType,
                PreferredPickupDate = request.PreferredPickupDate.Value,
                PreferredPickupTime = request.PreferredPickupTime.Value,

            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }




        [HttpGet("GetAllDistReq")]
        public IActionResult FoodDistributionRequest()
        {
            var data = DbContext.FoodDistributionRequests.ToList();
            return Ok(data);
        }

        //Food distribution form 
        [HttpPost("api/PostFoodDist")]
        public IActionResult FoodDistributionRequest([FromForm] FoodDistReq request)

        {
            var dist = DbContext.PartnershipRequests.FirstOrDefault();
            if (dist == null)
            {
                return NotFound(dist);

            }
            var data = new FoodDistributionRequest
            {
               CharityName = request.CharityName,
               ContactPerson= request.ContactPerson,
               Email= request.Email,
               Phone = request.Phone,
               PickupAddress= request.PickupAddress,
               FoodTypeNeeded = request.FoodTypeNeeded,
                QuantityNeeded = request.QuantityNeeded,
                PreferredDeliveryDate = request.PreferredDeliveryDate,  
            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }














        //[HttpPost("SetOrderByUserID")]
        //public IActionResult SetOrder(int id, [FromForm] OrderDTO order)
        //{
        //    var user = _db.Users.FirstOrDefault(x => x.UserId == id);
        //    if (user == null)
        //    {
        //        return NotFound(user);
        //    }

        //    var data = new Order
        //    {
        //        UserId = order.UserId,
        //        TotalAmount = order.TotalAmount,
        //        PaymentMethod = order.PaymentMethod,
        //        Status = order.Status,
        //        ShippingAddress = order.ShippingAddress,
        //    };

        //    _db.Orders.Add(data);
        //    _db.SaveChanges();
        //    return Ok(data);
    }
        //// GET: api/PartnershipRequests/5
        //[HttpGet("{id}")]
        //public ActionResult<PartnershipRequest> GetPartnershipRequest(int id)
        //{
        //    var request = DbContext.PartnershipRequests.Find(id);
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }
        //    return request;
        //}

        //// POST: api/PartnershipRequests
        //[HttpPost]
        //public ActionResult<PartnershipRequest> PostPartnershipRequest(PartnershipRequest request)
        //{
        //    DbContext.PartnershipRequests.Add(request);
        //    DbContext.SaveChanges();
        //    return CreatedAtAction(nameof(GetPartnershipRequest), new { id = request.RequestId }, request);
        //}

        //// PUT: api/PartnershipRequests/5
        //[HttpPut("{id}")]
        //public IActionResult PutPartnershipRequest(int id, PartnershipRequest request)
        //{
        //    if (id != request.RequestId)
        //    {
        //        return BadRequest();
        //    }

        //    DbContext.Entry(request).State = EntityState.Modified;
        //    DbContext.SaveChanges();

        //    return NoContent();
        //}
    }


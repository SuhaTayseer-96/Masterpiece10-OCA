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


        public class RegisterController : ControllerBase
        {
            private readonly MyDbContext DbContext;
            private readonly ILogger<RestaurantController> _logger;


            public RegisterController(MyDbContext context, ILogger<RestaurantController> logger)
            {
                DbContext = context;
                _logger = logger;

            }


            //All Log
            [HttpGet("GetAllUser")]
            public IActionResult User()
            {
                var data = DbContext.Users.ToList();
                return Ok(data);
            }

            //ByID
            [HttpGet("api/GetAllUserByID{id}")]
            public IActionResult UserByID(int id)
            {
                var data = DbContext.Users.FirstOrDefault(u => u.UserId == id);
                return Ok(data);
            }


        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User updatedUser)
        {
            var user = DbContext.Users.Find(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;
            user.Address = updatedUser.Address;

            DbContext.SaveChanges();

            return Ok();
        }



        ///log form
        [HttpPost("LogForm")]
        public IActionResult User([FromForm] UserDTO request)

        {
            var email = DbContext.Users.FirstOrDefault(a => a.Email == request.Email);
            if (email == null)
            {
                return NotFound("Please put valid email");

            }
            var data = new UserDTO
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,

            };
            DbContext.Add(data);
            DbContext.SaveChanges();
            return Ok(data);
        }





        //All Rest
        [HttpGet("api/GetAllRests")]
            public IActionResult Restaurant()
            {
                var data = DbContext.Restaurants.ToList();
                return Ok(data);
            }

            //ByID
            [HttpGet("api/GetAllRestByID{id}")]
            public IActionResult RestByID(int id)
            {
                var data = DbContext.Restaurants.FirstOrDefault(u => u.RestaurantId == id);
                return Ok(data);
            }

            ///Rest form
            [HttpPost("api/LogForm")]
            public IActionResult Restaurant([FromForm] RestRegDTO request)

            {
                var rests = DbContext.Restaurants.FirstOrDefault(r => r.Email == request.Email);
                if (rests == null)
                {
                    return NotFound("Please put valid email");

                }
                var data = new RestRegDTO
                {
                    Name = rests.Name,
                    Email = rests.Email,
                    Password = rests.Password,
                    OwnerName = request.OwnerName,
                    PhoneNo = request.PhoneNo,
                    Address = request.Address,

                };
                DbContext.Add(data);
                DbContext.SaveChanges();
                return Ok(data);
            }



            /// passwords
            private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }

            }

        //[HttpPut("{userId}/changePassword")]
        //public IActionResult ChangePassword(int userId, [FromBody] ChangePasswordModel model)
        //{
        //    var user = DbContext.Users.Find(userId);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Validate current password (you should hash and compare with stored hash)
        //    if (!VerifyPassword(model.CurrentPassword, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return BadRequest("Current password is incorrect.");
        //    }

        //    // Hash the new password and save it
        //    var newHashedPassword = HashPassword(model.NewPassword, out var newSalt);
        //    user.PasswordHash = newHashedPassword;
        //    user.PasswordSalt = newSalt;

        //    DbContext.SaveChanges();

        //    return Ok();
        //}


        //=============================================================
        /// register
        [HttpPost("api/register")]
        public IActionResult register([FromForm] UserDTO request)
        {
            // Hash and Salt password before saving
            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt
            };


            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult UserLog([FromForm] UserDTO request)
        {
            var data = DbContext.Users.FirstOrDefault(u => u.Email == request.Email);
            if (data == null)
            {
                return BadRequest("Please Enter the email");
            }
            return Ok();
        }

    }
    }

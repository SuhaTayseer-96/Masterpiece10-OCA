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
    public class HomeController : ControllerBase
    {
        private readonly MyDbContext db;
        private readonly ILogger<HomeController> _logger;


        public HomeController(MyDbContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;

        }

        //foodtime


        //contactus



        //Latest News
        [HttpGet("GetAllNews")]
        public IActionResult GetNewsPosts()
        {
            var newsPosts = db.NewsPosts.ToList();
            return Ok(newsPosts);
        }

    }
}

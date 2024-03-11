using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;

namespace WebsiteForNbaFans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITeamOperation operation;

        public HomeController(ITeamOperation operation)
        {
            this.operation = operation; 
        }

        [HttpGet(nameof(Test))]
        public async Task<IActionResult> Test()
        {
            var result = await this.operation.GetAll();
            return Ok(result);
        }
    }
}

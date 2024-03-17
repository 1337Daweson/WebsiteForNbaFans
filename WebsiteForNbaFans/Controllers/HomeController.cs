using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;
using WebsiteForNbaFans.Helpers.Configuration;
using Microsoft.Extensions.Options;

namespace WebsiteForNbaFans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITeamOperation operation;
        private readonly Api appSettings;

        public HomeController(ITeamOperation operation, IOptions<Api> appSettings)
        {
            this.operation = operation;
            this.appSettings = appSettings.Value;
        }

        [HttpGet(nameof(Test))]
        public async Task<IActionResult> Test()
        {
            var result = await this.operation.GetAll();
            return Ok(result);
        }

        [HttpGet(nameof(Teams))]
        public async Task<IActionResult> Teams(int page, int pageSize)
        {
            var response = await Helpers.ApiHelper.GetResponse(page, pageSize, appSettings.ApiKey, appSettings.ApiUrl, "teams");
            return Ok(response);
        }

        [HttpGet(nameof(TeamById))]
        public async Task<IActionResult> TeamById(int id, int page, int pageSize)
        {
            var response = await Helpers.ApiHelper.GetResponse(page, pageSize, appSettings.ApiKey, appSettings.ApiUrl, "teams",id);
            return Ok(response);
        }
    }
}

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
    public class NbaController : ControllerBase
    {
        private readonly Api appSettings;
        private readonly IHttpClientFactory clientFactory; 

        public NbaController(IOptions<Api> appSettings, IHttpClientFactory clientFactory)
        {
            this.appSettings = appSettings.Value;
            this.clientFactory = clientFactory;
        }

        [HttpGet(nameof(Teams))]
        public async Task<IActionResult> Teams()
        {
            var response = await Helpers.ApiHelper.GetResponse(clientFactory, appSettings.ApiKey, appSettings.ApiUrl, "teams");
            return Ok(response);
        }

        [HttpGet(nameof(TeamById))]
        public async Task<IActionResult> TeamById(int id)
        {
            var response = await Helpers.ApiHelper.GetResponse(clientFactory, appSettings.ApiKey, appSettings.ApiUrl, "teams", id);
            return Ok(response);
        }

        [HttpGet(nameof(PlayersByTeamId))]
        public async Task<IActionResult> PlayersByTeamId(int teamId)
        {
            var response = await Helpers.ApiHelper.GetPlayersByTeam(clientFactory, teamId, appSettings.ApiKey, appSettings.ApiUrl, "players");
            return Ok(response);
        }
    }
}

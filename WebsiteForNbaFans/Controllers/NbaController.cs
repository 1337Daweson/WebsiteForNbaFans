using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;
using WebsiteForNbaFans.Helpers.Configuration;
using Microsoft.Extensions.Options;
using WebsiteForNbaFans.Operations.RapidAPI;

namespace WebsiteForNbaFans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NbaController : ControllerBase
    {
        private readonly Api appSettings;
        private readonly IHttpClientFactory clientFactory;
        private readonly IRapidApiOperation apiOperation;

        public NbaController(IOptions<Api> appSettings,
            IHttpClientFactory clientFactory,
            IRapidApiOperation apiOperation)
        {
            this.appSettings = appSettings.Value;
            this.clientFactory = clientFactory;
            this.apiOperation = apiOperation;

        }

        [HttpGet(nameof(Team))]
        public async Task<IActionResult> Team(int teamId)
        {
            var response = await this.apiOperation.GetTeam(teamId);
            return Ok(response);
        }

        [HttpGet(nameof(Teams))]
        public async Task<IActionResult> Teams()
        {
            var response = await this.apiOperation.GetTeams();
            return Ok(response);
        }

        [HttpGet(nameof(Roster))]
        public async Task<IActionResult> Roster(int teamId)
        {
            var response = await this.apiOperation.GetCurrentRoster(teamId);
            return Ok(response);
        }

        [HttpGet(nameof(GamesByDate))]
        public async Task<IActionResult> GamesByDate(DateTime date)
        {
            var response = await this.apiOperation.GetGamesByDate(date);
            return Ok(response);    
        }

        [HttpGet(nameof(GamesByTeamId))]
        public async Task<IActionResult> GamesByTeamId(int teamId)
        {
            var response = await this.apiOperation.GetGamesByTeamId(teamId);
            return Ok(response);
        }

        [HttpGet(nameof(Player))]
        public async Task<IActionResult> Player(int playerId)
        {
            var response = await this.apiOperation.GetPlayerById(playerId);
            return Ok(response);
        }

        [HttpGet(nameof(PlayerStatistics))]
        public async Task<IActionResult> PlayerStatistics(int playerId)
        {
            var response = await this.apiOperation.GetPlayerStatistics(playerId);
            return Ok(response);
        }

        [HttpGet(nameof(Standings))]
        public async Task<IActionResult> Standings()
        {
            var response = await this.apiOperation.GetStandings();
            return Ok(response);
        }

    }
}

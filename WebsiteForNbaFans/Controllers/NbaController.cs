using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;
using WebsiteForNbaFans.Helpers.Configuration;
using Microsoft.Extensions.Options;
using WebsiteForNbaFans.Operations.RapidAPI;
using WebsiteForNbaFans.Operations.Caching;
using WebsiteForNbaFans.DTO;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebsiteForNbaFans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NbaController : ControllerBase
    {
        private readonly Api appSettings;
        private readonly IHttpClientFactory clientFactory;
        private readonly IRapidApiOperation apiOperation;
        private readonly ICacher cacher;

        public NbaController(IOptions<Api> appSettings,
            IHttpClientFactory clientFactory,
            IRapidApiOperation apiOperation,
            ICacher chacher)
        {
            this.appSettings = appSettings.Value;
            this.clientFactory = clientFactory;
            this.apiOperation = apiOperation;
            this.cacher = chacher;

        }

        [HttpGet(nameof(Team))]
        public async Task<IActionResult> Team(int teamId)
        {
            if (cacher.TryGetValue("team" + teamId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetTeam(teamId);
            this.cacher.Set("teams", response);
            return Ok(response);
        }

        [HttpGet(nameof(Teams))]
        public async Task<IActionResult> Teams()
        {
            if (cacher.TryGetValue("teams", out string data))
            {
                    return Ok(data);
            }

            var response = await this.apiOperation.GetTeams();
            this.cacher.Set("teams", response);

            return Ok(response);
        }

        [HttpGet(nameof(Roster))]
        public async Task<IActionResult> Roster(int teamId)
        {
            if (cacher.TryGetValue("roster" + teamId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetCurrentRoster(teamId);
            this.cacher.Set("roster" + teamId, response);

            return Ok(response);
        }

        [HttpGet(nameof(GamesByDate))]
        public async Task<IActionResult> GamesByDate(DateTime date)
        {
            if (cacher.TryGetValue("gameByDate" + date.ToString(), out string data))
            {
                return Ok(data);
            }
            var response = await this.apiOperation.GetGamesByDate(date);
            this.cacher.Set("gameByDate" + date.ToString(), response);

            return Ok(response);    
        }

        [HttpGet(nameof(GamesByTeamId))]
        public async Task<IActionResult> GamesByTeamId(int teamId)
        {
            if (cacher.TryGetValue("gameByTeam" + teamId, out string data))
            {
                return Ok(data);
            }
            var response = await this.apiOperation.GetGamesByTeamId(teamId);
            this.cacher.Set("gameByTeam" + teamId, response);

            return Ok(response);
        }

        [HttpGet(nameof(Player))]
        public async Task<IActionResult> Player(int playerId)
        {
            if (cacher.TryGetValue("player" + playerId, out string data))
            {
                return Ok(data);
            }
            var response = await this.apiOperation.GetPlayerById(playerId);
            this.cacher.Set("player" + playerId, response);
            return Ok(response);
        }

        [HttpGet(nameof(PlayersStatsByTeam))]
        public async Task<IActionResult> PlayersStatsByTeam(int teamId)
        {
            if (cacher.TryGetValue("stats" + teamId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetPlayersStats(teamId);
            cacher.Set("stats" + teamId, response);

            return Ok(response);
        }

        [HttpGet(nameof(Standings))]
        public async Task<IActionResult> Standings()
        {
            if (cacher.TryGetValue("standings", out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetStandings();
            cacher.Set("standings", response);

            return Ok(response);
        }



    }
}

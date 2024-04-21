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
        private readonly IArticleOperation articleOperation;

        public NbaController(IOptions<Api> appSettings,
            IHttpClientFactory clientFactory,
            IRapidApiOperation apiOperation,
            IArticleOperation articleOperation,
            ICacher chacher)
        {
            this.appSettings = appSettings.Value;
            this.clientFactory = clientFactory;
            this.apiOperation = apiOperation;
            this.cacher = chacher;
            this.articleOperation = articleOperation;

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

        [HttpGet(nameof(PlayersStatsByTeam))]
        public async Task<IActionResult> PlayersStatsByTeam(int teamId)
        {
            if (cacher.TryGetValue("stats" + teamId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetPlayersStatsByTeam(teamId);
            cacher.Set("stats" + teamId, response);

            return Ok(response);
        }

        [HttpGet(nameof(TeamsStats))]
        public async Task<IActionResult> TeamsStats(int teamId)
        {
            if (cacher.TryGetValue("teamStats" + teamId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetTeamsStats(teamId);
            cacher.Set("teamStats" + teamId, response);

            return Ok(response);
        }

        [HttpGet(nameof(GamesPerSeason))]
        public async Task<IActionResult> GamesPerSeason()
        {
            if (cacher.TryGetValue("gamesPerSeason", out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetGamesPerSeason();
            cacher.Set("gamesPerSeason", response);

            return Ok(response);
        }

        [HttpGet(nameof(PlayerStats))]
        public async Task<IActionResult> PlayerStats(int playerId, int season)
        {
            if (cacher.TryGetValue("playerStats" + playerId + season, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetPlayerStats(playerId, season);
            cacher.Set("playerStats" + playerId + season, response);

            return Ok(response);
        }

        [HttpGet(nameof(Articles))]
        public async Task<IActionResult> Articles()
        {
            return Ok(await this.articleOperation.GetArticlesAsync());
        }

        [HttpGet(nameof(Article))]
        public async Task<IActionResult> Article(int id)
        {
            return Ok(await this.articleOperation.GetArticleByIdAsync(id));
        }

        [HttpGet(nameof(PlayerStatsPerGame))]
        public async Task<IActionResult> PlayerStatsPerGame(int gameId)
        {
            if (cacher.TryGetValue("playerStatsPerGame" + gameId, out string data))
            {
                return Ok(data);
            }

            var response = await this.apiOperation.GetPlayerStatsByGame(gameId);
            cacher.Set("playerStatsPerGame" + gameId, response);

            return Ok(response);
        }


    }
}

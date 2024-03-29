using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebsiteForNbaFans.Helpers.Configuration;
using WebsiteForNbaFans.Operations.RapidAPI;

namespace WebsiteForNbaFans.Operations.RapidAPI
{
    public interface IRapidApiOperation
    {
        Task<string> GetTeam(int teamId);
        Task<string> GetTeams();
        Task<string> GetCurrentRoster(int teamId, int season = 2023);
        Task<string> GetGamesByDate(DateTime date);
        Task<string> GetGamesByTeamId(int teamId, int season = 2023);
        Task<string> GetPlayerById(int playerId);
        Task<string> GetPlayerStatistics(int playerId, int season = 2023);
        Task<string> GetStandings(int season = 2023);
        Task<string> GetPlayersStats(int teamId, int season = 2023);
    };

    public class RapidApiOperation : IRapidApiOperation
    {
        private readonly HttpClient _client;
        private readonly Api appSettings;

        public RapidApiOperation(IHttpClientFactory httpClientFactory, IOptions<Api> appSettings)
        {
            _client = httpClientFactory.CreateClient("RapidApiOperation");
            this.appSettings = appSettings.Value;
        }

        public async Task<string> GetCurrentRoster(int teamId, int season = 2023)
        {
            string url = $"/players?team={teamId}&season={season}"; 
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTeam(int teamId)
        {
            string url = $"/teams?id={teamId}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTeams()
        {
            string url = $"/teams?league=standard";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // games per date for calendar
        public async Task<string> GetGamesByDate(DateTime date)
        {
            // 2022-02-12
            string url = $"/games?date={date}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetGamesByTeamId(int teamId, int season = 2023)
        {
            string url = $"/games?team={teamId}&season={season}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlayerById(int playerId)
        {
            string url = $"/players?id={playerId}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlayerStatistics(int playerId, int season = 2023)
        {
            string url = $"/players/statistics?id={playerId}&season={season}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetStandings(int season = 2023)
        {
            string url = $"/standings?league=standard&season={season}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlayersStats(int teamId, int season = 2023)
        {
            // players/statistics?team=1&season=2020
            string url = $"/players/statistics?team={teamId}&season={season}";
            var response = await this._client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}


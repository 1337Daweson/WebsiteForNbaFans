using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace WebsiteForNbaFans.Helpers
{
    public static class ApiHelper
    {
        public async static Task<string> GetResponse(IHttpClientFactory clientFactory, string? apiKey, string? apiUrl, string? endpoint, int? id = null)
        {
            var client = clientFactory.CreateClient();  
            client.DefaultRequestHeaders.Add("Authorization", apiKey);
            if (!id.HasValue)
            {
                string url = $"{apiUrl}{endpoint}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                string url = $"{apiUrl}{endpoint}/{id}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async static Task<string> GetPlayersByTeam(IHttpClientFactory clientFactory, int teamId, string? apiKey, string? apiUrl, string? endpoint)
        {
            var client = clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", apiKey);
            string url = $"{apiUrl}{endpoint}?team_ids[]={teamId}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace WebsiteForNbaFans.Helpers
{
    public static class ApiHelper
    {
        public async static Task<string> GetResponse(int page, int pageSize, string? apiKey, string? apiUrl, string? endpoint, int? id = null)
        {
            HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", apiKey);
            if (!id.HasValue)
            {
                string url = $"{apiUrl}{endpoint}?page={page}&per_page={pageSize}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                string url = $"{apiUrl}{endpoint}/{id}?page={page}&per_page={pageSize}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}

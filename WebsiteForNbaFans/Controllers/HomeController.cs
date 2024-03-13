using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;

namespace WebsiteForNbaFans.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly string URL = "https://api.balldontlie.io/v1/teams";
        private readonly string KEY = "6bcf5679-4a0d-4832-9a2b-974a22fb1478";
        private readonly int PAGE = 1;
        private readonly int PAGE_SIZE = 10;
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

        [HttpGet(nameof(Teams))]
        public async Task<IActionResult> Teams(int page, int pageSize)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", KEY);
            string url = $"{URL}?page={page}&per_page={pageSize}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            client.Dispose();
            return Ok(responseBody);
        }
    }
}

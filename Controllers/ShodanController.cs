using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test_Pwn_Pach.Models;

[Route("api/[controller]")]
[ApiController]
public class ShodanController : ControllerBase
{
    private static readonly HttpClient httpClient = new HttpClient();

    [HttpGet("{ip}")]
    public async Task<IActionResult> GetIpDetails(string ip)
    {
        var response = await httpClient.GetAsync($"https://api.shodan.io/shodan/host/{ip}?key=8L3LM3YSd1bxWOFkcWLecsIby9exatDk");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ShodanResponseModel>(content);
            return Ok(data);
        }

        return BadRequest("Error retrieving information from Shodan API");
    }

}

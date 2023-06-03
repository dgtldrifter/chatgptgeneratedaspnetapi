using Microsoft.AspNetCore.Mvc;

namespace ChatGPTGeneratedSimpleWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomTextController : ControllerBase
{
    private static readonly List<string> StringHistory = new List<string>();
    private static readonly Random Random = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // POST: /RandomText/GetRandomText
    [HttpPost("GetRandomText")]
    public ActionResult<string> GetRandomText()
    {
        var randomText = new string(Enumerable.Repeat(Chars, 10)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
        StringHistory.Add(randomText);
        return randomText;
    }

    // GET: /RandomText/GetStringHistory/{int}
    [HttpGet("GetStringHistory/{count}")]
    public ActionResult<IEnumerable<string>> GetStringHistory(int count)
    {
        if (count <= 0)
        {
            return BadRequest("Count must be greater than 0");
        }

        return StringHistory.TakeLast(Math.Min(count, StringHistory.Count)).ToList();
    }

}
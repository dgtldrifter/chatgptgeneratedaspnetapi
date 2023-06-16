using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTGeneratedSimpleWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomTextController : ControllerBase
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private static readonly BlockingCollection<string> StringHistory = new(new ConcurrentQueue<string>());

    [HttpPost("GetRandomText")]
    public ActionResult<string> GetRandomText()
    {
        var randomText = new string(Enumerable.Repeat(Chars, 10)
            .Select(s => s[RandomNumberGenerator.GetInt32(s.Length)]).ToArray());

        StringHistory.Add(randomText);

        return randomText;
    }

    [HttpGet("GetStringHistory/{count}")]
    public ActionResult<IEnumerable<string>> GetStringHistory(int count)
    {
        if (count <= 0)
        {
            return BadRequest("Count must be greater than 0");
        }

        return StringHistory.Take(Math.Min(count, StringHistory.Count)).ToList();
    }


}
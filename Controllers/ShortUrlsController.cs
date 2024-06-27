using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace urlShortner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortUrlsController : ControllerBase
    {
        private readonly Dictionary<string, string> _urlMappings;
        private readonly Dictionary<string, int> _urlHits;

        public ShortUrlsController()
        {
            _urlMappings = new Dictionary<string, string>();
            _urlHits = new Dictionary<string, int>();
        }

        [HttpPost]
        public IActionResult CreateShortUrl([FromBody] string longUrl)
        {
            string shortUrl = GenerateShortUrl();
            _urlMappings[shortUrl] = longUrl;
            return Ok(shortUrl);
        }

        [HttpDelete("{shortUrl}")]
        public IActionResult DeleteShortUrl(string shortUrl)
        {
            if (_urlMappings.ContainsKey(shortUrl))
            {
                _urlMappings.Remove(shortUrl);
                _urlHits.Remove(shortUrl);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{shortUrl}")]
        public IActionResult GetLongUrl(string shortUrl)
        {
            if (_urlMappings.ContainsKey(shortUrl))
            {
                string longUrl = _urlMappings[shortUrl];
                return Ok(longUrl);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{shortUrl}/hits")]
        public IActionResult GetNumberOfHits(string shortUrl)
        {
            if (_urlHits.ContainsKey(shortUrl))
            {
                int hits = _urlHits[shortUrl];
                return Ok(hits);
            }
            else
            {
                return NotFound();
            }
        }

        private string GenerateShortUrl()
        {
            // TODO: Implement logic to generate a unique short URL
            // You can use a library or algorithm to generate a short URL
            // For simplicity, let's assume we are returning a random string for now
            return "abc123";
        }
    }
}
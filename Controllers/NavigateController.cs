using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace urlShortner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NavigateController : ControllerBase
    {
        private Dictionary<string, string> urlMappings; // Dictionary to store shortUrl-originalUrl mappings

        public NavigateController()
        {
            urlMappings = new Dictionary<string, string>();
        }

        [HttpGet("{shortUrl}")]
        public IActionResult NavigateToShortUrl(string shortUrl)
        {
            if (urlMappings.ContainsKey(shortUrl))
            {
                string originalUrl = urlMappings[shortUrl];
                return Redirect(originalUrl); // Redirect the user to the original URL
            }

            return NotFound(); // Return a 404 Not Found if the shortUrl is not found.
        }
    }
}
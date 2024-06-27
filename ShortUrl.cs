using System.Collections.Generic;

namespace urlShortner
{
    public class ShortUrl
    {
        // Properties
        public string Id { get; set; }
        public string LongUrl { get; set; }
        public int Hits { get; set; }
        public List<string> HitDates { get; set; }

        // Constructor
        public ShortUrl(string id, string longUrl)
        {
            Id = id;
            LongUrl = longUrl;
            Hits = 0;
            HitDates = new List<string>();
        }
    }
}

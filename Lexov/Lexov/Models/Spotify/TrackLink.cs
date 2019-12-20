using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Spotify
{
    public class TrackLink
    {
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
}

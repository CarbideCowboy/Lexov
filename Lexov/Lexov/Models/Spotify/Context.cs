using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Spotify
{
    public class Context
    {
        public string uri { get; set; }
        public string href { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string type { get; set; } 
    }
}

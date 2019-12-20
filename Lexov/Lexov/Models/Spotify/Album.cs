using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Spotify
{
    public class Album
    {
        public string album_group { get; set; }
        public string album_type { get; set; }
        public Artist artists { get; set; }
        public String[] available_markets { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public Image[] images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
}

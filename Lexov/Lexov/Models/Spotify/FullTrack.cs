using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Spotify
{
    public class FullTrack
    {
        public Album album { get; set; }
        public Artist[] artists { get; set; }
        public string[] available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        [JsonProperty("explicit")]
        public bool Explicit { get; set; } 
        public ExternalID external_ids { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_playable { get; set; }
        public TrackLink linked_from { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public bool is_local { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Spotify
{
    public class CurrentlyPlaying : BaseResponse
    {
        public Context context { get; set; }
        public int timestamp { get; set; }
        public int progress_ms { get; set; }
        public bool is_playing { get; set; }
        public FullTrack item { get; set; }
        public string currently_playing_type { get; set; }
    }
}

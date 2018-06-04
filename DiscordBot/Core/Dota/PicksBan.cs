using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class PicksBan
    {
        public bool is_pick { get; set; }
        public int hero_id { get; set; }
        public int team { get; set; }
        public int order { get; set; }
    }
}

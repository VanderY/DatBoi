using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class Match
    {
        public object match_id { get; set; }
        public object match_seq_num { get; set; }
        public int start_time { get; set; }
        public int lobby_type { get; set; }
        public int radiant_team_id { get; set; }
        public int dire_team_id { get; set; }
        public Player[] players { get; set; }
        //public List<Player> players { get; set; }
    }
}

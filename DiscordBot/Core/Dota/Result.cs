using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class Result
    {
        public int status { get; set; }
        public int num_results { get; set; }
        public int total_results { get; set; }
        public int results_remaining { get; set; }
        public Match[] matches { get; set; }
        public Player[] players { get; set; }
        public bool radiant_win { get; set; }
        public int duration { get; set; }
        public int pre_game_duration { get; set; }
        public int start_time { get; set; }
        public long match_id { get; set; }
        public long match_seq_num { get; set; }
        public int tower_status_radiant { get; set; }
        public int tower_status_dire { get; set; }
        public int barracks_status_radiant { get; set; }
        public int barracks_status_dire { get; set; }
        public int cluster { get; set; }
        public int first_blood_time { get; set; }
        public int lobby_type { get; set; }
        public int human_players { get; set; }
        public int leagueid { get; set; }
        public int positive_votes { get; set; }
        public int negative_votes { get; set; }
        public int game_mode { get; set; }
        public int flags { get; set; }
        public int engine { get; set; }
        public int radiant_score { get; set; }
        public int dire_score { get; set; }
        public PicksBan[] picks_bans { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class Commands
    {
        public static double Winrate(string id, int count)
        {
            string api = "E26ECE5ABC97A7AD4B9458909AFE700B";
            string url = $"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?matches_requested=" + count + "&key=" + api + "&account_id=" + id;

            GameDota game = JsonConvert.DeserializeObject<GameDota>(Data.GetData(url));
            int win = 0;
            int lose = 0;
            for (int i = 0; i < game.result.matches.Length; i++)
            {
                string matchURL = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id=" + game.result.matches[i].match_id + "&key=" + api;
                GameDota Match = JsonConvert.DeserializeObject<GameDota>(Data.GetData(matchURL));
                for (int k = 0; k < Match.result.players.Length / 2; k++)
                {
                    if (Match.result.players[k].account_id.ToString() == id)
                    {
                        if (Match.result.radiant_win)
                        {
                            win++;
                            Console.WriteLine($"1. {win}");
                            break;
                        }
                        else
                        {
                            lose++;
                            Console.WriteLine($"4. {lose}");
                            break;
                        }
                    }
                    else if (k == (Match.result.players.Length / 2) - 1)
                    {
                        if (Match.result.radiant_win)
                        {
                            lose++;
                            Console.WriteLine($"2. {lose}");
                            break;
                        }
                        else
                        {
                            win++;
                            Console.WriteLine($"3. {win}");
                            break;
                        }
                    }
                }
                //int k = 0;
                //while (true)
                //{
                //    if (Match.result.players[k].account_id.ToString() == id)
                //    {
                //        if (Match.result.radiant_win)
                //        {
                //            win++;
                //            Console.WriteLine($"1. {win}");
                //            break;
                //        }
                //        else
                //        {
                //            lose++;
                //            Console.WriteLine($"4. {lose}");
                //            break;
                //        }
                //    }
                //    else if (k == (Match.result.players.Length / 2) - 1)
                //    {
                //        if (Match.result.radiant_win)
                //        {
                //            lose++;
                //            Console.WriteLine($"2. {lose}");
                //            break;
                //        }
                //        else
                //        {
                //            win++;
                //            Console.WriteLine($"3. {win}");
                //            break;
                //        }
                //    }
                //    k++;
                //}
            }

            double winrate = Math.Round((double)win / (win + lose) * 100, 4);
            return winrate;
        }
    }
}

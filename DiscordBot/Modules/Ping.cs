using Discord;
using Discord.Commands;
using DiscordBot.Core.Dota;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("agressive")]
        public async Task PingAsync()
        {
            //EmbedBuilder builder = new EmbedBuilder();

            //builder.WithTitle("Attention!")
            //    .WithDescription("Lexa!")
            //    .WithColor(Color.Red);
            //await ReplyAsync("", false, builder.Build());


            //Context.User;
            //Context.Client;


            //await ReplyAsync($"{Context.User.Mention} ");
            await ReplyAsync($"{Context.User.Mention} go out!!");
        }

        [Command("fas")]
        public async Task FasCommand(string name)
        {
            await ReplyAsync($"{name} is bastard");
        }

        [Command("last")]
        public async Task DotaCommand(string id)
        {
            string api = "E26ECE5ABC97A7AD4B9458909AFE700B";
            string url = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?matches_requested=1&key=" + api + "&account_id=" + id;


            GameDota game = JsonConvert.DeserializeObject<GameDota>(Data.GetData(url));
            string hero = "";
            for (int k = 0; game.result.matches[0].players.Length < 11; k++)
            {
                if (game.result.matches[0].players[k].account_id.ToString() == id)
                {
                    hero = Parser.Parse(game.result.matches[0].players[k].hero_id);
                    break;
                }
            }
            //while(true)
            //{
            //    int k = 0;
            //    if (game.result.matches[0].players[k].account_id.ToString() == id)
            //    {
            //        hero = Parser.Parse(game.result.matches[0].players[k].hero_id);
            //        break;
            //    }
            //    k++;
            //}

            url = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id=" + game.result.matches[0].match_id + "&key=" + api;
            GameDota Game = JsonConvert.DeserializeObject<GameDota>(Data.GetData(url));
            double kda = 0.0;
            int i;
            for (i = 0; Game.result.players.Length < 11; i++)
            {
                if (Game.result.players[i].account_id.ToString() == id)
                {
                    if (Game.result.players[i].deaths != 0)
                    {
                        kda = Math.Round((double)(Game.result.players[i].kills + Game.result.players[i].assists) / Game.result.players[i].deaths, 2);
                        break;
                    }
                    else
                    {
                        kda = Game.result.players[i].kills + Game.result.players[i].assists;
                        break;
                    }
                }
            }
            if (Game.result.radiant_win && Game.result.players[i].player_slot < 5)
            {
                await ReplyAsync($"Последний матч {id} сыграл на {hero} c {kda} КДА и выиграл");
            }
            else if (!Game.result.radiant_win && Game.result.players[i].player_slot < 5)
            {
                await ReplyAsync($"Последний матч {id} сыграл на {hero} c {kda} КДА и проиграл");
            }
            else if (Game.result.radiant_win && Game.result.players[i].player_slot > 5)
            {
                await ReplyAsync($"Последний матч {id} сыграл на {hero} c {kda} КДА и проиграл");
            }
            else if (!Game.result.radiant_win && Game.result.players[i].player_slot > 5)
            {
                await ReplyAsync($"Последний матч {id} сыграл на {hero} c {kda} КДА и выиграл");
            }
        }

        [Command("winrate")]
        public async Task WinrateCommand(string id)
        {
            string count = "100";
            string api = "E26ECE5ABC97A7AD4B9458909AFE700B";
            string url = $"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?matches_requested=" + count + "&key=" + api + "&account_id=" + id;

            GameDota game = JsonConvert.DeserializeObject<GameDota>(Data.GetData(url));
            int win = 0;
            int lose = 0;
            for(int i = 0; i <= game.result.matches.Length - 1; i++)
            {
                string matchURL = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id=" + game.result.matches[i].match_id + "&key=" + api;
                GameDota Match = JsonConvert.DeserializeObject<GameDota>(Data.GetData(matchURL));
                for (int k = 0; k <= Match.result.players.Length; k++)
                {
                    if(Match.result.players[k].account_id.ToString() == id)
                    {
                        if (Match.result.radiant_win && Match.result.players[k].player_slot < 5)
                        {
                            win++;
                            Console.WriteLine($"1. {win}");
                            break;
                        }
                        else if (Match.result.radiant_win && Match.result.players[k].player_slot > 5)
                        {
                            lose++;
                            Console.WriteLine($"2. {lose}");
                            break;
                        }
                        else if (!Match.result.radiant_win && Match.result.players[k].player_slot > 5)
                        {
                            win++;
                            Console.WriteLine($"3. {win}");
                            break;
                        }
                        else if (!Match.result.radiant_win && Match.result.players[k].player_slot < 5)
                        {
                            lose++;
                            Console.WriteLine($"4. {lose}");
                            break;
                        }
                    }
                }
            }
            double winrate = Math.Round((double) win / (win + lose) * 100, 4);
            await ReplyAsync($"Winrate = {winrate}%;\nFrom {win + lose} games;");
        }

        [Command("join")]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            // Get the audio channel
            channel = channel ?? (Context.User as IGuildUser)?.VoiceChannel;
            if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

            // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
            var audioClient = await channel.ConnectAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class Parser
    {
        public static string Parse(int id)
        {
            string path = @"D:\Projects\DiscordBot\DiscordBot\Core\Dota\npc_heroes.txt";
            string hero = "";

            using (StreamReader fs = new StreamReader(path))
            {
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();
                    string temporary = "";

                    if (temp == $"		\"HeroID\"		\"{id}\"")
                    {
                        //return temp;
                        while (true)
                        {
                            temporary = fs.ReadLine();

                            if (temporary.Contains("\"workshop_guide_name\""))
                            {
                                hero = temporary.Remove(0,26);
                                hero = hero.Remove(hero.Length - 1, 1);
                                return hero;
                            }
                            else if (temp == null)
                            {
                                break;
                            }
                        }
                    }
                    // Если достигнут конец файла, прерываем считывание.
                    else if (temp == null)
                    {
                        break;
                    }
                } 
            }
            return hero;
        }
    }
}

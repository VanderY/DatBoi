using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DiscordBot.Core.Dota
{
    public class Data
    {
        public static string GetData(string url)
        {
            try
            {
                string result = "";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Proxy = null;
                httpWebRequest.AllowAutoRedirect = false;//Запрещаем автоматический реддирект 
                httpWebRequest.Method = "GET"; //Можно не указывать, по умолчанию используется GET. 
                httpWebRequest.Referer = "http://google.com"; // Реферер. Тут можно указать любой URL
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            result = reader.ReadToEnd();
                            return result;
                        }
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Bt4.App_Start
{
    public static class Bot
    {
        private static ITelegramBotClient Client;
        static IWebProxy wpp;
        static List<IWebProxy> proxLs;
        static Random rd = new Random();
        static int current = 0;
        public static void Main()
        {

            Client = new TelegramBotClient("954641214:AAFzynqxLMp3EjXzaKKgCch1foVu8x6ksjY") { Timeout = TimeSpan.FromSeconds(5) };
            var test = Client.GetMeAsync().Result;
            Client.OnMessage += Messengs;
            Client.StartReceiving();
        }
        public async static void Messengs(object sender, MessageEventArgs e)
        {

            var text = e?.Message?.Text;
            if (text == "/cat")
            {
                try
                {
                    current = rd.Next(1, 4999);
                    SendPhoto(sender, e);

                }
                catch
                {


                }

                Console.WriteLine($"Mess '{text}' in chat '{e.Message.Chat.Id}'cat № '{current}'");
            }
        }

        public async static void SendPhoto(object sender, MessageEventArgs e)
            {
                try
                {
                    var url = await Client.SendPhotoAsync(e.Message.Chat.Id, "https://d2ph5fj80uercy.cloudfront.net/04/cat" + Convert.ToString(current) + ".jpg");
                    return;
                }
                catch
                {
                    Messengs(sender, e);
                }
            }
        }
    }

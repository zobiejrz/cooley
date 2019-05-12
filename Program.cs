using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dnd_character_storage
{
    class Cooley
    {
        static void Main(string[] args) => new Program().Start();
        public Discord.DiscordSocketClient _client;
        public void Start()
        {
            _client = new DiscordSocketClient(x =>
            {
                x.AppName = " Cooley Bot ";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            //set bot prefix
            // _client.UsingCommands(x => {
            //     x.PrefixChar = '~'; //find how to set 2 character as prefix ";/"
            //     x.AllowMentionPrefix = true;
            //     x.HelpMode = HelpMode.Public;
            // });

            var token = "-x-x-x";
            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(token, TokenType.Bot);
            });
        }

        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] - [{e.Source}] {e.Message}");
        }
    }
}
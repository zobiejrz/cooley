using Discord;
using Discord.Analyzers;
using Discord.Commands;
using Discord.API;
using Discord.Audio;
using Discord.Rest;
using Discord.Rpc;
using Discord.Webhook;
using Discord.WebSocket;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dnd_character_storage
{
    class Cooley
    {
        static void Main(string[] args) => new Cooley().Start().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        public async Task Start()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig { 
                WebSocketProvider = Discord.Net.Providers.WS4Net.WS4NetProvider.Instance
            });

            //set bot prefix
            // _client.UsingCommands(x => {
            //     x.PrefixChar = '~'; //find how to set 2 character as prefix ";/"
            //     x.AllowMentionPrefix = true;
            //     x.HelpMode = HelpMode.Public;
            // });

            var token = "-x-x-x";
            await _client.LoginAsync(TokenType.Bot, token, true);
            await _client.StartAsync();
            await Task.Delay(-1);

        }
        public void Log(object sender, LogMessage e)
        {
            Console.WriteLine($"[{e.Severity}] - [{e.Source}] {e.Message}");
        }
    }
}
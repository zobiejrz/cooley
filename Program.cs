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
            /* Begin Commands */

            _client.Connected += async () => {
                Console.WriteLine("SYS - Connected to Discord Gateway as " + _client.CurrentUser);
                await Task.Delay(-1);
            };

            _client.Disconnected += async (e) => {
                Console.WriteLine("ERR - " + e);
                Console.WriteLine("ERR - Attempting to rejoin");
                await Task.Delay(-1);
            };

            _client.JoinedGuild += async (g) => {
                Console.WriteLine("SYS - Joined " + g.Name);
                await g.DefaultChannel.SendMessageAsync("Hello everyone! Type '-help' to see a list of commands!");
                await Task.Delay(-1);
            };

            _client.GuildAvailable += async (g) => {
                Console.WriteLine("SYS - Connected to " + g.Name);
                await Task.Delay(-1);
            };

            _client.LeftGuild += async (g) => {
                Console.WriteLine("SYS - Left " + g.Name);
                await Task.Delay(-1);
            };

            /* End Commands */
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
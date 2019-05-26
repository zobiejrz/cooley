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
using System.Reflection;

namespace dnd_character_storage
{
    class Cooley
    {
        static void Main(string[] args) => new Cooley().Start().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        private CommandService _commands;
        public async Task Start()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig { 
                WebSocketProvider = Discord.Net.Providers.WS4Net.WS4NetProvider.Instance
            });

            _commands = new CommandService(new CommandServiceConfig{
                CaseSensitiveCommands = true,
                
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            _client.Connected += async () => {
                Console.WriteLine("SYS - Connected to Discord Gateway as " + _client.CurrentUser);
                await Task.Delay(-1);
            };

            _client.Disconnected += async (e) => {
                Console.WriteLine("ERR - Disconnected from Discord Gateway: " + e.Message);
                await Task.Delay(-1);
            };

            _client.MessageReceived += async (SocketMessage a) => {
                var Message = a as SocketUserMessage;
                var Context = new SocketCommandContext(_client, Message);

                if (Message.Content == null || Message.Content == "") return;
                if (Message.Author.IsBot) return;

                int argPos = 0;

                if (!(Message.HasStringPrefix("-", ref argPos) || Message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;

                var Result = await _commands.ExecuteAsync(Context, argPos, null, MultiMatchHandling.Best);

                if (!Result.IsSuccess) {
                    Console.WriteLine("ERR - Command `" + Context.Message + "` could not be completed: " + Result.ErrorReason);
                }
            };


            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            var token = "-x-x-x";

            try
            {
                await _client.LoginAsync(TokenType.Bot, token, true);
                await _client.StartAsync();
                await Task.Delay(-1);
            } catch (Exception e) {
                Console.WriteLine("ERR - Couldn't log in: " + e.Message );
            }
            
        }
        public void Log(object sender, LogMessage e)
        {
            Console.WriteLine($"[{e.Severity}] - [{e.Source}] {e.Message}");
        }
    }
}
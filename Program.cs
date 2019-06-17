using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using dnd_character_storage.Resources.Datatypes;


namespace dnd_character_storage
{
    class Cooley
    {

        static void Main(string[] args) => new Cooley().Start().GetAwaiter().GetResult();
        private DiscordSocketClient client;
        private CommandService commands;
        public static Dictionary<String, Character> selectedCharacters;
        public async Task Start()
        {
            selectedCharacters = new Dictionary<String, Character>();
            this.client = new DiscordSocketClient(new DiscordSocketConfig
            { 
                WebSocketProvider = Discord.Net.Providers.WS4Net.WS4NetProvider.Instance
            });

            this.commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            this.client.Connected += async () =>
            {
                Console.WriteLine( $"SYS - Connected to Discord Gateway as {this.client.CurrentUser}" );
                await Task.Delay(-1);
            };

            this.client.Disconnected += async (e) =>
            {

                Console.WriteLine("ERR - Disconnected from Discord Gateway: " + e.Message);
                await Task.Delay(-1);
            };

            this.client.MessageReceived += async (SocketMessage a) => 
            {
                var Message = a as SocketUserMessage;
                var Context = new SocketCommandContext(this.client, Message);

                if (Message.Content == null || Message.Content == "") return;
                if (Message.Author.IsBot) return;

                int argPos = 0;

                if (!(Message.HasStringPrefix("-", ref argPos) || Message.HasMentionPrefix(this.client.CurrentUser, ref argPos))) return;

                var Result = await this.commands.ExecuteAsync(Context, argPos, null, MultiMatchHandling.Best);

                if (!Result.IsSuccess)
                {
                    Console.WriteLine("ERR - Command `" + Context.Message + "` could not be completed:\n\t" + Result.ErrorReason);
                }
            };

            // Adds the commands to the Command Service
            await this.commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            var token = "NTc2MjYzODE4ODA0NTkyNjYy.XQaI5g.zStslDbHXJXmZyvzkrXpt-rsTF0";
            
            // Continually tries logging in until successful every 2 seconds
            try
            {
                await this.client.LoginAsync(TokenType.Bot, token, true);
                await this.client.StartAsync();
                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERR - Log in failed: " + e.Message );
                Console.WriteLine("ERR - Trying to log in again...");
                System.Threading.Thread.Sleep(2000);
                await Start();
            }
            
        }
    }
}
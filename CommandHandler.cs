// using Discord;
// using Discord.Analyzers;
// using Discord.Commands;
// using Discord.API;
// using Discord.Audio;
// using Discord.Rest;
// using Discord.Rpc;
// using Discord.Webhook;
// using Discord.WebSocket;

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// public class CommandHandler
// {
//     private readonly DiscordSocketClient _client;
//     private readonly CommandService _commands;

//     public CommandHandler(DiscordSocketClient client, CommandService commands)
//     {
//         _commands = commands;
//         _client = client;
//     }
    
//     public async Task InstallCommandsAsync()
//     {
//         _client.MessageReceived += HandleCommandAsync;

//         await _commands.AddModulesAsync(assembly: G, 
//                                         services: null);
//     }

//     private async Task HandleCommandAsync(SocketMessage messageParam)
//     {
//         var message = messageParam as SocketUserMessage;
//         if (message == null) return;

//         int argPos = 0;

//         if (!(message.HasCharPrefix('-', ref argPos) || 
//             message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
//             message.Author.IsBot)
//             return;

//         var context = new SocketCommandContext(_client, message);

//         var result = await _commands.ExecuteAsync(
//             context: context, 
//             argPos: argPos,
//             services: null);


//         if (!result.IsSuccess)
//         await context.Channel.SendMessageAsync(result.ErrorReason);
//     }
// }
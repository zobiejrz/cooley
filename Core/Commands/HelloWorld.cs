using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

namespace dnd_character_storage.Core.Commands {
    
    public class HelloWorld : ModuleBase<SocketCommandContext> {
        [Command("hello"), Summary("HelloWorld")]
        public async Task say() => await ReplyAsync("Hello World!");
    }

}
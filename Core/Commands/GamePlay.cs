using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

namespace dnd_character_storage.Core.Command
{

    [Group("roll"), Alias("rl")]
    public class Roll : ModuleBase<SocketCommandContext>
    {
        [Command("4"), Alias("five")]
        public async Task RollD4()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D4 and got a {this.RandomNumber(4)}");
        }

        [Command("6"), Alias("six")]
        public async Task RollD6()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D6 and got a {this.RandomNumber(6)}");
        }
        [Command("8"), Alias("eight")]
        public async Task RollD8()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D8 and got a {this.RandomNumber(8)}");
        }
        [Command("10"), Alias("ten")]
        public async Task RollD10()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D10 and got a {this.RandomNumber(10)}");
        }
        [Command("12"), Alias("twelve")]
        public async Task RollD20()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D12 and got a {this.RandomNumber(12)}");
        }
        [Command("20"), Alias("twenty")]
        public async Task makeChannel()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync($"{Context.User.Mention} rolled a D20 and got a {this.RandomNumber(20)}");
        }

        private int RandomNumber(int max)  
        {  
            Random random = new Random();  
            return random.Next(1, max);  
        }  
    }

}
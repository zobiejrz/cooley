using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

namespace dnd_character_storage.Core.Commands
{
    
    public class HelloWorld : ModuleBase<SocketCommandContext>
    {
        //
        // This class is for basic, non D&D related commands
        //

        [Command("say")]
        public async Task hello([Remainder] string text)
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync (text);
        }
        [Command("ask")]
        public async Task ask([Remainder] string text)
        {
            if (text.ToLower() == "what is the primary goal") await ReplyAsync ( $"{Context.User.Mention} to win the game." );
        }

    }

    public class Dice : ModuleBase<SocketCommandContext>
    {
        //
        // Stand alone dice roller for D&D dice rolling
        //

        [Command("roll"), Alias("rl")]
        public async Task RollWithParam([Remainder] string text)
        {
            switch (text)
            {
                case "4":
                    await Context.Message.DeleteAsync();
                    await ReplyAsync($"{Context.User.Mention} rolled a D4 and got a {this.RandomNumber(4)}");
                break;
                case "6":
                    await ReplyAsync($"{Context.User.Mention} rolled a D6 and got a {this.RandomNumber(6)}");
                break;
                case "8":
                    await ReplyAsync($"{Context.User.Mention} rolled a D8 and got a {this.RandomNumber(8)}");
                break;
                case "10":
                    await ReplyAsync($"{Context.User.Mention} rolled a D10 and got a {this.RandomNumber(10)}");
                break;
                case "12":
                    await ReplyAsync($"{Context.User.Mention} rolled a D12 and got a {this.RandomNumber(12)}");
                break;
                case "20":
                    await ReplyAsync($"{Context.User.Mention} rolled a D20 and got a {this.RandomNumber(20)}");
                break;
                default:
                    await ReplyAsync($"{Context.User.Mention} you used -roll incorrectly! Try typing '-roll [ 4 | 6 | 8 | 10 | 12 | 20 ]'");
                break;
            }
            
        }
        [Command("roll"), Alias("rl")]
        public async Task RollWithNoParam()
        {
            await ReplyAsync($"{Context.User.Mention} you used -roll incorrectly! Try typing '-roll [ 4 | 6 | 8 | 10 | 12 | 20 ]'");
        }
        private int RandomNumber(int max)  
        {  
            Random random = new Random();  
            return random.Next(1, max);  
        }
    }
}
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

using Discord;
using Discord.Analyzers;
using Discord.Commands;
using Discord.API;
using Discord.Audio;
using Discord.Rest;
using Discord.Rpc;
using Discord.Webhook;
using Discord.WebSocket;

namespace dnd_character_storage.Core.Command
{
    [Group("player")]
    public class IO : ModuleBase<SocketCommandContext>
    {
        [Command("new")]
        public async Task New([Remainder] string name)
        {
            checkIfNewUser(Context.User);
            if (isNewCharacter(Context.User, name))
            {
                File.WriteAllText($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User}/{name}.csv","A character file written to store D&D e5 character sheets");
                await ReplyAsync( Context.User.Mention + ", I finished your new character, " + name + ". Use the -player select <name> command to select the character." );
            }
            else
            {
                await ReplyAsync( Context.User.Mention + " you've already made a character with that name, maybe try -player select " + name + " or use a new name." );
            }
        }
        [Command("new")]
        public async Task NewWithoutParam()
        {
            checkIfNewUser(Context.User);
            await ReplyAsync( $"{Context.User.Mention} what am I supposed to name your character? Try again by typing -player new <name>" );
        }
        [Command("select")]
        public async Task Select([Remainder] string character)
        {
            checkIfNewUser(Context.User);
            if (isNewCharacter(Context.User, character))
            {
                await ReplyAsync( Context.User.Mention + " that character doesn't exist or doesn't belong to you. Try selecting a different character, or '-player new <name>'. Use '-player list' to see all your characters." );
            }
            else
            {
                Cooley.selectedCharacters.Add( Context.User, character );
                await ReplyAsync ( Context.User.Mention + " has selected " + character + " to be their character." );
            }
        }
        [Command("select")]
        public async Task SelectWithoutParam()
        {
            checkIfNewUser(Context.User);
            if (Cooley.selectedCharacters[Context.User] != null)
            {
                await ReplyAsync( $"{Context.User.Mention} you have currently selected {Cooley.selectedCharacters[Context.User]} as your character." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you don't have a character selected! Try -player select <name> or -player new <name> to get started" );
            }  
        }
        [Command("delete")]
        public async Task delete([Remainder] string name)
        {
            checkIfNewUser(Context.User);
            if ( isNewCharacter(Context.User, name) )
            {
                await ReplyAsync ( $"{Context.User.Mention} that character doesn't exist, so I can't delete it. Maybe try something else?" );
            }
            else
            {
                File.Delete ( $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}/{name}.csv" );
                await ReplyAsync ( $"{Context.User.Mention} I've snapped {name} out of existance! No stones to bring them back this time." );
                if ( Cooley.selectedCharacters[Context.User] == name )
                {
                    Cooley.selectedCharacters.Remove(Context.User);
                }
            }
            
        }
        [Command("delete")]
        public async Task DeleteWithoutParam()
        {
            await ReplyAsync  ( $"{Context.User.Mention} I'm sorry, but you didn't type in a name to delete! Try typing -player delete <name> or -player list to find the one you hate most" );
        }
        [Command("list")]
        public async Task List()
        {
            string[] filePaths = Directory.GetFileSystemEntries($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}", "*.csv" );
            var list = "";
            foreach ( string filepath in filePaths )
            {
                var currentFile = filepath.Substring(74 + Context.User.ToString().Length);
                list += currentFile.Split(".csv")[0];
                list += "\n";
            }

            if ( list != "")
            {
                await ReplyAsync ( $"{Context.User.Mention} here are your characters:\n{list}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you don't have any characters to list! Use -player new <name> to make your first one!" );
            }
            
            
        }

        public static Boolean isNewCharacter(SocketUser user, String name)
        {
            string dir = @"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/" + user.ToString() + "/" + name + ".csv";
            if (File.Exists(dir)) return false;
            return true;
        }

        public static void checkIfNewUser(SocketUser user)
        {
            string dir = @"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/";
            string folder = user.ToString();
            // If directory does not exist, create it. 
            if (!Directory.Exists(dir + folder))
            {
                Directory.CreateDirectory( dir + folder);
            }
        }
    }

    public class Dice : ModuleBase<SocketCommandContext>
    {

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

    // [Group("character"), Alias("ch")]
    // public class character : ModuleBase<SocketCommandContext>
    // {
        // [Command("new"), Alias("n")]
        // public async Task new()
        // {
            
        // }

        // [Command("list"), Alias("l")]
        // public async Task list()
        // {
            
        // }

        // [Command("add"), Alias("a")]
        // public async Task add()
        // {

        // }

        // [Command("delete"), Alias(this)]
        // public async Task delete()this
        // {

        // }

        // [Command("select"), Alias("s")]
        // public async Task select()
        // {

        // }


        // private static void testIfNewUser(SocketUser user)
        // {

        // }

    // }
}
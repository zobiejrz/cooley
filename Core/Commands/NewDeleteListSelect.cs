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

namespace dnd_character_storage.Core.Commands
{
    [Group("player")]
    public class NewDeleteListSelect : ModuleBase<SocketCommandContext>
    {
        //
        // This Group is only to add/delete/list/select character files
        //
        // ~~~~~BUGS~~~~~
        // 1. -player new ../player/name will make a new file called name.csv in a player directory in CharacterData
        // 

        [Command("new"), Alias("n")]
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
        [Command("new"), Alias("n")]
        public async Task NewWithoutParam()
        {
            checkIfNewUser(Context.User);
            await ReplyAsync( $"{Context.User.Mention} what am I supposed to name your character? Try again by typing -player new <name>" );
        }
        [Command("select"), Alias("s")]
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
        [Command("select"), Alias("s")]
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
        [Command("delete"), Alias("d")]
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
        [Command("delete"), Alias("d")]
        public async Task DeleteWithoutParam()
        {
            await ReplyAsync  ( $"{Context.User.Mention} I'm sorry, but you didn't type in a name to delete! Try typing -player delete <name> or -player list to find the one you hate most" );
        }
        [Command("list"), Alias("l")]
        public async Task List()
        {
            string[] filePaths = Directory.GetFileSystemEntries($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}", "*.csv" );
            var list = "";
            foreach ( string filepath in filePaths )
            {
                // THIS IS WHERE BUGS WILL COME FROM WHEN THE COMPUTERS CHANGE
                //                         |
                //                        \|/
                //                         v
                list += filepath.Substring(74 + Context.User.ToString().Length).Split(".csv")[0];
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

}
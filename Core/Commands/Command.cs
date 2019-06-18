using System;
using System.Text;
using System.IO;
using Discord.WebSocket;
using Discord.Commands;
using Newtonsoft.Json;
using System.Security.Cryptography;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    public class Command : ModuleBase<SocketCommandContext>
    {
        protected virtual Boolean isNewCharacter(SocketUser user, String name)
        {
            // string dir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{user.ToString()}/{getSerialByName(name)}.json";
            string tempDir = $"Resources/CharacterData/{user.ToString()}/{getSerialByName(name)}.json";
            var dir = System.IO.Path.GetFullPath(tempDir);

            if (File.Exists(dir)) return false;
            return true;
        }
        protected virtual void checkIfNewUser(SocketUser user)
        {
            // string dir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{user.ToString()}";
            string tempDir = $"Resources/CharacterData/{user.ToString()}";
            var dir = System.IO.Path.GetFullPath(tempDir);

            // If directory does not exist, create it. 
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory( dir );
            }
        }
        protected virtual void serialize(Character character)
        {
            string tempDir = $"Resources/CharacterData/{character.Owner.ToString()}/{character.Serial}.json";
            var dir = System.IO.Path.GetFullPath(tempDir);
            File.WriteAllText(dir, JsonConvert.SerializeObject(character));
        }
        protected virtual Character deserialize(String playerDir)
        {
            return JsonConvert.DeserializeObject<Character>(File.ReadAllText(playerDir));
        }
        protected virtual Boolean playerHasCharacter(string name)
        {
            var tempDir = $"Resources/CharacterData/{Context.User.ToString()}";
            var dir = System.IO.Path.GetFullPath(tempDir);
            string[] filePaths = Directory.GetFileSystemEntries( dir, "*.json");

            Boolean value = false;
            foreach ( string filepath in filePaths )
            {
                Character _ = JsonConvert.DeserializeObject<Character>(File.ReadAllText(filepath));
                if ( _.Name == name ) 
                {
                    value = true;
                    break;
                }
            }
            return value;
        }
        protected virtual string getSerialByName(string name)
        {
            // string[] filePaths = Directory.GetFileSystemEntries($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}", "*.json" );
            var tempDir = $"Resources/CharacterData/{Context.User.ToString()}/";
            var dir = System.IO.Path.GetFullPath(tempDir);
            string[] filePaths = Directory.GetFileSystemEntries( dir, "*.json" );

            foreach ( string file in filePaths )
            {
                Character _ = deserialize(file);
                if ( _.Name == name ) 
                {
                    return _.Serial;
                }
            }
            return "NONE";
        }
        protected virtual byte[] getHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        protected virtual string getHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in getHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        protected virtual string getTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        // [Group("ability"), Alias("a")]
        // public class Ability : Write
        // {
        //     [Command("strength"), Alias("s")]
        //     public async Task ChangeStrength([Remainder] string amount)
        //     {
        //         if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
        //         {
        //             if (int.TryParse(amount, out int number))
        //             {
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Base = number;
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.UpdateModifier();
        //                 serialize(Cooley.selectedCharacters[Context.User.ToString()]);
        //                 await ReplyAsync ( $"{Context.User.Mention} changed {Cooley.selectedCharacters[Context.User.ToString()].Name}'s strength stat to {number}" );
        //             }
        //             else
        //             {
        //                 await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
        //             }
        //         }
        //         else
        //         {
        //             await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
        //         }
        //     }
        //     [Command("dexterity"), Alias("d")]
        //     public async Task ChangeDexterity([Remainder] string amount)
        //     {
        //         if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
        //         {
        //             if (int.TryParse(amount, out int number))
        //             {
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.Base = number;
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.UpdateModifier();
        //                 serialize(Cooley.selectedCharacters[Context.User.ToString()]);
        //                 await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s dexterity stat to {number}" );
        //             }
        //             else
        //             {
        //                 await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
        //             }
        //         }
        //         else
        //         {
        //             await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
        //         }
        //     }
        //     [Command("constitution"), Alias("co")]
        //     public async Task ChangeConstitution([Remainder] string amount)
        //     {
        //         if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
        //         {
        //             if (int.TryParse(amount, out int number))
        //             {
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.Base = number;
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.UpdateModifier();
        //                 serialize(Cooley.selectedCharacters[Context.User.ToString()]);
        //                 await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s constitution stat to {number}" );
        //             }
        //             else
        //             {
        //                 await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
        //             }
        //         }
        //         else
        //         {
        //             await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
        //         }
        //     }
        //     [Command("intelligence"), Alias("i")]
        //     public async Task ChangeIntelligence([Remainder] string amount)
        //     {
        //         if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
        //         {
        //             if (int.TryParse(amount, out int number))
        //             {
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Base = number;
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.UpdateModifier();
        //                 serialize(Cooley.selectedCharacters[Context.User.ToString()]);
        //                 await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s intelligence stat to {number}" );
        //             }
        //             else
        //             {
        //                 await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
        //             }
        //         }
        //         else
        //         {
        //             await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
        //         }
        //     }
        //     [Command("charisma"), Alias("ch")]
        //     public async Task ChangeCharisma([Remainder] string amount)
        //     {
        //         if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
        //         {
        //             if (int.TryParse(amount, out int number))
        //             {
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Base = number;
        //                 Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.UpdateModifier();
        //                 serialize(Cooley.selectedCharacters[Context.User.ToString()]);
        //                 await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s charisma stat to {number}" );
        //             }
        //             else
        //             {
        //                 await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
        //             }
        //         }
        //         else
        //         {
        //             await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
        //         }
        //     }
        // }





    }
}
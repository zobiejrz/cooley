using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord.Commands;
using Discord.WebSocket;

using dnd_character_storage.Resources.Datatypes;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace dnd_character_storage.Core.Commands
{
    [Group("player"), Alias("p")]
    public class NewDeleteListSelect : ModuleBase<SocketCommandContext>
    {
        //
        // This Group is only to add/delete/list/select character files
        // 

        [Command("new"), Alias("n")]
        public async Task New([Remainder] string name)
        {
            checkIfNewUser(Context.User);
            if (isNewCharacter(Context.User, name))
            {
                Character character = new Character();
                character.Name = name;
                character.Owner = Context.User.ToString();
                var tempSerial = $"{Context.User.ToString()}{getTimestamp()}";
                character.Serial = getHashString(tempSerial);
                
                character.Profession = Professions.none;
                character.Race = Races.human;
                character.Alignment = Alignments.trueneutral;
                character.MaxHP = 0;
                character.TempHP = 0;
                character.CurrentHP = 0;

                character.Abilities = new Abilities();
                character.Abilities.Strength = new SubAbility();
                character.Abilities.Dexterity = new SubAbility();
                character.Abilities.Constitution = new SubAbility();
                character.Abilities.Intelligence = new SubAbility();
                character.Abilities.Charisma = new SubAbility();

                character.ProfBonus = 0;

                character.Skills = new Skills();
                character.zero();

                serialize(character);
                await ReplyAsync( Context.User.Mention + ", I finished your new character, " + character.Name + ". Use the -player select <name> command to select the character." );
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
        public async Task Select([Remainder] string name)
        {
            try
            {
                checkIfNewUser(Context.User);
                // var playerDir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User}/{getSerialByName(name)}.json";
                var tempDir = $"Resources/CharacterData/{Context.User.ToString()}/{getSerialByName(name)}.json";
                var dir = System.IO.Path.GetFullPath(tempDir);
                // read file into a string and deserialize JSON to a type

                if (playerHasCharacter(name))
                {
                    Character character = new Character();
                    character = deserialize( dir );
                    if ( Cooley.selectedCharacters.ContainsKey(Context.User.ToString()) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()] = character;
                    }
                    else
                    {
                        Cooley.selectedCharacters.Add(Context.User.ToString(), character);
                    }
                    await ReplyAsync($"{Context.User.Mention} has selected {character.Name} to be their character.");
                }
                else
                {
                    await ReplyAsync($"{Context.User.Mention} you don't have that character. Try selecting a different character, or '-player new <name>'. Use '-player list' to see all your characters.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [Command("select"), Alias("s")]
        public async Task SelectWithoutParam()
        {
            checkIfNewUser(Context.User);
            
            if (!Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character value))
            {
                await ReplyAsync($"{Context.User.Mention} you don't have a character selected! Try -player select <name> or -player new <name> to get started");
            }
            else
            {
                await ReplyAsync($"{Context.User.Mention} you have currently selected {Cooley.selectedCharacters[Context.User.ToString()].Name} as your character.");
            }
        }
        [Command("delete"), Alias("d")]
        public async Task delete([Remainder] string name)
        {
            try
            {

                checkIfNewUser(Context.User);
                if ( !playerHasCharacter(name) )
                {
                    await ReplyAsync ( $"{Context.User.Mention} that character doesn't exist, so I can't delete it. Maybe try something else?" );
                }
                else
                {
                    // var playerDir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User}/{getSerialByName(name)}.json";
                    var tempDir = $"Resources/CharacterData/{Context.User.ToString()}/{getSerialByName(name)}.json";
                    var dir = System.IO.Path.GetFullPath(tempDir);

                    // read file into a string and deserialize JSON to a type
                    Character character = new Character();
                    character = deserialize(dir);

                    if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character c)  && c.Name == character.Name )
                    {
                        Cooley.selectedCharacters.Remove(Context.User.ToString());
                    }
                    // File.Delete ( $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}/{getSerialByName(name)}.json" );
                    File.Delete( dir );

                    await ReplyAsync ( $"{Context.User.Mention} I've snapped {name} out of existance! No stones to bring them back this time." ); 
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine (e);
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
            // string[] filePaths = Directory.GetFileSystemEntries($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}", "*.json" );
            var tempDir = $"Resources/CharacterData/{Context.User.ToString()}";
            var dir = System.IO.Path.GetFullPath(tempDir);

            string[] filePaths = Directory.GetFileSystemEntries( dir, "*.json" );

            var list = "";
            foreach ( string filepath in filePaths )
            {
                Character _ = deserialize(filepath);
                list += $"'{_.Name}'";
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
        public Boolean isNewCharacter(SocketUser user, String name)
        {
            // string dir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{user.ToString()}/{getSerialByName(name)}.json";
            string tempDir = $"Resources/CharacterData/{user.ToString()}/{getSerialByName(name)}.json";
            var dir = System.IO.Path.GetFullPath(tempDir);

            if (File.Exists(dir)) return false;
            return true;
        }

        public void checkIfNewUser(SocketUser user)
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
        private Character deserialize(String playerDir)
        {
            var file = File.ReadAllText(playerDir);
            return JsonConvert.DeserializeObject<Character>(file);
        }

        private void serialize(Character character)
        {
            // var playerDir = $"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{character.Owner}/{character.Serial}.json";
            string tempDir = $"Resources/CharacterData/{character.Owner.ToString()}/{character.Serial}.json";
            var dir = System.IO.Path.GetFullPath(tempDir);
            File.WriteAllText(dir, JsonConvert.SerializeObject(character));
        }
        
        private string getSerialByName(string name)
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
        private Boolean playerHasCharacter(string name)
        {
            // string[] filePaths = Directory.GetFileSystemEntries($"/home/ben/Documents/GitHub/dnd_character_storage/Resources/CharacterData/{Context.User.ToString()}", "*.json" );
            var tempDir = $"Resources/CharacterData/{Context.User.ToString()}";
            var dir = System.IO.Path.GetFullPath(tempDir);
            string[] filePaths = Directory.GetFileSystemEntries( dir, "*.json");

            Boolean value = false;
            foreach ( string filepath in filePaths )
            {
                Character _ = deserialize(filepath);
                if ( _.Name == name ) 
                {
                    value = true;
                    break;
                }
            }
            return value;
        }
        private byte[] getHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        private string getHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in getHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        private string getTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }
    }

}
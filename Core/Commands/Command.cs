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
            string tempDir = $"Resources/CharacterData/{user.ToString()}/{getSerialByName(name)}.json";
            var dir = System.IO.Path.GetFullPath(tempDir);

            if (File.Exists(dir)) return false;
            return true;
        }
        protected virtual void checkIfNewUser(SocketUser user)
        {
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

        protected virtual Boolean isTrueValue (string a)
        {
            Boolean b = false;
            switch (a)
            {
                case "1":
                    b = true;
                    break;
                case "true":
                    b = true;
                    break;
                case "t":
                    b = true;
                    break;
                case "yes":
                    b = true;
                    break;
                case "y":
                    b = true;
                    break;
                case "pizza":
                    b = true;
                    break;
            }
            return b;
        }
    }
}
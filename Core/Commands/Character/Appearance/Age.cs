using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("age")]
    public class Age : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string age)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( int.TryParse(age, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Age = b;
                    await ReplyAsync( $"{Context.User.Mention} {character.Name} is now {b} years old." );
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} I'm sorry, but {age} isn't a number! Please try again with a valid number." );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("set"), Alias("s")]
        public async Task SetWithoutParameter()
        {
            await ReplyAsync ( $"{Context.User.Mention} You need to include the age you want your character to be! Try '-age set <number>'." );
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync( $"{Context.User.Mention} {character.Name} is {character.Age} years old." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias ("c")]
        public async Task CheckWithParameter([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync( $"{Context.User.Mention} {character.Name} is {character.Age} years old." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-age set <number>' to change your active character's age\n'-age check' to see your active character's age" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithParameter([Remainder] string a)
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-age set <number>' to change your active character's age\n'-age check' to see your active character's age" );
        }

    }

}
using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("ac")]
    public class ArmorClass : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string ac)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( int.TryParse(ac, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].ArmorClass = b;
                    await ReplyAsync( $"{Context.User.Mention} {character.Name}'s armor class is {character.ArmorClass}." );
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} I'm sorry, but {ac} isn't a number! Please try again with a valid number." );
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
            await ReplyAsync ( $"{Context.User.Mention} You need to include the armor class you want your character to be! Try '-ac set <number>'." );
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync( $"{Context.User.Mention} {character.Name}'s armor class is {character.ArmorClass}." );
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
                await ReplyAsync( $"{Context.User.Mention} {character.Name}'s armor class is {character.ArmorClass}." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-ac set <number>' to change your active character's armor class\n'-ac check' to see your active character's armor class" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithParameter([Remainder] string a)
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-ac set <number>' to change your active character's armor class\n'-ac check' to see your active character's armor class" );
        }

    }

}
using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("xp")]
    public class XP : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string xp)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( int.TryParse(xp, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].XP = b;
                    await ReplyAsync( $"{Context.User.Mention} {character.Name} now has {b} experience." );
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} I'm sorry, but {xp} isn't a number! Please try again with a valid number." );
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
            await ReplyAsync ( $"{Context.User.Mention} You need to include the experience you want your character have! Try '-xp set <number>'." );
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync( $"{Context.User.Mention} {character.Name} has {character.XP} experience." );
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
                await ReplyAsync( $"{Context.User.Mention} {character.Name} has {character.XP} experience." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-xp set <number>' to change your active character's experience\n'-xp check' to see your active character's experience" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithParameter([Remainder] string a)
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help!\n'-xp set <number>' to change your active character's experience\n'-xp check' to see your active character's experience" );
        }

    }

}
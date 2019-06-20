using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("eyes")]
    public class EyeColor : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].EyeColor = a;
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s eye color to {a}" );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("set"), Alias("s")]
        public async Task SetWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s eye color to... oh wait, you didn't tell me what to change the color to. Maybe try '-eye set <color>'." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s eyes are colored {character.EyeColor}." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task Check([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s eyes are colored {character.EyeColor}. I don't know what '{a}' means, but you included it for some reason." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help([Remainder] string a)
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the eye color commands:\n\t'-eye set <eye>' will change your active characters eye color\n\t'-eye check' will check your active character's eye color" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithoutParameter()
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the eye color commands:\n\t'-eye set <eye>' will change your active characters eye color\n\t'-eye check' will check your active character's eye color" );
        }
    }

}
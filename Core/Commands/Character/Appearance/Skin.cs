using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("skin")]
    public class SkinColor : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].SkinColor = a;
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s skin color to {a}" );
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
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s skin color to... oh wait, you didn't tell me what to change it to. Maybe try '-skin set <color>'." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s skin is colored {character.SkinColor}." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s skin is {character.SkinColor}. I don't know what '{a}' means, but you included it for some reason." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help([Remainder] string a)
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the skin color commands:\n\t'-skin set <color>' will change your active characters skin color\n\t'-skin check' will check your active character's skin color" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithoutParameter()
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the skin color commands:\n\t'-skin set <color>' will change your active characters skin color\n\t'-skin check' will check your active character's skin color" );
        }
    }

}
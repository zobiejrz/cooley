using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("height")]
    public class Height : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].Height = a;
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s height to {a}" );
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
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s height to... oh wait, you didn't tell me what to change the height to. Maybe try '-height set <height>'." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s is {character.Height} tall." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s is {character.Height} tall. I don't know what '{a}' means, but you included it for some reason." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help([Remainder] string a)
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the height commands:\n\t'-height set <height>' will change your active characters height\n\t'-height check' will check your active character's height" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithoutParameter()
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the height commands:\n\t'-height set <height>' will change your active characters height\n\t'-height check' will check your active character's height" );
        }
    }

}
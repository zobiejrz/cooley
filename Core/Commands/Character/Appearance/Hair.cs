using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("hair")]
    public class HairColor : Command
    {
        [Command("set"), Alias("s")]
        public async Task Set([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].HairColor = a;
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s hair color to {a}" );
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
                await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s hair color to... oh wait, you didn't tell me what to change it to. Maybe try '-hair set <color>'." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s hair is colored {character.HairColor}." );
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
                await ReplyAsync ( $"{Context.User.Mention} {character.Name}'s hair is {character.HairColor}. I don't know what '{a}' means, but you included it for some reason." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help([Remainder] string a)
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the hair color commands:\n\t'-hair set <color>' will change your active characters hair color\n\t'-hair check' will check your active character's hair color" );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithoutParameter()
        {
            await ReplyAsync ( $"{Context.User.Mention} Here are the hair color commands:\n\t'-hair set <color>' will change your active characters hair color\n\t'-hair check' will check your active character's hair color" );
        }
    }

}
using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("name"), Alias("n")]
    public class Name : Command
    {
        [Command("edit"), Alias("e")]
        public async Task change([Remainder] string name)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( !playerHasCharacter(name) )
                {
                    var oldName = Cooley.selectedCharacters[Context.User.ToString()].Name;
                    Cooley.selectedCharacters[Context.User.ToString()].Name = name;
                    serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                    await ReplyAsync ( $"{Context.User.Mention} you've renamed {oldName} to {name}!" );
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} you already have a character named {name}! Maybe try another name?" );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }

        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync ( $"{Context.User.Mention} your current character is {Cooley.selectedCharacters[Context.User.ToString()].Name}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }

        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.Mention} Correct usage: \n\t-name edit <name>\n\t-name check" );
        }

    }
}
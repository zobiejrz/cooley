using System.Threading.Tasks;
using Discord.Commands;
namespace dnd_character_storage.Core.Commands
{
    public class Help : Command
    {
        [Command("help"), Alias("h", "?")]
        public async Task help()
        {
            await ReplyAsync( $"{Context.User.Mention} here are the commands!"
                            + "\n-player"
                            + "\n-class"
                            + "\n-race"
                            + "\n-Health"
                            + "\n-name"
                            + "\n-alignment"
                            + "\n-<ability>" );
            /*
            **
            ** -<ability> [ check | set ] <number>
            **
            */
        }
    }

}
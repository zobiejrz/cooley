using System.Threading.Tasks;
using Discord.Commands;
namespace dnd_character_storage.Core.Commands
{
    public class Help : Command
    {
        [Command("help"), Alias("h", "?")]
        public async Task help()
        {
            await ReplyAsync( $"{Context.User.Mention} here are the commands! For more help do '-<command> ?'"
                            + "\n'-player' - Make a new character! Select it to use all of the lower commands!"
                            + "\n'-class' - Adds, Removes, and Edits classes for your character"
                            + "\n'-race' - There are many races to choose (NASCAR not included)"
                            + "\n'-health' - Let's you change temporary, max, and current HP"
                            + "\n'-name' - Let's you change your current character's name. Tax fraud, transition, we don't judge."
                            + "\n'-alignment' - This command group lets you change your alignment like a chaotic evil person would."
                            + "\n'-<ability>' - Abilities are Charisma, Constitution, Dexterity, Intelligence, Strength, and Wisdom!"
                            + "\n'-<skill>' - There is a lot. Maybe start by doing '-skill list'."
                            + "\n'-proficiency' - Check and edit your proficiency bonus!"
                            + "\n'-wallet' - This checks the money in your purse, and changes the amount in it."
                            + "\n'-inventory' - This is where you can keep anything you want!"
                            + "\n'-feature' - It's like your inventory but you keep the languages you know instead." 
                            + "\n'-roll [ 4 | 6 | 8 | 10 | 12 | 20 ]' - For all your dice-y needs!");
        }
    }

}
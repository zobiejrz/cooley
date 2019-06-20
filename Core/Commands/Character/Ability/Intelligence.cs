using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("intelligence"), Alias("i")]
    public class Intelligence : Command
    {
        [Command("check"), Alias("c")]
        public async Task Check([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync ( $"{Context.User.Mention} this command doesn't take parameters! Please try again!" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task CheckWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( character.Abilities.Dexterity.isProficient )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a intelligence of {character.Abilities.Intelligence.Base}, a modifier of {character.Abilities.Intelligence.Modifier}, and is proficient." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a intelligence of {character.Abilities.Intelligence.Base}, a modifier of {character.Abilities.Intelligence.Modifier}, and is not proficient." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("edit"), Alias("e")]
        public async Task Edit([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Base = b;
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.UpdateModifier();
                    Cooley.selectedCharacters[Context.User.ToString()].UpdateSkills();
                    await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s intelligence stat to {b}." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {a} isn't a valid number! Try again." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("edit"), Alias("e")]
        public async Task EditWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                await ReplyAsync ( $"{Context.User.Mention} what do I change the intelligence stat too? Try doing '-intelligence edit <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("proficient"), Alias("p")]
        public async Task Proficient([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( isTrueValue(a) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.isProficient = true;
                    await ReplyAsync ( $"{Context.User.Mention} gave {character.Name} a intelligence proficiency" );
                }
                else
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.isProficient = false;
                    await ReplyAsync ( $"{Context.User.Mention} removed {character.Name}'s intelligence proficiency" );
                }   
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("proficient"), Alias("p")]
        public async Task ProficientWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                if ( character.Abilities.Intelligence.isProficient )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does have a intelligence proficiency. Use '-intelligence proficient false' to remove it." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does not have a intelligence proficiency. Use '-intelligence proficient true' to aquire it." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("?", "h")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.Mention} here's how -intelligence works:\n\t-intelligence check\n\t-intelligence edit\n\t-intelligence proficient" );
        }
    }
}

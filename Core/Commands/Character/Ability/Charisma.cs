using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("charisma")]
    public class Charisma : Command
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
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a charisma of {character.Abilities.Charisma.Base}, a modifier of {character.Abilities.Charisma.Modifier}, and is proficient." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a charisma of {character.Abilities.Charisma.Base}, a modifier of {character.Abilities.Charisma.Modifier}, and is not proficient." );
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
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Base = b;
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.UpdateModifier();
                    Cooley.selectedCharacters[Context.User.ToString()].UpdateSkills();
                    await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s charisma stat to {b}." );
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
                await ReplyAsync ( $"{Context.User.Mention} what do I change the charisma stat too? Try doing '-charisma edit <number>'." );
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
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.isProficient = true;
                    await ReplyAsync ( $"{Context.User.Mention} gave {character.Name} a charisma proficiency" );
                }
                else
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.isProficient = false;
                    await ReplyAsync ( $"{Context.User.Mention} removed {character.Name}'s charisma proficiency" );
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
                if ( character.Abilities.Charisma.isProficient )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does have a charisma proficiency. Use '-charisma proficient false' to remove it." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does not have a charisma proficiency. Use '-charisma proficient true' to aquire it." );
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
            await ReplyAsync ( $"{Context.User.Mention} here's how -charisma works:\n\t-charisma check\n\t-charisma edit\n\t-charisma proficient" );
        }
    }
}

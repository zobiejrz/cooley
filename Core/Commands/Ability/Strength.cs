using System;
using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("strength"), Alias("s")]
    public class Strength : Command
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
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a strength of {character.Abilities.Strength.Base}, a modifier of {character.Abilities.Strength.Modifier}, and is proficient." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} has a strength of {character.Abilities.Strength.Base}, a modifier of {character.Abilities.Strength.Modifier}, and is not proficient." );
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
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Base = b;
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.UpdateModifier();
                    try
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].UpdateSkills();
                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine(e);
                    }
                    await ReplyAsync ( $"{Context.User.Mention} set {character.Name}'s strength stat to {b}." );
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
                await ReplyAsync ( $"{Context.User.Mention} what do I change the strength stat too? Try doing '-strength edit <number>'." );
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
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.isProficient = true;
                    await ReplyAsync ( $"{Context.User.Mention} gave {character.Name} a strength proficiency" );
                }
                else
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.isProficient = false;
                    await ReplyAsync ( $"{Context.User.Mention} removed {character.Name}'s strength proficiency" );
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
                if ( character.Abilities.Strength.isProficient )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does have a strength proficiency. Use '-strength proficient false' to remove it." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} does not have a strength proficiency. Use '-strength proficient true' to aquire it." );
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
            await ReplyAsync ( $"{Context.User.Mention} here's how -strength works:\n\t-strength check\n\t-strength edit\n\t-strength proficient" );
        }
    }
}

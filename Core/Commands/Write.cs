using System;
using System.Threading.Tasks;
using Discord.Commands;

using dnd_character_storage.Resources.Datatypes;


namespace dnd_character_storage.Core.Commands
{
    [Group("write"), Alias("w")]
    public class Write : ModuleBase<SocketCommandContext>
    {
        [Group("ability"), Alias("a")]
        public class Ability : ModuleBase<SocketCommandContext>
        {
            [Command("strength"), Alias("s")]
            public async Task ChangeStrength([Remainder] string amount)
            {
                try
                {
                    if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
                    {
                        if (int.TryParse(amount, out int number))
                        {
                            Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Base = number;
                            Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.UpdateModifier();
                            // Cooley.selectedCharacters[Context.User.ToString()] = character;
                            await ReplyAsync ( $"{Context.User.Mention} changed {Cooley.selectedCharacters[Context.User.ToString()].Name}'s strength stat to {number}" );
                        }
                        else
                        {
                            await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
                        }
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                    }
                }
                catch ( Exception e )
                {
                    Console.WriteLine (e);
                }
            }
            [Command("dexterity"), Alias("d")]
            public async Task ChangeDexterity([Remainder] string amount)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
                {
                    if (int.TryParse(amount, out int number))
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.Base = number;
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.UpdateModifier();
                        await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s dexterity stat to {number}" );
                    }
                    else
                    {
                        await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("constitution"), Alias("co")]
            public async Task ChangeConstitution([Remainder] string amount)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
                {
                    if (int.TryParse(amount, out int number))
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.Base = number;
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.UpdateModifier();
                        await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s constitution stat to {number}" );
                    }
                    else
                    {
                        await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("intelligence"), Alias("i")]
            public async Task ChangeIntelligence([Remainder] string amount)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
                {
                    if (int.TryParse(amount, out int number))
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Base = number;
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.UpdateModifier();
                        await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s intelligence stat to {number}" );
                    }
                    else
                    {
                        await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("charisma"), Alias("ch")]
            public async Task ChangeCharisma([Remainder] string amount)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
                {
                    if (int.TryParse(amount, out int number))
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Base = number;
                        Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.UpdateModifier();
                        await ReplyAsync ( $"{Context.User.Mention} changed {character.Name}'s charisma stat to {number}" );
                    }
                    else
                    {
                        await ReplyAsync ($"{Context.User.Mention} '{amount}' isn't a valid number!");
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }    
        }





    }
}
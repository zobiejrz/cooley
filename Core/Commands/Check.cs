using System.Threading.Tasks;
using Discord.Commands;
using dnd_character_storage.Resources.Datatypes;

namespace dnd_character_storage.Core.Commands
{
    [Group("check"), Alias("c")]
    public class Check : ModuleBase<SocketCommandContext>
    {
        [Command("strength"), Alias("s")]
        public async Task ChangeStrength()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                var b = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Base;
                var s = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Saving;
                var m = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Strength.Modifier;
                await ReplyAsync ( $"{Context.User.Mention} here is {character.Name}'s strength stats:\n\tBase: {b}\n\tModifier: {m}\n\tSaving: {s}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("dexterity"), Alias("d")]
        public async Task ChangeDexterity()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                var b = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.Base;
                var s = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.Saving;
                var m = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Dexterity.Modifier;
                await ReplyAsync ( $"{Context.User.Mention} here is {character.Name}'s dexterity stats:\n\tBase: {b}\n\tModifier: {m}\n\tSaving: {s}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("constitution"), Alias("co")]
        public async Task ChangeConstitution()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                var b = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.Base;
                var s = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.Saving;
                var m = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Constitution.Modifier;
                await ReplyAsync ( $"{Context.User.Mention} here is {character.Name}'s constitution stats:\n\tBase: {b}\n\tModifier: {m}\n\tSaving: {s}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("intelligence"), Alias("i")]
        public async Task ChangeIntelligence()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                var b = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Base;
                var s = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Saving;
                var m = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Intelligence.Modifier;
                await ReplyAsync ( $"{Context.User.Mention} here is {character.Name}'s intelligence stats:\n\tBase: {b}\n\tModifier: {m}\n\tSaving: {s}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("charisma"), Alias("ch")]
        public async Task ChangeCharisma()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character))
            {
                var b = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Base;
                var s = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Saving;
                var m = Cooley.selectedCharacters[Context.User.ToString()].Abilities.Charisma.Modifier;
                await ReplyAsync ( $"{Context.User.Mention} here is {character.Name}'s charisma stats:\n\tBase: {b}\n\tModifier: {m}\n\tSaving: {s}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }    
    }
}
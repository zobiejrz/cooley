using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("health"), Alias("h")]
    public class Health : Command
    {
        [Group("edit"), Alias("e")]
        public class change : Command
        {
            [Command("max"), Alias("m")]
            public async Task EditMax([Remainder] string a)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
                {
                    if ( int.TryParse(a, out int b) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].MaxHP = b;
                        await ReplyAsync ( $"{Context.User.Mention} changed {Cooley.selectedCharacters[Context.User.ToString()].Name}'s Max HP to {b}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} invalid value! To change Max HP you need to pass a number!" );
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("max"), Alias("m")]
            public async Task EditMaxNoParam()
            {
                await ReplyAsync ( $"{Context.User.Mention} Max HP cannot be changed without an input value. Try again with a number!" );
            }
            [Command("temp"), Alias("t")]
            public async Task EditTemp([Remainder] string a)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
                {
                    if ( int.TryParse(a, out int b) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].TempHP = b;
                        await ReplyAsync ( $"{Context.User.Mention} changed {Cooley.selectedCharacters[Context.User.ToString()].Name}'s Temp HP to {b}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} invalid value! To change Temp HP you need to pass a number!" );
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("temp"), Alias("t")]
            public async Task EditTempNoParam()
            {
                await ReplyAsync ( $"{Context.User.Mention} Temp HP cannot be changed without an input value. Try again with a number!" );
            }
            [Command("current"), Alias("c")]
            public async Task EditCurrent([Remainder] string a)
            {
                if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
                {
                    if ( int.TryParse(a, out int b) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].CurrentHP = b;
                        await ReplyAsync ( $"{Context.User.Mention} changed {Cooley.selectedCharacters[Context.User.ToString()].Name}'s Current HP to {b}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} invalid value! To change Current HP you need to pass a number!" );
                    }
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
                }
            }
            [Command("current"), Alias("c")]
            public async Task EditCurrentNoParam()
            {
                await ReplyAsync ( $"{Context.User.Mention} Current HP cannot be changed without an input value. Try again with a number!" );
            }
        }

        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                int max = Cooley.selectedCharacters[Context.User.ToString()].MaxHP;
                int temp = Cooley.selectedCharacters[Context.User.ToString()].TempHP;
                int current = Cooley.selectedCharacters[Context.User.ToString()].CurrentHP;
                await ReplyAsync ( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name}'s current health stats:\n\tCurrent: {current}\n\tMax: {max}\n\tTemporary: {temp}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.Mention} Correct usage: \n\t-health edit <stat> <value>\n\t-health check" );
        }
    }
}
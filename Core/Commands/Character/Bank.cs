using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("wallet")]
    public class Bank : Command
    {
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} {character.Name} has {character.Purse.Copper} copper, {character.Purse.Silver} silver, {character.Purse.Electrum} electrum, {character.Purse.Gold} gold, and {character.Purse.Platinum} platinum." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task Check([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} {character.Name} has {character.Purse.Copper} copper, {character.Purse.Silver} silver, {character.Purse.Electrum} electrum, {character.Purse.Gold} gold, and {character.Purse.Platinum} platinum." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("shorten"), Alias("s")]
        public async Task Consolidate()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].Purse.Consolidate();
                await ReplyAsync ( $"{Context.User.Mention} {character.Name} consolidated their wallet and has {character.Purse.Copper} copper, {character.Purse.Silver} silver, {character.Purse.Electrum} electrum, {character.Purse.Gold} gold, and {character.Purse.Platinum} platinum." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("shorten"), Alias("s")]
        public async Task Consolidate([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                Cooley.selectedCharacters[Context.User.ToString()].Purse.Consolidate();
                await ReplyAsync ( $"{Context.User.Mention} {character.Name} consolidated their wallet and has {character.Purse.Copper} copper, {character.Purse.Silver} silver, {character.Purse.Electrum} electrum, {character.Purse.Gold} gold, and {character.Purse.Platinum} platinum." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("platinum"), Alias("p")]
        public async Task Platinum([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Purse.Platinum = b;
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} now has {b} platinum coins" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} you can't put {a} in your a wallet, please just use numbers." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("platinum"), Alias("p")]
        public async Task PlatinumWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} you didn't tell me what to put in the wallet. Try '-wallet platinum <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("gold"), Alias("g")]
        public async Task Gold([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Purse.Gold = b;
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} now has {b} gold coins" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} you can't put {a} in your a wallet, please just use numbers." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("gold"), Alias("g")]
        public async Task GoldWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} you didn't tell me what to put in the wallet. Try '-wallet gold <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("electrum"), Alias("e")]
        public async Task Electrum([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Purse.Electrum = b;
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} now has {b} electrum coins" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} you can't put {a} in your a wallet, please just use numbers." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("electrum"), Alias("e")]
        public async Task ElectrumWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} you didn't tell me what to put in the wallet. Try '-wallet electrum <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("silver"), Alias("s")]
        public async Task Silver([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Purse.Silver = b;
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} now has {b} silver coins" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} you can't put {a} in your a wallet, please just use numbers." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("silver"), Alias("s")]
        public async Task SilverWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} you didn't tell me what to put in the wallet. Try '-wallet silver <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("copper"), Alias("c")]
        public async Task Copper([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                if ( int.TryParse(a, out int b) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Purse.Copper = b;
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} now has {b} copper coins" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {character.Name} you can't put {a} in your a wallet, please just use numbers." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("copper"), Alias("c")]
        public async Task CopperWithoutParameter()
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character character) )
            {
                await ReplyAsync ( $"{Context.User.Mention} you didn't tell me what to put in the wallet. Try '-wallet copper <number>'." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.ToString()} so you needed help? Here you go:\n\t'-wallet check' to see current balance\n\t'-wallet shorten' consolidates wallet\n\t'-wallet <coin>' to change number of coins." );
        }
        [Command("help"), Alias("h", "?")]
        public async Task HelpWithParameter([Remainder] string a)
        {
            await ReplyAsync ( $"{Context.User.ToString()} so you needed help? Here you go:\n\t'-wallet check' to see current balance\n\t'-wallet shorten' consolidates wallet\n\t'-wallet <coin>' to change number of coins." );
        }
    }

}
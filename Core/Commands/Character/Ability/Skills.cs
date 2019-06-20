using Discord.Commands;
using System.Threading.Tasks;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("skill")]
    public class Skill : Command
    {
        [Command("acrobatics")]
        public async Task Acrobatics()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Acrobatics} for acrobatics." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("animal")]
        public async Task AnimalHandeling()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.AnimalHandeling} for animal handeling." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("arcana")]
        public async Task Arcana()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Arcana} for arcana." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("athletics")]
        public async Task Athletics()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Athletics} for athletics." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("deception")]
        public async Task Deception()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Deception} for deception." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("history")]
        public async Task History()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.History} for history." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("insight")]
        public async Task Insight()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Insight} for insight." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("intimidation")]
        public async Task Intimidation()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Intimidation} for intimidation." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("investigation")]
        public async Task Investigation()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Investigation} for investigation." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("medicine")]
        public async Task Medicine()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Medicine} for medicine." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("nature")]
        public async Task Nature()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Nature} for nature." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("perception")]
        public async Task Perception()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Perception} for perception." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("performance")]
        public async Task Performance()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Performance} for performance." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("persuasion")]
        public async Task Persuasion()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Persuasion} for persuasion." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("religion")]
        public async Task Religion()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Religion} for religion." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("sleight")]
        public async Task SleightOfHand()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.SleightOfHand} for sleight of hand." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("stealth")]
        public async Task Stealth()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Stealth} for stealth." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("survival")]
        public async Task Survival()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character a))
            {
                await ReplyAsync ( $"{Context.User.Mention} {a.Name} has a {a.Skills.Survival} for survival." );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("help"), Alias("?", "h")]
        public async Task Help()
        {
            await ReplyAsync ( $"To use the skill command type '-skill <skill>' to list the skill's score, or '-skill list' to see all skills." );
        }

        [Command("list"), Alias("l")]
        public async Task List()
        {
            string list = "Acrobatics\nAnimal Handeling (type 'animal')\nArcana\nAthletics\nDeception\nHistory\nInsight\nIntimidation\nInvestigation\nMedicine\nNature\nPerception\nPerformance\nPersuasion\nReligion\nSleight of Hand (type 'sleight')\nStealth\nSurvival";
            await ReplyAsync ( $"{Context.User.Mention} here are all the skills:\n{list}" );
        }
    }
}
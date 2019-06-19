using Discord.Commands;
using System;
using System.Threading.Tasks;
using System.Linq;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("alignment"), Alias("a")]
    public class Alignment : Command
    {
        public string[] align = new string[] {"lawful good", "lawful neutral", "lawful evil", "neutral good", "true neutral", "neutral evil", "chaotic good", "chaotic neutral", "chaotic evil"};
        [Command("edit"), Alias("e")]
        public async Task edit([Remainder] string s)
        {
            s = s.ToLower();
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( int.TryParse(s, out int a) )
                {
                    if ( a >= 1 && a <= align.Length )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Alignment = getAlignmentFromInt(a - 1);
                        serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                        await ReplyAsync ( $"{Context.User.Mention} set {Cooley.selectedCharacters[Context.User.ToString()].Name}'s alignment to {Cooley.selectedCharacters[Context.User.ToString()].getAlignment()}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} thats an invalid alignment code! Alignment codes are numbers 1-9!" );
                    }
                }
                else if ( align.Contains(s) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Alignment = getAlignmentFromString(s);
                    serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                    await ReplyAsync ( $"{Context.User.Mention} set {Cooley.selectedCharacters[Context.User.ToString()].Name}'s alignment to {Cooley.selectedCharacters[Context.User.ToString()].getAlignment()}" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} invalid alignment. Use '-alignment list' to see a list of valid alignments." );
                }
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("edit"), Alias("e")]
        public async Task EditWithoutParam()
        {
            await ReplyAsync ( $"{Context.User.Mention} what should I change the alignment to? Use '-alignment list' for options." );
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync ( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name}'s alignment is {Cooley.selectedCharacters[Context.User.ToString()].getAlignment()}" );
            }
            else
            {
                await ReplyAsync ( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("list"), Alias("l")]
        public async Task List()
        {
            string list = "";
            for ( int i = 1; i < 10; i++ )
            {
                list += $"{i}. {align[i-1]}\n";
            }
            await ReplyAsync ( $"{Context.User.Mention} here is the list of alignments:\n{list}" );
        }


        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.Mention} Correct usage: \n\t'-alignment edit <alignment>' to change selected characters alignment\n\t'-alignment check' to check selected characters alignment\n\t'-alignment list' to see all alignments" );
        }
        private Alignments getAlignmentFromInt(int a)
        {
            Alignments value = Alignments.trueneutral;
            switch (a)
            {
                case 0:
                    value = Alignments.lawfulgood;
                    break;
                case 1:
                    value = Alignments.lawfulneutral;
                    break;
                case 2:
                    value = Alignments.lawfulevil;
                    break;
                case 3:
                    value = Alignments.neutralgood;
                    break;
                case 4:
                    value = Alignments.trueneutral;
                    break;
                case 5:
                    value = Alignments.neutralevil;
                    break;
                case 6:
                    value = Alignments.chaoticgood;
                    break;
                case 7:
                    value = Alignments.chaoticneutral;
                    break;
                case 8:
                    value = Alignments.chaoticevil;
                    break;
                default:
                    value = Alignments.trueneutral;
                    break;
            }
            return value;
        }
        private Alignments getAlignmentFromString(string a)
        {
            Alignments value = Alignments.trueneutral;
            switch (a)
            {
                case "lawful good":
                    value = Alignments.lawfulgood;
                    break;
                case "lawful neutral":
                    value = Alignments.lawfulneutral;
                    break;
                case "lawful evil":
                    value = Alignments.lawfulevil;
                    break;
                case "neutral good":
                    value = Alignments.neutralgood;
                    break;
                case "true neutral":
                    value = Alignments.trueneutral;
                    break;
                case "neutral evil":
                    value = Alignments.neutralevil;
                    break;
                case "chaotic good":
                    value = Alignments.chaoticgood;
                    break;
                case "chaotic neutral":
                    value = Alignments.chaoticneutral;
                    break;
                case "chaotic evil":
                    value = Alignments.chaoticevil;
                    break;
                default:
                    value = Alignments.trueneutral;
                    break;
            }
            return value;
        }
    }
}
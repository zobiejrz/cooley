using Discord.Commands;
using System;
using System.Threading.Tasks;
using System.Linq;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("race"), Alias("r")]
    public class Race : Command
    {
        public string[] races = new string[] {"none", "dragonborn", "dwarf", "elf", "gnome", "half elf", "halfling", "orc", "half orc", "human", "tiefling", "feral tiefling", "aarakocra", "air genasi", "earth genasi", "fire genasi", "water genasi", "goliath", "aasimar", "bugbear", "firbolg", "goblin", "hobgoblin", "kenku", "kobold", "lizardfolk", "tabaxi", "triton", "yuanti pureblood", "tortle", "gith", "changeling", "kalashtar", "beasthide shifter", "longtooth shifter", "swiftstride shifter", "wildhunt shifter", "warforged", "centaur", "loxodon", "minotaur", "simichybrid", "vedalken"};
        [Command("edit"), Alias("e")]
        public async Task edit([Remainder] string name)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( int.TryParse(name, out int a) )
                {
                    if ( a > 0 && a < 43 )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Race = getRaceFromInt(a);
                        serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                        await ReplyAsync ( $"{Context.User.Mention} set {Cooley.selectedCharacters[Context.User.ToString()].Name}'s race to {Cooley.selectedCharacters[Context.User.ToString()].Race}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} thats an invalid race code! Race codes are numbers 1-42!" );
                    }
                }
                else if ( races.Contains(name) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Race = getRaceFromString(name);
                    serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                    await ReplyAsync ( $"{Context.User.Mention} set {Cooley.selectedCharacters[Context.User.ToString()].Name}'s race to {Cooley.selectedCharacters[Context.User.ToString()].Race}" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} invalid race. Use '-race list' to see a list of valid races." );
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
            await ReplyAsync ( $"{Context.User.Mention} what should I change the race to? Use '-race list' for options." );
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync ( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name}'s race is {Cooley.selectedCharacters[Context.User.ToString()].Race}" );
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
            for ( int i = 1; i < 43; i++ )
            {
                list += $"{i}. {races[i]}\n";
            }
            await ReplyAsync ( $"{Context.User.Mention} here is the list of races:\n{list}" );
        }


        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            await ReplyAsync ( $"{Context.User.Mention} Correct usage: \n\t'-race edit <race>' to change selected characters race\n\t'-name check' to check selected characters race\n\t'-name list' to see all races" );
        }

        private Races getRaceFromInt(int a)
        {
            Races value;
            switch ( a )
            {
                case 1:
                    value = Races.dragonborn;
                    break;
                case 2:
                    value = Races.dwarf;
                    break;
                case 3:
                    value = Races.elf;
                    break;
                case 4:
                    value = Races.gnome;
                    break;
                case 5:
                    value = Races.halfelf;
                    break;
                case 6:
                    value = Races.halfling;
                    break;
                case 7:
                    value = Races.orc;
                    break;
                case 8:
                    value = Races.halforc;
                    break;
                case 9:
                    value = Races.human;
                    break;
                case 10:
                    value = Races.tiefling;
                    break;
                case 11:
                    value = Races.feraltiefling;
                    break;
                case 12:
                    value = Races.aarakocra;
                    break;
                case 13:
                    value = Races.airgenasi;
                    break;
                case 14:
                    value = Races.earthgenasi;
                    break;
                case 15:
                    value = Races.firegenasi;
                    break;
                case 16:
                    value = Races.watergenasi;
                    break;
                case 17:
                    value = Races.goliath;
                    break;
                case 18:
                    value = Races.aasimar;
                    break;
                case 19:
                    value = Races.bugbear;
                    break;
                case 20:
                    value = Races.firbolg;
                    break;
                case 21:
                    value = Races.goblin;
                    break;
                case 22:
                    value = Races.hobgoblin;
                    break;
                case 23:
                    value = Races.kenku;
                    break;
                case 24:
                    value = Races.kobold;
                    break;
                case 25:
                    value = Races.lizardfolk;
                    break;
                case 26:
                    value = Races.tabaxi;
                    break;
                case 27:
                    value = Races.triton;
                    break;
                case 28:
                    value = Races.yuantipureblood;
                    break;
                case 29:
                    value = Races.tortle;
                    break;
                case 30:
                    value = Races.gith;
                    break;
                case 31:
                    value = Races.changeling;
                    break;
                case 32:
                    value = Races.kalashtar;
                    break;
                case 33:
                    value = Races.beasthideshifter;
                    break;
                case 34:
                    value = Races.longtoothshifter;
                    break;
                case 35:
                    value = Races.swiftstrideshifter;
                    break;
                case 36:
                    value = Races.wildhuntshifter;
                    break;
                case 37:
                    value = Races.warforged;
                    break;
                case 38:
                    value = Races.centaur;
                    break;
                case 39:
                    value = Races.loxodon;
                    break;
                case 40:
                    value = Races.minotaur;
                    break;
                case 41:
                    value = Races.simichybrid;
                    break;
                case 42:
                    value = Races.vedalken;
                    break;
                default:
                    value = Races.human;
                    break;
            }

            return value;
        }

        private Races getRaceFromString(string a)
        {
            a = a.ToLower();
            Races value;
            switch ( a )
            {
                case "dragon born":
                    value = Races.dragonborn;
                    break;
                case "dwarf":
                    value = Races.dwarf;
                    break;
                case "elf":
                    value = Races.elf;
                    break;
                case "gnome":
                    value = Races.gnome;
                    break;
                case "half elf":
                    value = Races.halfelf;
                    break;
                case "halfling":
                    value = Races.halfling;
                    break;
                case "orc":
                    value = Races.orc;
                    break;
                case "half orc":
                    value = Races.halforc;
                    break;
                case "human":
                    value = Races.human;
                    break;
                case "tiefling":
                    value = Races.tiefling;
                    break;
                case "feral tiefling":
                    value = Races.feraltiefling;
                    break;
                case "aarakocra":
                    value = Races.aarakocra;
                    break;
                case "air genasi":
                    value = Races.airgenasi;
                    break;
                case "earth genasi":
                    value = Races.earthgenasi;
                    break;
                case "fire genasi":
                    value = Races.firegenasi;
                    break;
                case "water genasi":
                    value = Races.watergenasi;
                    break;
                case "goliath":
                    value = Races.goliath;
                    break;
                case "aasimar":
                    value = Races.aasimar;
                    break;
                case "bugbear":
                    value = Races.bugbear;
                    break;
                case "firbolg":
                    value = Races.firbolg;
                    break;
                case "goblin":
                    value = Races.goblin;
                    break;
                case "hobgoblin":
                    value = Races.hobgoblin;
                    break;
                case "kenku":
                    value = Races.kenku;
                    break;
                case "kobold":
                    value = Races.kobold;
                    break;
                case "lizardfolk":
                    value = Races.lizardfolk;
                    break;
                case "tabaxi":
                    value = Races.tabaxi;
                    break;
                case "triton":
                    value = Races.triton;
                    break;
                case "yuanti pureblood":
                    value = Races.yuantipureblood;
                    break;
                case "tortle":
                    value = Races.tortle;
                    break;
                case "gith":
                    value = Races.gith;
                    break;
                case "changeling":
                    value = Races.changeling;
                    break;
                case "kalashtar":
                    value = Races.kalashtar;
                    break;
                case "beasthide shifter":
                    value = Races.beasthideshifter;
                    break;
                case "longtooth shifter":
                    value = Races.longtoothshifter;
                    break;
                case "swiftstride shifter":
                    value = Races.swiftstrideshifter;
                    break;
                case "wildhunt shifter":
                    value = Races.wildhuntshifter;
                    break;
                case "warforged":
                    value = Races.warforged;
                    break;
                case "centaur":
                    value = Races.centaur;
                    break;
                case "loxodon":
                    value = Races.loxodon;
                    break;
                case "minotaur":
                    value = Races.minotaur;
                    break;
                case "simichybrid":
                    value = Races.simichybrid;
                    break;
                case "vedalken":
                    value = Races.vedalken;
                    break;
                default:
                    value = Races.human;
                    break;
            }

            return value;
        }

    }
}
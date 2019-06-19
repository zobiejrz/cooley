using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("class"), Alias("c")]
    public class Class : Command
    {
        public string[] professions = new string[] {"barbarian", "bard", "cleric", "druid", "fighter", "monk", "paladin", "ranger", "rogue", "sorceror", "warlock", "wizard", "artificer"};

        [Command("add"), Alias("a")]
        public async Task Add([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( int.TryParse(a, out int b) )
                {
                    if ( b >= 0 && b <= professions.Length )
                    {
                        var cla = getProfessionFromInt(b);
                        if ( !Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(cla) )
                        {
                            Cooley.selectedCharacters[Context.User.ToString()].Profession.Add(cla, 0);
                            serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is now a level 0 {cla}" );
                        }
                        else
                        {
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} already has that class." );
                        }
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} {a} is an invalid class code! Class codes are number 1-13. Or use '-class list' to see valid classes." );
                    }
                }
                else if ( professions.Contains(a) )
                {
                    var cla = getProfessionFromString(a);
                    if ( !Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(cla) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Profession.Add(cla, 0);
                        serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                        await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is now a level 0 {cla}" );
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} already has that class." );
                    }
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} that is an invalid class. Use '-class list' to see available classes, and use '-class check' to see active classes." );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selectd! Use -player select <name> to use this command!" );
            }
        }
        [Command("delete"), Alias("d")]
        public async Task Delete([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( int.TryParse(a, out int b) )
                {
                    if ( b >= 0 && b <= professions.Length )
                    {
                        var cla = getProfessionFromInt(b);
                        if ( Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(cla) )
                        {
                            Cooley.selectedCharacters[Context.User.ToString()].Profession.Remove(cla);
                            serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is no longer a {cla}" );
                        }
                        else
                        {
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is not a {cla} and so I can't delete that!" );
                        }
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} that is an invalid class code! Class codes are number 1-13. Use '-class list' to see valid classes. Use '-class check' to see active classes." );
                    }
                }
                else if ( professions.Contains(a) )
                {
                    var cla = getProfessionFromString(a);
                    if ( Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(cla) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Profession.Remove(cla);
                        serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                        await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is no longer a {cla}" );
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is not a {cla} and so I can't delete that! Use '-class check' to see active classes." );
                    }
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} that is an invalid class. Use '-class list' to see available classes, and use '-class check' to see active classes." );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("level"), Alias("lv")]
        public async Task Level([Remainder] string a)
        {
            string[] parts = a.Split(" ");
            string claString = parts[0];
            string lvlString = parts[1];

            Professions tempClass;

            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                if ( int.TryParse(claString, out int claInt) )
                {
                    if ( claInt > 0 && claInt < professions.Length )
                    {
                        tempClass = getProfessionFromInt(claInt);
                        if ( Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(tempClass) )
                        {
                            if ( int.TryParse(lvlString, out int lvl) )
                            {
                                Cooley.selectedCharacters[Context.User.ToString()].Profession[tempClass] = lvl;
                                serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                                await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is now a level {lvl} {tempClass}" );
                            }
                            else
                            {
                                await ReplyAsync( $"{Context.User.Mention} {lvlString} is not a number! Please use '-class level <class> <level>' where <class> is a valid class and <level> is a number!" );
                            }
                        }
                        else
                        {
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is not a {tempClass} so they can't be leveled up! Use '-class check' to see active classes." );
                        }
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} {a} is an invalid class code. Class codes are numbers 1-13. Use '-class list' to see available classes." );
                    }
                }
                else if ( professions.Contains(claString) )
                {
                    tempClass = getProfessionFromString(claString);
                    if ( Cooley.selectedCharacters[Context.User.ToString()].Profession.ContainsKey(tempClass) )
                    {
                        if ( int.TryParse(lvlString, out int lvl) )
                        {
                            Cooley.selectedCharacters[Context.User.ToString()].Profession[tempClass] = lvl;
                            serialize(Cooley.selectedCharacters[Context.User.ToString()]);
                            await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} is now a level {lvl} {tempClass}" );
                        }
                        else
                        {
                            await ReplyAsync( $"{Context.User.Mention} {lvlString} is not a number! Please use '-class level <class> <level>' where <class> is a valid class and <level> is a number!" );
                        }
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()]} is not a {tempClass} so they can't be leveled up! Use '-class check' to see active classes." );
                    }
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} that is an invalid class code. Use '-class list' to see valid classes." );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                string list = "";
                foreach(KeyValuePair<Professions, int> a in Cooley.selectedCharacters[Context.User.ToString()].Profession)
                {
                    list += $"Level {a.Value} {a.Key}\n";
                }

                if ( list != "" )
                {
                    await ReplyAsync( $"{Context.User.Mention} here is {Cooley.selectedCharacters[Context.User.ToString()].Name}'s classes:\n{list}" );
                }
                else
                {
                    await ReplyAsync( $"{Context.User.Mention} {Cooley.selectedCharacters[Context.User.ToString()].Name} doesn't have any classes. Use '-class add <class>' to get started." );
                }
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
            for ( int i = 1; i < 14; i++ )
            {
                list += $"{i}. {professions[i-1]}\n";
            }
            await ReplyAsync ( $"{Context.User.Mention} here is the list of classes:\n{list}" );
        }
        [Command("help"), Alias("?", "h")]
        public async Task Help()
        {
            await ReplyAsync( $"{Context.User.Mention} Here's some help with the -class command:\n\t'-class add <class>' adds <class> to active character\n\t'-class delete <class>' deletes <class> from active character\n\t'-class level <class> <level>' sets <class> to <level> for active character\n\t'-class check' to see the active character's classes\n\t'-class list' to see valid classes." );
        }
        private Professions getProfessionFromInt(int a)
        {
            Professions value;
            a--;
            switch (a)
            {
                case 0:
                    value = Professions.barbarian;
                    break;
                case 1:
                    value = Professions.bard;
                    break;
                case 2:
                    value = Professions.cleric;
                    break;
                case 3:
                    value = Professions.druid;
                    break;
                case 4:
                    value = Professions.fighter;
                    break;
                case 5:
                    value = Professions.monk;
                    break;
                case 6:
                    value = Professions.paladin;
                    break;
                case 7:
                    value = Professions.ranger;
                    break;
                case 8:
                    value = Professions.rogue;
                    break;
                case 9:
                    value = Professions.sorceror;
                    break;
                case 10:
                    value = Professions.warlock;
                    break;
                case 11:
                    value = Professions.wizard;
                    break;
                case 12:
                    value = Professions.artificer;
                    break;
                default:
                    value = Professions.paladin;
                    break;
            }

            return value;
        }
        private Professions getProfessionFromString(string a)
        {
            Professions value;
            switch (a)
            {
                case "barbarian":
                    value = Professions.barbarian;
                    break;
                case "bard":
                    value = Professions.bard;
                    break;
                case "cleric":
                    value = Professions.cleric;
                    break;
                case "druid":
                    value = Professions.druid;
                    break;
                case "fighter":
                    value = Professions.fighter;
                    break;
                case "monk":
                    value = Professions.monk;
                    break;
                case "paladin":
                    value = Professions.paladin;
                    break;
                case "ranger":
                    value = Professions.ranger;
                    break;
                case "rogue":
                    value = Professions.rogue;
                    break;
                case "sorceror":
                    value = Professions.sorceror;
                    break;
                case "warlock":
                    value = Professions.warlock;
                    break;
                case "wizard":
                    value = Professions.wizard;
                    break;
                case "artificer":
                    value = Professions.artificer;
                    break;
                default:
                    value = Professions.paladin;
                    break;
            }
            return value;
        }
    }
}
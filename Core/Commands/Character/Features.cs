using System;
using System.Threading.Tasks;
using Discord.Commands;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("feature"), Alias("f")]
    public class Features : Command
    {
        [Command("add"), Alias("a")]
        public async Task Add([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character c))
            {
                string[] b = a.Split(" - ");
                if ( b.Length < 2 )
                {
                    await ReplyAsync( $"{Context.User.Mention} You need to include a description! Separate the name and description with a ' - '. Like, '-inv add <name> - <description>'" );
                }
                else if ( b.Length > 2)
                {
                    await ReplyAsync( $"{Context.User.Mention} You can only have one description! Try using ' - ' only once!" );
                }
                else
                {
                    string name = b[0];
                    string description = b[1];
                    Item temp = new Item();
                    temp.Name = name;
                    temp.Description = description;
                    
                    if ( !c.Features.Contains(temp) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Features.Add(temp);
                        await ReplyAsync( $"{Context.User.Mention} added '{name}' to {c.Name}'s feature list" );
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} you already have '{name}' in {c.Name}'s feature list so I didn't put it in again." );
                    }

                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("add"), Alias("a")]
        public async Task AddWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync( $"{Context.User.Mention} add what? Try '-feature list add <name> - <description>' to add something to your feature list." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        [Command("delete"), Alias("d")]
        public async Task Delete([Remainder] string a)
        {
            if ( Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character c) )
            {
                if ( hasItemWithName(a) )
                {
                    Cooley.selectedCharacters[Context.User.ToString()].Features.Remove(getItemByName(a));
                    await ReplyAsync ( $"{Context.User.Mention} I found '{a}' in {c.Name}'s feature list and removed it." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} I don't think {c.Name} has something called {a} in their feature list, so I didn't remove anything." );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("delete"), Alias("d")]
        public async Task DeleteWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync( $"{Context.User.Mention} add what? Try '-feature list delete <name> - <description>' to remove something to your feature list." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("name"), Alias("n")]
        public async Task EditName([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                string[] b = a.Split(" - ");
                string name = b[0];
                if ( b.Length > 2 )
                {
                    await ReplyAsync( $"{Context.User.Mention} you are definitely trying to many things. Only '-feature list name <name> - <new name>' works." );
                }
                else if ( b.Length < 2)
                {
                    await ReplyAsync( $"{Context.User.Mention} it looks like you didn't give me the new name. Try '-feature list name <name> - <new name>'.'" );
                }
                else
                {
                    if ( hasItemWithName(name) )
                    {
                        int index = Cooley.selectedCharacters[Context.User.ToString()].Features.IndexOf(getItemByName(name));
                        string newName = b[1];
                        Cooley.selectedCharacters[Context.User.ToString()].Features[index].Name = newName;
                        await ReplyAsync ( $"{Context.User.Mention} renamed {name} to {newName}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} you don't have {name} in your feature list!" );
                    }
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("description"), Alias("d")]
        public async Task EditDescription([Remainder] string a)
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                string[] b = a.Split(" - ");
                string name = b[0];
                if ( b.Length > 2 )
                {
                    await ReplyAsync( $"{Context.User.Mention} you are definitely trying to many things. Only '-feature list description <name> - <new description>' works." );
                }
                else if ( b.Length < 2)
                {
                    await ReplyAsync( $"{Context.User.Mention} it looks like you didn't give me the new name. Try '-feature list description <name> - <new description>'.'" );
                }
                else
                {
                    if ( hasItemWithName(name) )
                    {
                        int index = Cooley.selectedCharacters[Context.User.ToString()].Features.IndexOf(getItemByName(name));
                        string newDescription = b[1];
                        Cooley.selectedCharacters[Context.User.ToString()].Features[index].Description = newDescription;
                        await ReplyAsync ( $"{Context.User.Mention} set the description of {name} to {newDescription}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} you don't have {name} in your feature list!" );
                    }
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("edit"), Alias("e")]
        public async Task EditWithoutParameter()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character _))
            {
                await ReplyAsync( $"{Context.User.Mention} what? Try '-feature list [ name | description ] <name> - <new value>' to the name/description of something to your feature list." );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("check"), Alias("c")]
        public async Task Check()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character c))
            {
                string list = "";
                foreach ( Item i in Cooley.selectedCharacters[Context.User.ToString()].Features )
                {
                    list += $"{i.ToString()}\n";
                }
                if ( list != "" )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {c.Name}'s Features:\n{list}" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {c.Name}'s features list is empty!" );
                }
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }
        [Command("help"), Alias("h", "?")]
        public async Task Help()
        {
            if (Cooley.selectedCharacters.TryGetValue(Context.User.ToString(), out Character c))
            {
                await ReplyAsync( $"{Context.User.Mention} Here's the feature list commands\n\t'-feature check' to list features'\n\t'-feature add <name> - <description>' adds a feature\n\t'-feature delete <name>' deletes a feature\n\t'-feature [ name | description ] <name> <new value>' edits the name or description of a feature" );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        private Boolean hasItemWithName(string name)
        {
            foreach (Item item in Cooley.selectedCharacters[Context.User.ToString()].Features)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        private Item getItemByName(string name)
        {
            Item error = new Item();
            error.Name = "Error";
            error.Description = "It's an error; They are only worth the tears it takes to destroy them.";

            foreach (Item item in Cooley.selectedCharacters[Context.User.ToString()].Features)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return error;
        }
    }

}
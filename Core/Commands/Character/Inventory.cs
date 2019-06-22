using System;
using System.Threading.Tasks;
using Discord.Commands;
using dnd_character_storage.Resources.Datatypes;
namespace dnd_character_storage.Core.Commands
{
    [Group("inventory"), Alias("inv", "i")]
    public class Inventory : Command
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
                    
                    if ( !c.Inventory.Contains(temp) )
                    {
                        Cooley.selectedCharacters[Context.User.ToString()].Inventory.Add(temp);
                        await ReplyAsync( $"{Context.User.Mention} added '{name}' to {c.Name}'s inventory" );
                    }
                    else
                    {
                        await ReplyAsync( $"{Context.User.Mention} you already have '{name}' in {c.Name}'s inventory so I didn't put it in again." );
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
                await ReplyAsync( $"{Context.User.Mention} add what? Try '-inventory add <name> - <description>' to add something to your inventory." );
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
                    Cooley.selectedCharacters[Context.User.ToString()].Inventory.Remove(getItemByName(a));
                    await ReplyAsync ( $"{Context.User.Mention} I found '{a}' in {c.Name}'s inventory and removed it." );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} I don't think {c.Name} has something called {a} in their inventory, so I didn't remove anything." );
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
                await ReplyAsync( $"{Context.User.Mention} add what? Try '-inventory delete <name> - <description>' to remove something to your inventory." );
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
                    await ReplyAsync( $"{Context.User.Mention} you are definitely trying to many things. Only '-inventory name <name> - <new name>' works." );
                }
                else if ( b.Length < 2)
                {
                    await ReplyAsync( $"{Context.User.Mention} it looks like you didn't give me the new name. Try '-inventory name <name> - <new name>'.'" );
                }
                else
                {
                    if ( hasItemWithName(name) )
                    {
                        int index = Cooley.selectedCharacters[Context.User.ToString()].Inventory.IndexOf(getItemByName(name));
                        string newName = b[1];
                        Cooley.selectedCharacters[Context.User.ToString()].Inventory[index].Name = newName;
                        await ReplyAsync ( $"{Context.User.Mention} renamed {name} to {newName}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} you don't have {name} in your inventory!" );
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
                    await ReplyAsync( $"{Context.User.Mention} you are definitely trying to many things. Only '-inventory description <name> - <new description>' works." );
                }
                else if ( b.Length < 2)
                {
                    await ReplyAsync( $"{Context.User.Mention} it looks like you didn't give me the new name. Try '-inventory description <name> - <new description>'.'" );
                }
                else
                {
                    if ( hasItemWithName(name) )
                    {
                        int index = Cooley.selectedCharacters[Context.User.ToString()].Inventory.IndexOf(getItemByName(name));
                        string newDescription = b[1];
                        Cooley.selectedCharacters[Context.User.ToString()].Inventory[index].Description = newDescription;
                        await ReplyAsync ( $"{Context.User.Mention} set the description of {name} to {newDescription}" );
                    }
                    else
                    {
                        await ReplyAsync ( $"{Context.User.Mention} you don't have {name} in your inventory!" );
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
                await ReplyAsync( $"{Context.User.Mention} what? Try '-inventory [ name | description ] <name> - <new value>' to the name/description of something to your inventory." );
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
                foreach ( Item i in Cooley.selectedCharacters[Context.User.ToString()].Inventory )
                {
                    list += $"{i.ToString()}\n";
                }
                if ( list != "" )
                {
                    await ReplyAsync ( $"{Context.User.Mention} {c.Name}'s Inventory:\n{list}" );
                }
                else
                {
                    await ReplyAsync ( $"{Context.User.Mention} {c.Name}'s Inventory is empty!" );
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
                await ReplyAsync( $"{Context.User.Mention} Here's the inventory commands\n\t'-inventory check' to list inventory'\n\t'-inventory add <name> - <description>' adds an item\n\t'-inventory delete <name>' deletes an item\n\t'-inventory [ name | description ] <name> <new value>' edits the name or description of an item" );
            }
            else
            {
                await ReplyAsync( $"{Context.User.Mention} you must have a character selected! Use -player select <name> to use this command!" );
            }
        }

        private Boolean hasItemWithName(string name)
        {
            foreach (Item item in Cooley.selectedCharacters[Context.User.ToString()].Inventory)
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

            foreach (Item item in Cooley.selectedCharacters[Context.User.ToString()].Inventory)
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
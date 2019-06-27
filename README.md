# Cooley
Cooley is a discord bot that manages Dungeon and Dragons character sheets inside the chat! Currently featuring 40 commands to edit, save, and use D&D edition 5 characters.

## Use
As of now I don't plan on hosting this bot full time, but you are more than welcome to use it. Feel free to clone the code and run it on your own servers, however you will have to make a top level file named `auth.json` with your own bots key in it. It should look something like this:

~~~~
{
  "Discord" : "Super Secret Authorization Code";
}
~~~~

## Pull Requests
Have your own ideas for Cooley? Feel free to support! Anyone is welcome to refactor pre-existing code or add their own command module. This was my Hello World project for learning C#, so I may not write much more of my own code, but I'll keep an eye on any pull requests that come my way.

## Commands
Here are the list of commands Cooley offers! If ever you get lost you can use `-help` in chat to see this same list!

* `-player new <name>` will make a new character for you. Default values are set, but everything is under your control.
* `-player list` will show all of your character in chat.
* `-player delete <name>` will delete any character you specify. **THIS COMMAND CAN'T BE UNDONE**
* `-player select <name>` will select any character you specify. You can't edit any character without first doing this step. Doing this command without a name will just tell you which character you've selected.

* `-name edit <name>` will change your selected character's name.
* `-name check` will show your selected character's name.

* `-inventory check` will show all items in your inventory.
* `-inventory add <name> - <description>` will add an item to your inventory.
* `-inventory delete <name>` will remove the first item in your inventory with <name>.
* `-inventory name <name> - <new name>` will change the name of the first item in your inventory with <name>.
* `-inventory description <name> - <new description>` will change the description of the first item in your inventory with <name>.

**`-feature` has all the same subcommands as `-inventory`**

* `-class check` will show your character's classes.
* `-class list` will show all classes.
* `-class add <class>` will add <class> to your character. This command takes the class string or it's number in `-class list`.
* `-class delete <class>` will remove <class> from your character.
  
* `-wallet check` will show your character's money
* `-wallet shorten` will put all your money into the biggest possible coins
* `-wallet <coin> <amount>` will set <coin> to <amount>. For example `-wallet gold 4` would give me 4 gold.

* `-xp check` displays experience points.
* `-xp set <number>` sets character's xp to <number>.
  
* `-alignment check` shows current alignment.
* `-alignment list` shows all alignments.
* `-alignment edit <alignment>` sets alignment to <alignment> from `-alignment list`.
  
* `-ac check` shows armor class.
* `-ac set <number>` sets armor class to <number>.
  
* `-health check` shows health stats.
* `-health edit [ current | temp | max ] <number>` will set current, temporary, and max hit points respectively.

* `-race check` to see current race.
* `-race list` to see all races.
* `-race edit <race>` to change current race. Replace <race> with name or number from `-race list`.
  
* `-[ age | eyes | hair | height | skin | weight ] check` will show the current value for the respective variable.
* `-[ age | eyes | hair | height | skin | weight ] set <value>` will change the current value for the respective variable. Most of those variable are just simple strings and can be set to anything you want.

* `proficiency check`shows proficiency bonus for character.
* `proficiency edit <number>` sets proficiency bonus to <number>.

Abilities are Strength, Charisma, Intelligence, Dexterity, Constitution, and Wisdom. Substitute one of those six values for [ability].
* `[ability] check` will show the current values for that ability.
* `[ability] edit <number>` will change the base value for the ability and update the skills associated with it.
* `[ability] proficient <true/false value>` will set whether or not you are proficient in the ability.

* `skill list` to see all skills.
* `skill <skill>` to see the value for that skill.

* `-roll [ 4 | 6 | 8 | 10 | 12 | 20 ]` will output a random number for any of the die in D&D

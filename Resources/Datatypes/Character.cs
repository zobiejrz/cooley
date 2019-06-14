using System;
using System.Collections.Generic;
using Discord.WebSocket;

namespace dnd_character_storage.Resources.Datatypes
{

  [Serializable]

    public class Character
    {
        public string Name            { get; set; }
        public string Owner           { get; set; }
        public Profession Professions { get; set; }
        public Races Race              { get; set; }
        public Alignment Alignment    { get; set; }
        public int MaxHP              { get; set; }
        public int TempHP             { get; set; }
        public int CurrentHP          { get; set; }
        public Abilities Abilities    { get; set; }
        public int ProfBonus          { get; set; }
        public Skills Skills          { get; set; }

        public void zero()
        {
            this.Professions = Profession.artificer;
            this.Race = Races.human;
            this.Alignment = Alignment.trueneutral;
            this.MaxHP = 0;
            this.TempHP = 0;
            this.CurrentHP = 0;
            this.Abilities.zero();
            this.ProfBonus = 0;
            this.Skills.zero();

        }
    }

    public class Abilities
    {

        SubAbility Strength;
        SubAbility Dexterity;
        SubAbility Constitution;
        SubAbility Intelligence;
        SubAbility Charisma;
        

        public void zero()
        {
            Strength.Base = 0;
            Strength.Modifier = 0;
            Strength.Saving = 0;
            Dexterity.Base = 0;
            Dexterity.Modifier = 0;
            Dexterity.Saving = 0;
            Constitution.Base = 0;
            Constitution.Modifier = 0;
            Constitution.Saving = 0;
            Intelligence.Base = 0;
            Intelligence.Modifier = 0;
            Intelligence.Saving = 0;
            Charisma.Base = 0;
            Charisma.Modifier = 0;
            Charisma.Saving = 0;
        }
    }

    public class SubAbility
    {
        public int Base { get; set; }
        public int Modifier { get; set; }
        public int Saving { get; set; }
    }

    public class Skills
    {
        public int acrobatics{ get; set; }        
        public int animalHandeling{ get; set; }
        public int arcana{ get; set; }
        public int athletics{ get; set; }
        public int deception{ get; set; }
        public int history{ get; set; }
        public int insight{ get; set; }
        public int intimidation{ get; set; }
        public int investigation{ get; set; }
        public int medicine{ get; set; }
        public int nature{ get; set; }
        public int perception{ get; set; }
        public int performance{ get; set; }
        public int persuasion{ get; set; }
        public int religion{ get; set; }
        public int sleightOfHand{ get; set; }
        public int stealth{ get; set; }
        public int survival{ get; set; } 

        public void zero()
        {
            this.acrobatics = 0;
            this.animalHandeling = 0;
            this.arcana = 0;
            this.athletics = 0;
            this.deception = 0;
            this.history = 0;
            this.insight = 0;
            this.intimidation = 0;
            this.investigation = 0;
            this.medicine = 0;
            this.nature = 0;
            this.perception = 0;
            this.performance = 0;
            this.persuasion = 0;
            this.religion = 0;
            this.sleightOfHand = 0;
            this.stealth = 0;
            this.survival = 0;
        }      
}

    public enum Profession
    {
        none = 0,
        barbarian,
        bard,
        cleric,
        druid,
        fighter,
        monk,
        paladin,
        ranger,
        rogue,
        sorceror,
        warlock,
        wizard,
        artificer
    }

    public enum Races
    {
        none = 0,
        dragonborn,
        dwarf,
        elf,
        gnome,
        halfelf,
        halfling,
        orc,
        halforc,
        human,
        tiefling,
        feraltiefling,
        aarakocra,
        airgenasi,
        earthgenasi,
        firegenasi,
        watergenasi,
        goliath,
        aasimar,
        bugbear,
        firbolg,
        goblin,
        hobgoblin,
        kenku,
        kobold,
        lizardfolk,
        tabaxi,
        triton,
        yuantipureblood,
        tortle,
        gith,
        changeling,
        kalashtar,
        beasthideshifter,
        longtoothshifter,
        swiftstrideshifter,
        wildhuntshifter,
        warforged,
        centaur,
        loxodon,
        minotaur,
        simichybrid,
        vedalken
    }

    public enum Alignment
    {
        lawfulgood = 0,
        lawfulneutral,
        lawfulevil,
        neutralgood,
        trueneutral,
        neutralevil,
        chaoticgood,
        chaoticneutral,
        chaoticevil
    }

}
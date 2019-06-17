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
        public string Serial          { get; set; }
        public Profession Professions { get; set; }
        public Races Race             { get; set; }
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

        SubAbility Strength         { get; set; }
        SubAbility Dexterity        { get; set; }
        SubAbility Constitution     { get; set; }
        SubAbility Intelligence     { get; set; }
        SubAbility Charisma         { get; set; }
        

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
        public int Base         { get; set; }
        public int Modifier     { get; set; }
        public int Saving       { get; set; }
    }

    public class Skills
    {
        public int Acrobatics       { get; set; }        
        public int AnimalHandeling  { get; set; }
        public int Arcana           { get; set; }
        public int Athletics        { get; set; }
        public int Deception        { get; set; }
        public int History          { get; set; }
        public int Insight          { get; set; }
        public int Intimidation     { get; set; }
        public int Investigation    { get; set; }
        public int Medicine         { get; set; }
        public int Nature           { get; set; }
        public int Perception       { get; set; }
        public int Performance      { get; set; }
        public int Persuasion       { get; set; }
        public int Religion         { get; set; }
        public int SleightOfHand    { get; set; }
        public int Stealth          { get; set; }
        public int Survival         { get; set; } 

        public void zero()
        {
            this.Acrobatics = 0;
            this.AnimalHandeling = 0;
            this.Arcana = 0;
            this.Athletics = 0;
            this.Deception = 0;
            this.History = 0;
            this.Insight = 0;
            this.Intimidation = 0;
            this.Investigation = 0;
            this.Medicine = 0;
            this.Nature = 0;
            this.Perception = 0;
            this.Performance = 0;
            this.Persuasion = 0;
            this.Religion = 0;
            this.SleightOfHand = 0;
            this.Stealth = 0;
            this.Survival = 0;
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
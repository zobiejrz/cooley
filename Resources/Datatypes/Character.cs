using System;
using System.Collections;
using System.Collections.Generic;

namespace dnd_character_storage.Resources.Datatypes
{

  [Serializable]
    public class Character
    {
        public string Name                              { get; set; }
        public string Owner                             { get; set; }
        public string Serial                            { get; set; }
        public int Age                                  { get; set; }
        public string Height                            { get; set; }
        public string Weight                            { get; set; }
        public string EyeColor                          { get; set; }
        public string SkinColor                         { get; set; }
        public string HairColor                         { get; set; }
        public int XP                                   { get; set; }
        public Dictionary<Professions, int> Profession  { get; set; }
        public Races Race                               { get; set; }
        public Alignments Alignment                     { get; set; }
        public int MaxHP                                { get; set; }
        public int TempHP                               { get; set; }
        public int CurrentHP                            { get; set; }
        public Abilities Abilities                      { get; set; }
        public int ProfBonus                            { get; set; }
        public Skills Skills                            { get; set; }
        public int ArmorClass                           { get; set; }
        public int SpellSlots                           { get; set; }
        public Wallet Purse                             { get; set; }
        public List<Item> Inventory                     { get; set; }
        public List<Item> Features                      { get; set; }

        public void zero()
        {
            this.Profession.Clear();
            this.Profession.Add(Professions.barbarian, 0);

            this.Race = Races.human;
            this.Alignment = Alignments.trueneutral;
            this.MaxHP = 0;
            this.TempHP = 0;
            this.CurrentHP = 0;
            this.Abilities.zero();
            this.ProfBonus = 0;
            this.UpdateSkills();
            this.XP = 0;

            Inventory.Clear();
            Features.Clear();
        }

        public string getRace()
        {
            string value = "";
            switch ( Race )
            {
                case Races.dragonborn:
                    value = "dragonborn";
                    break;
                case Races.dwarf:
                    value = "dwarf";
                    break;
                case Races.elf:
                    value = "elf";
                    break;
                case Races.gnome:
                    value = "gnome";
                    break;
                case Races.halfelf:
                    value = "half-elf";
                    break;
                case Races.halfling:
                    value = "halfling";
                    break;
                case Races.orc:
                    value = "orc";
                    break;
                case Races.halforc:
                    value = "half-orc";
                    break;
                case Races.human:
                    value = "human";
                    break;
                case Races.tiefling:
                    value = "tiefling";
                    break;
                case Races.feraltiefling:
                    value = "feral tiefling";
                    break;
                case Races.aarakocra:
                    value = "aarakocra";
                    break;
                case Races.airgenasi:
                    value = "air genasi";
                    break;
                case Races.earthgenasi:
                    value = "earth genasi";
                    break;
                case Races.firegenasi:
                    value = "fire genasi";
                    break;
                case Races.watergenasi:
                    value = "water genasi";
                    break;
                case Races.goliath:
                    value = "goliath";
                    break;
                case Races.aasimar:
                    value = "aasimar";
                    break;
                case Races.bugbear:
                    value = "bugbear";
                    break;
                case Races.firbolg:
                    value = "firbolg";
                    break;
                case Races.goblin:
                    value = "goblin";
                    break;
                case Races.hobgoblin:
                    value = "hobgoblin";
                    break;
                case Races.kenku:
                    value = "kenku";
                    break;
                case Races.kobold:
                    value = "kobold";
                    break;
                case Races.lizardfolk:
                    value = "lizardfolk";
                    break;
                case Races.tabaxi:
                    value = "tabaxi";
                    break;
                case Races.triton:
                    value = "triton";
                    break;
                case Races.yuantipureblood:
                    value = "yuanti pureblood";
                    break;
                case Races.tortle:
                    value = "tortle";
                    break;
                case Races.gith:
                    value = "gith";
                    break;
                case Races.changeling:
                    value = "changeling";
                    break;
                case Races.kalashtar:
                    value = "kalashtar";
                    break;
                case Races.beasthideshifter:
                    value = "beasthide shifter";
                    break;
                case Races.longtoothshifter:
                    value = "longtooth shifter";
                    break;
                case Races.swiftstrideshifter:
                    value = "swiftstride shifter";
                    break;
                case Races.wildhuntshifter:
                    value = "wildhunt shifter";
                    break;
                case Races.warforged:
                    value = "warforged";
                    break;
                case Races.centaur:
                    value = "centaur";
                    break;
                case Races.loxodon:
                    value = "loxodon";
                    break;
                case Races.minotaur:
                    value = "minotaur";
                    break;
                case Races.simichybrid:
                    value = "simichybrid";
                    break;
                case Races.vedalken:
                    value = "vedalken";
                    break;
            }
            return value;
        }
        public string getAlignment()
        {
            string value = "";
            switch ( Alignment )
            {
                case Alignments.lawfulgood:
                    value = "lawful good";
                    break;
                case Alignments.lawfulneutral:
                    value = "lawful neutral";
                    break;
                case Alignments.lawfulevil:
                    value = "lawful evil";
                    break;
                case Alignments.neutralgood:
                    value = "neutral good";
                    break;
                case Alignments.trueneutral:
                    value = "true neutral";
                    break;
                case Alignments.neutralevil:
                    value = "neutral evil";
                    break;
                case Alignments.chaoticgood:
                    value = "chaotic good";
                    break;
                case Alignments.chaoticneutral:
                    value = "chaotic neutral";
                    break;
                case Alignments.chaoticevil:
                    value = "chaotic evil";
                    break;
            }
            return value;
        }
        public void UpdateSkills()
        {
            if ( this.Abilities.Dexterity.isProficient )
            {
                this.Skills.Acrobatics = this.Abilities.Dexterity.Modifier + this.ProfBonus;
                this.Skills.SleightOfHand = this.Abilities.Dexterity.Modifier + this.ProfBonus;
                this.Skills.Stealth = this.Abilities.Dexterity.Modifier + this.ProfBonus;
            }
            else
            {
                this.Skills.Acrobatics = this.Abilities.Dexterity.Modifier;
                this.Skills.SleightOfHand = this.Abilities.Dexterity.Modifier;
                this.Skills.Stealth = this.Abilities.Dexterity.Modifier;
            }
            
            if ( this.Abilities.Wisdom.isProficient )
            {
                this.Skills.AnimalHandeling = this.Abilities.Wisdom.Modifier + this.ProfBonus;
                this.Skills.Perception = this.Abilities.Wisdom.Modifier + this.ProfBonus;
                this.Skills.Survival = this.Abilities.Wisdom.Modifier + this.ProfBonus;
                this.Skills.Medicine = this.Abilities.Wisdom.Modifier + this.ProfBonus;
                this.Skills.Insight = this.Abilities.Wisdom.Modifier + this.ProfBonus;
            }
            else
            {
                this.Skills.AnimalHandeling = this.Abilities.Wisdom.Modifier;
                this.Skills.Perception = this.Abilities.Wisdom.Modifier;
                this.Skills.Survival = this.Abilities.Wisdom.Modifier;
                this.Skills.Medicine = this.Abilities.Wisdom.Modifier;
                this.Skills.Insight = this.Abilities.Wisdom.Modifier;
            }
            
            if ( this.Abilities.Intelligence.isProficient )
            {
                this.Skills.Arcana = this.Abilities.Intelligence.Modifier + this.ProfBonus;
                this.Skills.History = this.Abilities.Intelligence.Modifier + this.ProfBonus;
                this.Skills.Investigation = this.Abilities.Intelligence.Modifier + this.ProfBonus;
                this.Skills.Nature = this.Abilities.Intelligence.Modifier + this.ProfBonus;
                this.Skills.Religion = this.Abilities.Intelligence.Modifier + this.ProfBonus;
            }
            else
            {
                this.Skills.Arcana = this.Abilities.Intelligence.Modifier;
                this.Skills.History = this.Abilities.Intelligence.Modifier;
                this.Skills.Investigation = this.Abilities.Intelligence.Modifier;
                this.Skills.Nature = this.Abilities.Intelligence.Modifier;
                this.Skills.Religion = this.Abilities.Intelligence.Modifier;
            }

            if ( this.Abilities.Strength.isProficient )
            {
                this.Skills.Athletics = this.Abilities.Strength.Modifier + this.ProfBonus;
            }
            else
            {
                this.Skills.Athletics = this.Abilities.Strength.Modifier;
            }

            if ( this.Abilities.Charisma.isProficient )
            {
                this.Skills.Deception = this.Abilities.Charisma.Modifier + this.ProfBonus;
                this.Skills.Intimidation = this.Abilities.Charisma.Modifier + this.ProfBonus;
                this.Skills.Performance = this.Abilities.Charisma.Modifier + this.ProfBonus;
                this.Skills.Persuasion = this.Abilities.Charisma.Modifier + this.ProfBonus;
            }
            else
            {
                this.Skills.Deception = this.Abilities.Charisma.Modifier;
                this.Skills.Intimidation = this.Abilities.Charisma.Modifier;
                this.Skills.Performance = this.Abilities.Charisma.Modifier;
                this.Skills.Persuasion = this.Abilities.Charisma.Modifier;
            }
            
        } 
    }
    public class Wallet
    {
        public int Copper       { get; set; }
        public int Silver       { get; set; }
        public int Electrum     { get; set; }
        public int Gold         { get; set; }
        public int Platinum     { get; set; }
        
        public void Consolidate()
        {
            while ( Copper >= 100 )
            {
                Copper -= 100;
                Silver += 1;
            }

            while ( Silver >= 100 )
            {
                Silver -= 100;
                Electrum += 1;
            }
            
            while ( Electrum >= 100 )
            {
                Electrum -= 100;
                Gold += 1;
            }

            while ( Gold >= 100 )
            {
                Gold -= 100;
                Platinum += 1;
            }
        }
    }
    public class Abilities
    {

        public SubAbility Strength         { get; set; }
        public SubAbility Dexterity        { get; set; }
        public SubAbility Constitution     { get; set; }
        public SubAbility Intelligence     { get; set; }
        public SubAbility Wisdom           { get; set; }
        public SubAbility Charisma         { get; set; }
        

        public void zero()
        {
            Strength.Base = 0;
            Strength.Modifier = 0;

            Dexterity.Base = 0;
            Dexterity.Modifier = 0;

            Constitution.Base = 0;
            Constitution.Modifier = 0;

            Intelligence.Base = 0;
            Intelligence.Modifier = 0;
            
            Charisma.Base = 0;
            Charisma.Modifier = 0;
        }
    }
    public class SubAbility
    {
        public int Base             { get; set; }
        public int Modifier         { get; set; }
        public Boolean isProficient { get; set; }
        public void UpdateModifier()
        {
            if ( Base <= 1 )
            {
                Modifier = -5;
            }
            else if ( Base <= 3 )
            {
                Modifier = -4;
            }
            else if ( Base <= 5 )
            {
                Modifier = -3;
            }
            else if ( Base <= 7 )
            {
                Modifier = -2;
            }
            else if ( Base <= 9 )
            {
                Modifier = -1;
            }
            else if ( Base <= 11 )
            {
                Modifier = 0;
            }
            else if ( Base <= 13 )
            {
                Modifier = 1;
            }
            else if ( Base <= 15 )
            {
                Modifier = 2;
            }
            else if ( Base <= 17 )
            {
                Modifier = 3;
            }
            else if ( Base <= 19 )
            {
                Modifier = 4;
            }
            else if ( Base <= 21 )
            {
                Modifier = 5;
            }
            else if ( Base <= 23 )
            {
                Modifier = 6;
            }
            else if ( Base <= 25 )
            {
                Modifier = 7;
            }
            else if ( Base <= 27 )
            {
                Modifier = 8;
            }
            else if ( Base <= 29 )
            {
                Modifier = 9;
            }
            else
            {
                Modifier = 10;
            }
        }

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
    }

    public enum Professions
    {
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

    public enum Alignments
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
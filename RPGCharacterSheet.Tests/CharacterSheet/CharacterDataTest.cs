using RPGCharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterSheet.Tests.CharacterSheet
{
    public class CharacterDataTest
    {
        [Fact]
        public void Updating_Ability_Score_Updates_Skill_Modifiers()
        {
            CharacterData character = generateCharater();

            Assert.Equal(0, character.GetSkill("Acrobatics")?.Modifier);

            character.GetAbilityScore("Dexterity").Score = 18;

            Assert.Equal(4, character.GetSkill("Acrobatics").Modifier);
            Assert.Equal(0, character.GetSkill("Perception")?.Modifier);
        }

        [Fact]
        public void Update_Proficieny_Updates_Proficient_Skills()
        {
            CharacterData character = generateCharater();

            Assert.Equal(0, character.GetSkill("Perception")?.Modifier);

            character.ProficiencyBonus.Modifier = 3;
            character.GetSkill("Perception").Proficient = true;

            Assert.Equal(3, character.GetSkill("Perception")?.Modifier);

            character.ProficiencyBonus.Modifier = 5;

            Assert.Equal(5, character.GetSkill("Perception")?.Modifier);

            character.GetSkill("Perception").Proficient = false;

            Assert.Equal(0, character.GetSkill("Perception")?.Modifier);
        }

        [Fact]
        public void Expert_Cannot_Be_True_If_Not_Proficient()
        {
            CharacterData character = generateCharater();
            Assert.False(character.GetSkill("Performance").Expert);

            character.GetSkill("Performance").Expert = true;

            Assert.False(character.GetSkill("Performance").Expert);

            character.GetSkill("Performance").Proficient = true;
            character.GetSkill("Performance").Expert = true;

            Assert.True(character.GetSkill("Performance").Expert);
        }

        [Fact]
        public void Setting_Expert_Doubles_Proficiency_Bonus()
        {
            CharacterData character = generateCharater();
            character.ProficiencyBonus.Modifier = 3;

            character.GetSkill("Performance").Proficient = true;
            character.GetSkill("Performance").Expert = true;

            Assert.Equal(6, character.GetSkill("Performance").Modifier);
        }

        [Theory]
        [InlineData("Perception", 18, 4, true, false, 18)]
        [InlineData("Insight", 14, 5, true, true, 22)]
        [InlineData("Investigation", 7, 5, false, false, 8)]
        public void Passive_Score_For_Skill_Calculated_Based_On_Modifiers(string skill, int abilityScore, int proficiencyBonus, bool proficient, bool expert, int expectedScore)
        {
            CharacterData character = generateCharater();
            character.ProficiencyBonus.Modifier = proficiencyBonus;
            Skill skillToTest = character.GetSkill(skill);
            skillToTest.BaseAbilityScore.Score = abilityScore;
            skillToTest.Proficient = proficient;
            skillToTest.Expert = expert;

            Assert.Equal(expectedScore, skillToTest.PassiveScore);

        }

        private CharacterData generateCharater()
        {
            CharacterData character = new()
            {
                CharacterName = "Charles Lorrance",
                Class = "Fighter"
            };

            AbilityScore _dex = new() { Name = "Dexterity", Score = 10 };
            AbilityScore _int = new() { Name = "Intelligence", Score = 10 };
            AbilityScore _wis = new() { Name = "Wisdom", Score = 10 };
            AbilityScore _cha = new() { Name = "Charisma", Score = 10 };

            Skill _dexsav = new() { Name = "Dexterity", BaseAbilityScore = _dex, ProficiencyModifier = character.ProficiencyBonus };
            Skill _intsav = new() { Name = "Intelligence", BaseAbilityScore = _int, ProficiencyModifier = character.ProficiencyBonus };
            Skill _wissav = new() { Name = "Wisdom", BaseAbilityScore = _wis, ProficiencyModifier = character.ProficiencyBonus };
            Skill _chasav = new() { Name = "Charisma", BaseAbilityScore = _cha, ProficiencyModifier = character.ProficiencyBonus };

            Skill _acro = new() { Name = "Acrobatics", BaseAbilityScore = _dex, ProficiencyModifier = character.ProficiencyBonus };
            Skill _perc = new() { Name = "Perception", BaseAbilityScore = _wis, ProficiencyModifier = character.ProficiencyBonus };
            Skill _perf = new() { Name = "Performance", BaseAbilityScore = _cha, ProficiencyModifier = character.ProficiencyBonus };
            Skill _inst = new() { Name = "Insight", BaseAbilityScore = _wis, ProficiencyModifier = character.ProficiencyBonus };
            Skill _invt = new() { Name = "Investigation", BaseAbilityScore = _int, ProficiencyModifier = character.ProficiencyBonus };
            


            character.AbilityScores.AddRange(new List<AbilityScore> { _dex, _int, _wis, _cha });
            character.SavingThrows.AddRange(new List<Skill> { _dexsav, _intsav, _wissav, _chasav });
            character.SkillChecks.AddRange(new List<Skill> { _acro, _perc, _perf, _inst, _invt });

            return character;
        }
    }
}

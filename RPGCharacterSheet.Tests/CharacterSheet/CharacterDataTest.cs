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

        private CharacterData generateCharater()
        {
            CharacterData character = new()
            {
                CharacterName = "Charles Lorrance",
                Class = "Fighter"
            };

            AbilityScore _dex = new() { Name = "Dexterity", Score = 10 };
            AbilityScore _wis = new() { Name = "Wisdom", Score = 10 };
            AbilityScore _cha = new() { Name = "Charisma", Score = 10 };

            Skill _dexsav = new() { Name = "Dexterity", BaseAbilityScore = _dex, ProficiencyModifier = character.ProficiencyBonus };
            Skill _wissav = new() { Name = "Wisdom", BaseAbilityScore = _wis, ProficiencyModifier = character.ProficiencyBonus };
            Skill _chasav = new() { Name = "Charisma", BaseAbilityScore = _cha, ProficiencyModifier = character.ProficiencyBonus };

            Skill _acro = new() { Name = "Acrobatics", BaseAbilityScore = _dex, ProficiencyModifier = character.ProficiencyBonus };
            Skill _perc = new() { Name = "Perception", BaseAbilityScore = _wis, ProficiencyModifier = character.ProficiencyBonus };
            Skill _perf = new() { Name = "Performance", BaseAbilityScore = _cha, ProficiencyModifier = character.ProficiencyBonus };


            character.AbilityScores.AddRange(new List<AbilityScore> { _dex, _wis, _cha });
            character.SavingThrows.AddRange(new List<Skill> { _dexsav, _wissav, _chasav });
            character.SkillChecks.AddRange(new List<Skill> { _acro, _perc, _perf });

            return character;
        }
    }
}

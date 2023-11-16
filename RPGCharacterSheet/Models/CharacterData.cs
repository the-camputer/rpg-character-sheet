using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterSheet.Models
{
    public class CharacterData
    {
        public string CharacterName { get; set; }
        public string Alignment { get; set; }
        public string PlayerName { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Background { get; set; }
        public string Homeland { get; set; }
        public string Ancestry { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Skin { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public int ExperiencePoints { get; set; }
        public List<AbilityScore> AbilityScores { get; set; }
        public List<Skill> SavingThrows { get; set; }
        public List<Skill> SkillChecks { get; set; }
        public Skill ProficiencyBonus { get; set; }
        public bool Inspiration { get; set; }
        public int ArmorClass { get; set; }
        public int Initiative { get; set; }
        public int Speed { get; set; }
        public int HitPointMax { get; set; }
        public int HitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }
        public int HitDiceCount { get; set; }
        public string HitDiceType { get; set; }
        public int DeathSaveSuccesses { get; set; }
        public int DeathSaveFailures {  get; set; }
        public string Personality { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }

        public CharacterData() 
        {
            Level = 1;
            Age = 1;
            ExperiencePoints = 0;
            AbilityScores = new List<AbilityScore>();
            SavingThrows = new List<Skill>();
            SkillChecks = new List<Skill>();
            ProficiencyBonus = new Skill { Name = "Proficiency", Modifier = 0 };
        }

        public AbilityScore GetAbilityScore(string scoreName)
        {
            return AbilityScores.Find(score => score.Name == scoreName);
        }

        public Skill GetSkill(string skillName)
        {
            return SkillChecks.Find(skill => skill.Name == skillName);
        }

        public Skill GetSavingThrow(string savingThrowName)
        {
            return SavingThrows.Find(sav => sav.Name == savingThrowName);
        }
    }
}

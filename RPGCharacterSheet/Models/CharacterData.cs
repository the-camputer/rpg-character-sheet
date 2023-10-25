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
        public string Gender {  get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Skin { get; set; }
        public string Hair { get; set; }
        public string Eyes {  get; set; }
        public int ExperiencePoints { get; set; }

        public List<AbilityScore> AbilityScores { get; set; }
        
        public List<Skill> SavingThrows { get; set; }
        public CharacterData() 
        {
            Level = 1;
            Age = 1;
            ExperiencePoints = 0;
            AbilityScores = new List<AbilityScore>();
            SavingThrows = new List<Skill>();
        }
    }
}

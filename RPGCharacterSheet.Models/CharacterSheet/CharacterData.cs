using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterSheet.Models.CharacterSheet
{
    public class CharacterData
    {
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Background { get; set; }
        public string PlayerName { get; set; }
        public string Ancestry { get; set; }
        public string Alignment { get; set; }
        public int ExperiencePoints { get; set; }
        public CharacterData() { }
    }
}

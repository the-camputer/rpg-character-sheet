using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Character_Sheet.Models
{
    public class CharacterData
    {
        public String CharacterName {  get; set; }
        public String Class {  get; set; }
        public int Level {  get; set; }
        public String Background { get; set; }
        public String PlayerName { get; set; }
        public String Ancestry { get; set; }
        public String Alignment { get; set; }
        public int ExperiencePoints { get; set; }
        public CharacterData() { }
    }
}

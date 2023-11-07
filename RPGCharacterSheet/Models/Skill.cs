using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RPGCharacterSheet.Models
{
    public class Skill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }


        private AbilityScore _baseAbilityScore;
        public AbilityScore BaseAbilityScore
        {
            get => _baseAbilityScore;
            set
            {
                if (_baseAbilityScore != null)
                {
                    _baseAbilityScore.PropertyChanged -= AbilityScoreModifierChanged;
                }
                _baseAbilityScore = value;
                _baseAbilityScore.PropertyChanged += AbilityScoreModifierChanged;
                Modifier = CalculateModifier();
            }
        }

        private Skill _proficiencyModifier;
        public Skill ProficiencyModifier
        {
            get => _proficiencyModifier;
            set
            {
                if (_proficiencyModifier != null)
                {
                    _proficiencyModifier.PropertyChanged -= ProficiencyModifierChanged;
                }
                _proficiencyModifier = value;
                _proficiencyModifier.PropertyChanged += ProficiencyModifierChanged;
                Modifier = CalculateModifier();
            }
        }

        private int _modifier;
        public int Modifier
        {
            get => _modifier;
            set
            {
                _modifier = value;
                OnPropertyChanged(nameof(Modifier));
            }
        }

        private bool _proficient;
        public bool Proficient
        {
            get => _proficient;
            set
            {
                _proficient = value;
                if (!_proficient)
                {
                    Expert = false;
                }
                Modifier = CalculateModifier();
                OnPropertyChanged(nameof(Proficient));
            }
        }

        private bool _expert;
        public bool Expert
        {
            get => _expert;
            set
            {
                if (Proficient)
                {
                    _expert = value;
                }
                else
                {
                    _expert = false;
                }
                Modifier = CalculateModifier();
                OnPropertyChanged(nameof(Expert));
                OnPropertyChanged(nameof(Modifier));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AbilityScoreModifierChanged(object sender, PropertyChangedEventArgs a)
        {
            if (a.PropertyName == "Modifier")
            {
                this.Modifier = CalculateModifier();
            }
        }

        public void ProficiencyModifierChanged(object sender, PropertyChangedEventArgs a)
        {
            if (a.PropertyName == "Modifier" && this.Proficient)
            {
                this.Modifier = CalculateModifier();
            }
        }

        private int CalculateModifier()
        {
            int result = BaseAbilityScore.Modifier;

            if (Proficient && ProficiencyModifier != null)
            {
                if (Expert)
                {
                    result += ProficiencyModifier.Modifier * 2;
                }
                else
                {
                    result += ProficiencyModifier.Modifier;
                }
            }

            return result;
        }
    }
}

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
                Modifier = _baseAbilityScore.Modifier;
            }
        }

        private void _baseAbilityScore_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AbilityScoreModifierChanged(object sender, PropertyChangedEventArgs a)
        {
            if (a.PropertyName == "Modifier")
            {
                this.Modifier = (sender as AbilityScore).Modifier;
            }
        }
    }
}

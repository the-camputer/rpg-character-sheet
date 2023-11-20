using System.ComponentModel;

namespace RPGCharacterSheet.Models
{
    public class ProficiencyBonus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _modifier;
        public int Modifier {
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
    }
}

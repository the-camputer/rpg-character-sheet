using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RPGCharacterSheet.Models.CharacterSheet
{
    public class CharacterSheetViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<string> _alignments;
        public ObservableCollection<string> Alignments { get { return _alignments; } }

        private CharacterData _characterData;

        public string CharacterName
        {
            get => _characterData.CharacterName;
            set
            {
                _characterData.CharacterName = value;
                OnPropertyChanged(nameof(CharacterName));
            }
        }

        public string Alignment
        {
            get => _characterData.Alignment;
            set
            {
                _characterData.Alignment = value;
                OnPropertyChanged(nameof(Alignment));
            }
        }

        public string PlayerName
        {
            get => _characterData.PlayerName;
            set
            {
                _characterData.PlayerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public CharacterSheetViewModel() 
        {
            _characterData = new CharacterData();
            setUp();
        }

        public CharacterSheetViewModel(CharacterData characterData)
        {
            _characterData = characterData;
            setUp();
        }

        private void setUp()
        {
            _alignments = new ObservableCollection<string>()
            {
                "LG",
                "NG",
                "CG",
                "LN",
                "N",
                "CN",
                "LE",
                "NE",
                "CE"
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.WriteLine($"{propertyName}, {this.GetType().GetProperty(propertyName).GetValue(this)}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

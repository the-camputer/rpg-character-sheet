using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using RPGCharacterSheet.Models;

namespace RPGCharacterSheet.ViewModels
{
    public class CharacterSheetViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<string> _alignments;
        public ObservableCollection<string> Alignments { get { return _alignments; } }

        private CharacterData _characterData;

        #region ChangeableProperties
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

        public string Class
        {
            get => _characterData.Class;
            set
            {
                _characterData.Class = value;
                OnPropertyChanged(nameof(Class));
            }
        }

        public int Level
        {
            get => _characterData.Level;
            set
            {
                // TODO: Add validation.
                _characterData.Level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public string Background
        {
            get => _characterData.Background;
            set
            {
                _characterData.Background = value;
                OnPropertyChanged(nameof(Background));
            }
        }

        public string Homeland
        {
            get => _characterData.Homeland;
            set
            {
                _characterData.Homeland = value;
                OnPropertyChanged(nameof(Homeland));
            }
        }

        public string Ancestry
        {
            get => _characterData.Ancestry;
            set
            {
                _characterData.Ancestry = value;
                OnPropertyChanged(nameof(Ancestry));
            }
        }

        public string Gender
        {
            get => _characterData.Gender;
            set
            {
                _characterData.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public int Age
        {
            get => _characterData.Age;
            set
            {
                _characterData.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Height
        {
            get => _characterData.Height;
            set
            { 
                _characterData.Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Weight
        {
            get => _characterData.Weight;
            set
            {
                _characterData.Weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public string Skin
        {
            get => _characterData.Skin;
            set
            {
                _characterData.Skin = value;
                OnPropertyChanged(nameof(Skin));
            }
        }

        public string Hair
        {
            get => _characterData.Hair;
            set
            {
                _characterData.Hair = value;
                OnPropertyChanged(nameof(Hair));
            }
        }

        public string Eyes
        {
            get => _characterData.Eyes;
            set
            {
                _characterData.Eyes = value;
                OnPropertyChanged(nameof(Eyes));
            }
        }

        public int ExperiencePoints
        {
            get => _characterData.ExperiencePoints;
            set
            {
                _characterData.ExperiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }

        private ObservableCollection<AbilityScore> _abilityScores;
        public ObservableCollection<AbilityScore> AbilityScores { get { return _abilityScores; } }

        private ObservableCollection<Skill> _savingThrows;
        public ObservableCollection<Skill> SavingThrows { get { return _savingThrows; } }
        #endregion

        public CharacterSheetViewModel()
        {
            _characterData = new CharacterData();
            SetUp();
        }

        public CharacterSheetViewModel(CharacterData characterData)
        {
            _characterData = characterData;
            SetUp();
        }

        private void SetUp()
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

            AbilityScore _str = new AbilityScore { Name = "Strength" };
            AbilityScore _dex = new AbilityScore { Name = "Dexterity" };
            AbilityScore _con = new AbilityScore { Name = "Constitution" };
            AbilityScore _int = new AbilityScore { Name = "Intelligence" };
            AbilityScore _wis = new AbilityScore { Name = "Wisdom" };
            AbilityScore _cha = new AbilityScore { Name = "Charisma" };


            _characterData.AbilityScores.AddRange(new List<AbilityScore> { _str, _dex, _con, _int, _wis, _cha });
            _abilityScores = new ObservableCollection<AbilityScore>(_characterData.AbilityScores);

            Skill saveStr = new Skill { Name = _str.Name, BaseAbilityScore = _str };
            Skill saveDex = new Skill { Name = _dex.Name, BaseAbilityScore = _dex };
            Skill saveCon = new Skill { Name = _con.Name, BaseAbilityScore = _con };
            Skill saveInt = new Skill { Name = _int.Name, BaseAbilityScore = _int };
            Skill saveWis = new Skill { Name = _wis.Name, BaseAbilityScore = _wis };
            Skill saveCha = new Skill { Name = _cha.Name, BaseAbilityScore = _cha };
            _characterData.SavingThrows.AddRange(new List<Skill> { saveStr, saveDex, saveCon, saveInt, saveWis, saveCha });
            _savingThrows = new ObservableCollection<Skill>(_characterData.SavingThrows);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            System.Diagnostics.Debug.WriteLine($"{propertyName}, {GetType().GetProperty(propertyName).GetValue(this)}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

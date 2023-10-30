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

        private ObservableCollection<Skill> _skillChecks;
        public ObservableCollection<Skill> SkillChecks {  get { return _skillChecks; } }
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

            AbilityScore _str = new AbilityScore { Name = "Strength", Score = 10 };
            AbilityScore _dex = new AbilityScore { Name = "Dexterity", Score = 10 };
            AbilityScore _con = new AbilityScore { Name = "Constitution", Score = 10 };
            AbilityScore _int = new AbilityScore { Name = "Intelligence", Score = 10 };
            AbilityScore _wis = new AbilityScore { Name = "Wisdom", Score = 10 };
            AbilityScore _cha = new AbilityScore { Name = "Charisma", Score = 10 };


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

            Skill acrobatics = new Skill { Name = "Acrobatics", BaseAbilityScore = _dex };
            Skill animalHandling = new Skill { Name = "Animal Handling", BaseAbilityScore = _wis };
            Skill arcana = new Skill { Name = "Arcana", BaseAbilityScore = _int };
            Skill athletics = new Skill { Name = "Athletics", BaseAbilityScore = _str };
            Skill deception = new Skill { Name = "Deception", BaseAbilityScore = _cha };
            Skill history = new Skill { Name = "History", BaseAbilityScore = _int };
            Skill insight = new Skill { Name = "Insight", BaseAbilityScore = _wis };
            Skill intimidation = new Skill { Name = "Intimidation", BaseAbilityScore = _cha };
            Skill investigation = new Skill { Name = "Investigation", BaseAbilityScore = _int };
            Skill medicine = new Skill { Name = "Medicine", BaseAbilityScore = _wis };
            Skill nature = new Skill { Name = "Nature", BaseAbilityScore = _int };
            Skill perception = new Skill { Name = "Perception", BaseAbilityScore = _wis };
            Skill performance = new Skill { Name = "Performance", BaseAbilityScore = _cha };
            Skill persuation = new Skill { Name = "Persuation", BaseAbilityScore = _cha };
            Skill religion = new Skill { Name = "Religion", BaseAbilityScore = _int };
            Skill slightOfHand = new Skill { Name = "Sleight of Hand", BaseAbilityScore = _dex };
            Skill stealth = new Skill { Name = "Stealth", BaseAbilityScore = _dex };
            Skill survival = new Skill { Name = "Survival", BaseAbilityScore = _wis };
            _characterData.SkillChecks.AddRange(new List<Skill> 
            { 
                acrobatics, 
                animalHandling,
                arcana,
                athletics,
                deception,
                history,
                insight,
                intimidation,
                investigation,
                medicine,
                nature,
                perception,
                performance,
                persuation,
                religion,
                slightOfHand,
                stealth,
                survival
            });
            _skillChecks = new ObservableCollection<Skill>(_characterData.SkillChecks);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

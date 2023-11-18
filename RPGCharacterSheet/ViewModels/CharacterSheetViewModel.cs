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
        public ObservableCollection<string> Alignments { get => _alignments; }

        ObservableCollection<string> _hitDiceTypes;
        public ObservableCollection<string> HitDiceTypes { get => _hitDiceTypes; }

        private readonly CharacterData _characterData;
        public CharacterData CharacterData { get => _characterData; }

        private ObservableCollection<AbilityScore> _abilityScores;
        public ObservableCollection<AbilityScore> AbilityScores { get => _abilityScores; }

        private ObservableCollection<Skill> _savingThrows;
        public ObservableCollection<Skill> SavingThrows { get => _savingThrows; }

        private ObservableCollection<Skill> _skillChecks;
        public ObservableCollection<Skill> SkillChecks { get => _skillChecks; }

        private ObservableCollection<Skill> _passiveSkills;
        public ObservableCollection<Skill> PassiveSkills { get => _passiveSkills; }

        private ObservableCollection<Attack> _attacks;
        public ObservableCollection<Attack> Attacks { get => _attacks; }

        #region ChangeableProperties
        private Skill _selectedPassiveSkill;
        public Skill SelectedPassiveSkill
        {
            get => _selectedPassiveSkill;
            set
            {
               _selectedPassiveSkill = value;
                OnPropertyChanged(nameof(SelectedPassiveSkill));
            }
        }

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

        public int Proficiency
        {
            get => _characterData.ProficiencyBonus.Modifier;
            set
            {
                _characterData.ProficiencyBonus.Modifier = value;
                OnPropertyChanged(nameof(Proficiency));
            }
        }

        public bool Inspiration
        {
            get => _characterData.Inspiration;
            set
            {
                _characterData.Inspiration = value;
                OnPropertyChanged(nameof(Inspiration));
            }
        }

        public int ArmorClass
        {
            get => _characterData.ArmorClass;
            set
            {
                _characterData.ArmorClass = value;
                OnPropertyChanged(nameof(ArmorClass));
            }
        }

        public int Initiative
        {
            get => _characterData.Initiative;
            set
            {
                _characterData.Initiative = value;
                OnPropertyChanged(nameof(Initiative));
            }
        }

        public int Speed
        {
            get => _characterData.Speed;
            set
            {
                _characterData.Speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        public int HitPointMax
        {
            get => _characterData.HitPointMax;
            set
            {
                _characterData.HitPointMax = value;
                OnPropertyChanged(nameof(HitPointMax));
            }
        }

        public int HitPoints
        {
            get => _characterData.HitPoints;
            set
            {
                _characterData.HitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int TemporaryHitPoints
        {
            get => _characterData.TemporaryHitPoints;
            set
            {
                _characterData.TemporaryHitPoints = value;
                OnPropertyChanged(nameof(TemporaryHitPoints));
            }
        }

        public int HitDiceCount
        {
            get => _characterData.HitDiceCount;
            set
            {
                _characterData.HitDiceCount = value;
                OnPropertyChanged(nameof(HitDiceCount));
            }
        }

        public string HitDiceType
        {
            get => _characterData.HitDiceType;
            set
            {
                _characterData.HitDiceType = value;
                OnPropertyChanged(nameof(HitDiceType));
            }
        }

        public int DeathSaveSuccesses
        {
            get => _characterData.DeathSaveSuccesses;
            set
            {
                _characterData.DeathSaveSuccesses = value;
                OnPropertyChanged(nameof(DeathSaveSuccesses));
            }
        }

        public int DeathSaveFailures
        {
            get => _characterData.DeathSaveFailures;
            set
            {
                _characterData.DeathSaveFailures = value;
                OnPropertyChanged(nameof(DeathSaveFailures));
            }
        }

        public string Personality
        {
            get => _characterData.Personality;
            set
            {
                _characterData.Personality = value;
                OnPropertyChanged(nameof(Personality));
            }
        }

        public string Ideals
        {
            get => _characterData.Ideals;
            set
            {
                _characterData.Ideals = value;
                OnPropertyChanged(nameof(Ideals));
            }
        }

        public string Bonds
        {
            get => _characterData.Bonds;
            set
            {
                _characterData.Bonds = value;
                OnPropertyChanged(nameof(Bonds));
            }
        }

        public string Flaws
        {
            get => _characterData.Flaws;
            set
            {
                _characterData.Flaws = value;
                OnPropertyChanged(nameof(Flaws));
            }
        }

        public List<Coin> Coins
        {
            get => _characterData.Coins;
            set
            {
                _characterData.Coins = value;
                OnPropertyChanged(nameof(Coins));
            }
        }

        public string Equipment
        {
            get => _characterData.Equipment;
            set
            {
                _characterData.Equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }

        public string OtherProficiencies
        {
            get => _characterData.OtherProficiencies;
            set
            {
                _characterData.OtherProficiencies = value;
                OnPropertyChanged(nameof(OtherProficiencies));
            }
        }
        public string Features
        {
            get => _characterData.Features;
            set
            {
                _characterData.Features = value;
                OnPropertyChanged(nameof(Features));
            }
        }
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

            _hitDiceTypes = new ObservableCollection<string>()
            {
                "d6",
                "d8",
                "d10",
                "d12"
            };

            AbilityScore _str = new() { Name = "Strength", Score = 10 };
            AbilityScore _dex = new() { Name = "Dexterity", Score = 10 };
            AbilityScore _con = new() { Name = "Constitution", Score = 10 };
            AbilityScore _int = new() { Name = "Intelligence", Score = 10 };
            AbilityScore _wis = new() { Name = "Wisdom", Score = 10 };
            AbilityScore _cha = new() { Name = "Charisma", Score = 10 };


            _characterData.AbilityScores.AddRange(new List<AbilityScore> { _str, _dex, _con, _int, _wis, _cha });
            _abilityScores = new ObservableCollection<AbilityScore>(_characterData.AbilityScores);

            Skill saveStr = new() { Name = _str.Name, BaseAbilityScore = _str, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill saveDex = new() { Name = _dex.Name, BaseAbilityScore = _dex, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill saveCon = new() { Name = _con.Name, BaseAbilityScore = _con, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill saveInt = new() { Name = _int.Name, BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill saveWis = new() { Name = _wis.Name, BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill saveCha = new() { Name = _cha.Name, BaseAbilityScore = _cha, ProficiencyModifier = _characterData.ProficiencyBonus };

            _characterData.SavingThrows.AddRange(new List<Skill> { saveStr, saveDex, saveCon, saveInt, saveWis, saveCha });
            _savingThrows = new ObservableCollection<Skill>(_characterData.SavingThrows);

            Skill acrobatics = new() { Name = "Acrobatics", BaseAbilityScore = _dex, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill animalHandling = new() { Name = "Animal Handling", BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill arcana = new() { Name = "Arcana", BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill athletics = new() { Name = "Athletics", BaseAbilityScore = _str, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill deception = new() { Name = "Deception", BaseAbilityScore = _cha, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill history = new() { Name = "History", BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill insight = new() { Name = "Insight", BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill intimidation = new() { Name = "Intimidation", BaseAbilityScore = _cha, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill investigation = new() { Name = "Investigation", BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill medicine = new() { Name = "Medicine", BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill nature = new() { Name = "Nature", BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill perception = new() { Name = "Perception", BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill performance = new() { Name = "Performance", BaseAbilityScore = _cha, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill persuation = new() { Name = "Persuation", BaseAbilityScore = _cha, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill religion = new() { Name = "Religion", BaseAbilityScore = _int, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill slightOfHand = new() { Name = "Sleight of Hand", BaseAbilityScore = _dex, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill stealth = new() { Name = "Stealth", BaseAbilityScore = _dex, ProficiencyModifier = _characterData.ProficiencyBonus };
            Skill survival = new() { Name = "Survival", BaseAbilityScore = _wis, ProficiencyModifier = _characterData.ProficiencyBonus };

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

            _passiveSkills = new ObservableCollection<Skill>(new List<Skill>() { perception, insight, investigation });
            SelectedPassiveSkill = perception;

            Attack attack1 = new Attack();
            Attack attack2 = new Attack();
            Attack attack3 = new Attack();

            _characterData.Attacks.AddRange(new List<Attack>() { attack1, attack2, attack3 });
            _attacks = new ObservableCollection<Attack>(_characterData.Attacks);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

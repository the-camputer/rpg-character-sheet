using RPGCharacterSheet.Models;
using RPGCharacterSheet.ViewModels;

namespace RPGCharacterSheet.Tests.CharacterSheet
{
    public class CharactersheetViewModelTest
    {
        [Fact]
        public void Updating_VM_Updates_CharacterData()
        {
            CharacterData characterData = new();
            CharacterSheetViewModel viewModel = new(characterData);
            
            viewModel.CharacterName = "Balthazar";
            viewModel.Alignment = "LG";
            viewModel.PlayerName = "Lewis";
            viewModel.Class = "Bardbarian";
            viewModel.Level = 19;
            viewModel.Proficiency = 6;
            viewModel.Inspiration = true;
            viewModel.Background = "Baker";
            viewModel.Homeland = "The Shire";
            viewModel.Ancestry = "Halfling";
            viewModel.Gender = "what are you, a cop?";
            viewModel.Age = 25;
            viewModel.Height = "5'2\"";
            viewModel.Weight = "140 lbs";
            viewModel.Skin = "Glittery";
            viewModel.Hair = "Ashen";
            viewModel.Eyes = "Mulled wine";
            viewModel.ExperiencePoints = 350000;
            viewModel.ArmorClass = 14;
            viewModel.Initiative = 6;
            viewModel.Speed = 30;
            viewModel.HitPoints = 13;
            viewModel.HitPointMax = 132;
            viewModel.TemporaryHitPoints = 24;
            viewModel.HitDiceCount = 19;
            viewModel.HitDiceType = "d10";
            viewModel.DeathSaveSuccesses = 1;
            viewModel.DeathSaveFailures = 0;
            viewModel.Personality = "Test 1";
            viewModel.Ideals = "Test 2";
            viewModel.Bonds = "Test 3";
            viewModel.Flaws = "Test 4";
            viewModel.Coins.Find(coin => coin.Name == "EP").Count = 43;
            viewModel.Equipment = "longsword";
            viewModel.OtherProficiencies = "Languages: Elvish, Common";
            viewModel.Features = "Lucky";


            Assert.Equal("Balthazar", characterData.CharacterName);
            Assert.Equal("LG", characterData.Alignment);
            Assert.Equal("Lewis", characterData.PlayerName);
            Assert.Equal("Bardbarian", characterData.Class);
            Assert.Equal(19, characterData.Level);
            Assert.Equal(6, characterData.ProficiencyBonus.Modifier);
            Assert.True(characterData.Inspiration);
            Assert.Equal("Baker", characterData.Background);
            Assert.Equal("The Shire", characterData.Homeland);
            Assert.Equal("Halfling", characterData.Ancestry);
            Assert.Equal("what are you, a cop?", characterData.Gender);
            Assert.Equal(25, characterData.Age);
            Assert.Equal("5'2\"", characterData.Height);
            Assert.Equal("140 lbs", characterData.Weight);
            Assert.Equal("Glittery", characterData.Skin);
            Assert.Equal("Ashen", characterData.Hair);
            Assert.Equal("Mulled wine", characterData.Eyes);
            Assert.Equal(350000, characterData.ExperiencePoints);
            Assert.Equal(14, characterData.ArmorClass);
            Assert.Equal(6, characterData.Initiative);
            Assert.Equal(30, characterData.Speed);
            Assert.Equal(13, characterData.HitPoints);
            Assert.Equal(132, characterData.HitPointMax);
            Assert.Equal(24, characterData.TemporaryHitPoints);
            Assert.Equal(19, characterData.HitDiceCount);
            Assert.Equal("d10", characterData.HitDiceType);
            Assert.Equal(1, characterData.DeathSaveSuccesses);
            Assert.Equal(0, characterData.DeathSaveFailures);
            Assert.Equal("Test 1", characterData.Personality);
            Assert.Equal("Test 2", characterData.Ideals);
            Assert.Equal("Test 3", characterData.Bonds);
            Assert.Equal("Test 4", characterData.Flaws);
            Assert.Equal(43, characterData.Coins.Find(coin => coin.Name == "EP").Count);
            Assert.Equal("longsword", characterData.Equipment);
            Assert.Equal("Languages: Elvish, Common", characterData.OtherProficiencies);
            Assert.Equal("Luck", characterData.Features);
        }

        [Theory]
        [InlineData(0, "Strength")]
        [InlineData(1, "Dexterity")]
        [InlineData(2, "Constitution")]
        [InlineData(3, "Intelligence")]
        [InlineData(4, "Wisdom")]
        [InlineData(5, "Charisma")]
        public void VM_Adds_AbilityScores_To_Character_Data(int index, string expectedName)
        {
            CharacterData characterData = new();
            CharacterSheetViewModel viewModel = new CharacterSheetViewModel(characterData);

            Assert.Equal(expectedName, characterData.AbilityScores[index].Name);
            Assert.Equal(10, characterData.AbilityScores[index].Score);
            Assert.Equal(0, characterData.AbilityScores[index].Modifier);
        }

        [Theory]
        [InlineData(0, "Strength")]
        [InlineData(1, "Dexterity")]
        [InlineData(2, "Constitution")]
        [InlineData(3, "Intelligence")]
        [InlineData(4, "Wisdom")]
        [InlineData(5, "Charisma")]
        public void VM_Adds_Saving_Throws_To_Character_Data(int index, string expectedName)
        {
            CharacterData characterData = new();
            CharacterSheetViewModel viewModel = new CharacterSheetViewModel(characterData);

            Assert.Equal(expectedName, characterData.SavingThrows[index].Name);
            Assert.Equal(0, characterData.SavingThrows[index].Modifier);
        }

        [Theory]
        [InlineData(0, "Acrobatics", "Dexterity")]
        [InlineData(1, "Animal Handling", "Wisdom")]
        [InlineData(2, "Arcana", "Intelligence")]
        [InlineData(3, "Athletics", "Strength")]
        [InlineData(4, "Deception", "Charisma")]
        [InlineData(5, "History", "Intelligence")]
        [InlineData(6, "Insight", "Wisdom")]
        [InlineData(7, "Intimidation", "Charisma")]
        [InlineData(8, "Investigation", "Intelligence")]
        [InlineData(9, "Medicine", "Wisdom")]
        [InlineData(10, "Nature", "Intelligence")]
        [InlineData(11, "Perception", "Wisdom")]
        [InlineData(12, "Performance", "Charisma")]
        [InlineData(13, "Persuation", "Charisma")]
        [InlineData(14, "Religion", "Intelligence")]
        [InlineData(15, "Sleight of Hand", "Dexterity")]
        [InlineData(16, "Stealth", "Dexterity")]
        [InlineData(17, "Survival", "Wisdom")]
        public void VM_Adds_Skills_To_Character_Data(int index, string expectedSkillCheckName, string expectedAbilityScore)
        {
            CharacterData characterData = new();
            CharacterSheetViewModel viewModel = new(characterData);

            Assert.Equal(expectedSkillCheckName, characterData.SkillChecks[index].Name);
            Assert.Equal(expectedAbilityScore, characterData.SkillChecks[index].BaseAbilityScore.Name);
        }
    }
}
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
            CharacterSheetViewModel viewModel = new CharacterSheetViewModel(characterData);
            
            viewModel.CharacterName = "Balthazar";
            viewModel.Alignment = "LG";
            viewModel.PlayerName = "Lewis";
            viewModel.Class = "Bardbarian";
            viewModel.Level = 19;
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

            Assert.Equal("Balthazar", characterData.CharacterName);
            Assert.Equal("LG", characterData.Alignment);
            Assert.Equal("Lewis", characterData.PlayerName);
            Assert.Equal("Bardbarian", characterData.Class);
            Assert.Equal(19, characterData.Level);
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
        }
    }
}
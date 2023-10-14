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

            Assert.Equal("Balthazar", characterData.CharacterName);
            Assert.Equal("LG", characterData.Alignment);
            Assert.Equal("Lewis", characterData.PlayerName);
        }
    }
}
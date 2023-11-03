using RPGCharacterSheet.ViewModels;


namespace RPGCharacterSheet.Pages;

public partial class CharacterSheet : ContentPage
{
	

	public CharacterSheet()
    {
        BindingContext = new CharacterSheetViewModel();
        InitializeComponent();
        
    }
}
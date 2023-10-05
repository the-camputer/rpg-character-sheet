using RPG_Character_Sheet.Models;
using System.Collections.ObjectModel;

namespace RPG_Character_Sheet;

public partial class CharacterSheet : ContentPage
{
	private CharacterData characterData;

	ObservableCollection<string> alignments = new ObservableCollection<string>()
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
	public ObservableCollection<string> Alignments { get { return alignments; } }

	public CharacterSheet()
	{
		InitializeComponent();
		characterData = new CharacterData();

		AlignmentPicker.ItemsSource = alignments;
	}

    private void AlignmentPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		characterData.Alignment = ((Picker) sender).SelectedItem as string;
    }
}
using RPGCharacterSheet.ViewModels;


namespace RPGCharacterSheet.Pages;

public partial class CharacterSheet : ContentPage
{

    private FilePickerFileType _filePickerTypes;


    public CharacterSheet()
    {
        _filePickerTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".rpgc" } }
                });

        BindingContext = new CharacterSheetViewModel();
        InitializeComponent();

        System.Diagnostics.Debug.WriteLine(FileSystem.AppDataDirectory);
    }

    public async void SaveCharacter(object sender, EventArgs e)
    {
        FileResult file = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Save Character Data",
            FileTypes = _filePickerTypes
        });

        (BindingContext as CharacterSheetViewModel).CharacterData.Save(file.FullPath.ToString());

    }
}
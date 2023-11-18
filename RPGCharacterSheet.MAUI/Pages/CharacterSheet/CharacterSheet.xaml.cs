using CommunityToolkit.Maui.Storage;
using Newtonsoft.Json;
using RPGCharacterSheet.ViewModels;
using System.Text;

namespace RPGCharacterSheet.Pages;

public partial class CharacterSheet : ContentPage
{

    private FilePickerFileType _filePickerTypes;
    IFileSaver fileSaver;
    CancellationTokenSource cancellationToken = new CancellationTokenSource();

    public CharacterSheet(IFileSaver fileSaver)
    {
        _filePickerTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".rpgc" } }
                });

        BindingContext = new CharacterSheetViewModel();
        InitializeComponent();

        this.fileSaver = fileSaver;
    }


    public CharacterSheet() : this(null) { }

    public async void SaveCharacter(object sender, EventArgs e)
    {
        var characterData = (BindingContext as CharacterSheetViewModel).CharacterData;
        var serialized = JsonConvert.SerializeObject(characterData, Formatting.None);

        using var stream = new MemoryStream(Encoding.Default.GetBytes(serialized));

        await fileSaver.SaveAsync(FileSystem.Current.AppDataDirectory, $"{characterData.CharacterName}-{characterData.Level}.prgc", stream, cancellationToken.Token);

    }
}
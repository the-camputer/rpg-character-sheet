using CommunityToolkit.Maui.Storage;
using Newtonsoft.Json;
using RPGCharacterSheet.Models;
using RPGCharacterSheet.ViewModels;
using System.Text;

namespace RPGCharacterSheet.Pages;

public partial class CharacterSheet : ContentPage
{
    IFileSaver fileSaver;
    CancellationTokenSource cancellationToken = new CancellationTokenSource();

    public CharacterSheet(CharacterData characterData, IFileSaver fileSaver)
    {
        BindingContext = characterData == null ? new CharacterSheetViewModel() : new CharacterSheetViewModel(characterData);
        InitializeComponent();

        this.fileSaver = fileSaver;
    }

    public CharacterSheet(IFileSaver fileSaver) : this(null, fileSaver) { }

    public CharacterSheet() : this(new(), null) { }

    public CharacterSheet(CharacterData characterData) : this(characterData, null) { }

    public async void SaveCharacter(object sender, EventArgs e)
    {
        var characterData = (BindingContext as CharacterSheetViewModel).CharacterData;
        var serialized = JsonConvert.SerializeObject(characterData, Formatting.None);

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(serialized));

        await fileSaver.SaveAsync(FileSystem.Current.AppDataDirectory, $"{characterData.CharacterName}-{characterData.Level}.rpgc", stream, cancellationToken.Token);

    }
}
using CommunityToolkit.Maui.Storage;
using Newtonsoft.Json;
using RPGCharacterSheet.Models;

namespace RPGCharacterSheet.Pages
{
    public partial class MainPage : ContentPage
    {
        private FilePickerFileType _filePickerTypes;

        public MainPage()
        {
            InitializeComponent();
            _filePickerTypes = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".rpgc" } }
                });
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CharacterSheet(FileSaver.Default));
        }

        private async void LoadBtn_Clicked(object sender, EventArgs e)
        {
            var characterFile = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a Character",
                FileTypes = _filePickerTypes
            });

            using var stream = await characterFile.OpenReadAsync();
            StreamReader reader = new StreamReader(stream);
            string serializedData = reader.ReadToEnd();

            CharacterData characterData = JsonConvert.DeserializeObject<CharacterData>(serializedData);

            await Navigation.PushAsync(new CharacterSheet(characterData));
        }
    }
}
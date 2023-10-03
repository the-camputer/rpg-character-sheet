namespace RPG_Character_Sheet
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCreateClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Creating new character sheet");
        }
    }
}
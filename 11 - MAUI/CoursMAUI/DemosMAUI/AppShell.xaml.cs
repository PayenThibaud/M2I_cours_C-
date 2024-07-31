namespace DemosMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        public async void OnHelpClick(object sender, EventArgs e)
        {
            await DisplayAlert("Page d'aide", "Débrouillez vous !", "Retour");
        }
    }
}

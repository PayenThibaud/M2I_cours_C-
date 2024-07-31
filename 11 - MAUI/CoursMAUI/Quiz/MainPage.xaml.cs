
using Quiz.Views;

namespace Quiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void StartBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Q1());
        }
    }

}

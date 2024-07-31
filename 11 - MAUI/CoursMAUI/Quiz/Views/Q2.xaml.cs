namespace Quiz.Views;

public partial class Q2 : ContentPage
{
	public Q2()
    {
        InitializeComponent();
    }

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q3());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

}
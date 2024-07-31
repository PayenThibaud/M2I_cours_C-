namespace Quiz.Views;

public partial class Q6 : ContentPage
{
	public Q6()
	{
		InitializeComponent();
	}

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q7());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

}
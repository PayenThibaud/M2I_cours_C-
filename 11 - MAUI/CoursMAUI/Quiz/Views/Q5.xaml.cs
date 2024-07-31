namespace Quiz.Views;

public partial class Q5 : ContentPage
{
	public Q5()
	{
		InitializeComponent();
	}

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q6());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
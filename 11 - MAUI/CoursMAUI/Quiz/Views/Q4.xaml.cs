namespace Quiz.Views;

public partial class Q4 : ContentPage
{
	public Q4()
	{
		InitializeComponent();
	}

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q5());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
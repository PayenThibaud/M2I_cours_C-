namespace Quiz.Views;

public partial class Q7 : ContentPage
{
	public Q7()
	{
		InitializeComponent();
	}

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q8());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
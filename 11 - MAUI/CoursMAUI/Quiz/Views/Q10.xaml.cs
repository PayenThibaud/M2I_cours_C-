namespace Quiz.Views;

public partial class Q10 : ContentPage
{
	public Q10()
	{
		InitializeComponent();
	}
    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q11());
    }

    public async void Loose(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();

    }

}
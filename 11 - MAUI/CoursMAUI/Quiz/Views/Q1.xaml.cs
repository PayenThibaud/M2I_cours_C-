namespace Quiz.Views;

public partial class Q1 : ContentPage
{
	public Q1()
	{
		InitializeComponent();
	}

    public async void Win(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Q2());
    }

    public async void Loose(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new MainPage());
        await Navigation.PopToRootAsync();        // PB résolu en .net 7
        //await Navigation.PopAsync();
    }


}
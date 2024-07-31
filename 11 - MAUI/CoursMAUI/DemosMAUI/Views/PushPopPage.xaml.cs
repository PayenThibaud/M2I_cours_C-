namespace DemosMAUI.Views;

public partial class PushPopPage : ContentPage
{
    public PushPopPage()
    {
        InitializeComponent();
    }

    public PushPopPage(string entryContent)
	{
		InitializeComponent();
        EtText.Text = entryContent;
	}

    public async void OnPushClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PushPopPage(EtText.Text));
    }

    public async void OnPopClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    public async void OnPopAllClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
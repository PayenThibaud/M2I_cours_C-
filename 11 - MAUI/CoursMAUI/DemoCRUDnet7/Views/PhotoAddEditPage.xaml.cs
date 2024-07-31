using DemoCRUDnet7.Models;
using DemoCRUDnet7.Services;

namespace DemoCRUDnet7.Views;

public partial class PhotoAddEditPage : ContentPage
{
    private readonly ICRUDService<Photo> _photoService;
    public Photo Photo { get; set; }
    public bool IsUpdate { get; set; }
    public PhotoAddEditPage(ICRUDService<Photo> photoService, Photo photo = null)
	{
		InitializeComponent();
        _photoService = photoService;

        IsUpdate = photo != null;

        if (photo == null)
            photo = new Photo();

        BindingContext = Photo = photo;
    }
    public async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (IsUpdate)
        {
            await _photoService.Put(Photo);
        }
        else
            await _photoService.Post(Photo);

        //await Navigation.PopAsync();

        // Retourner à la page PhotoList
        //await Shell.Current.GoToAsync("//PhotoList");
        await Navigation.PopToRootAsync();

        // en .NET 6, il y a un bug avec GotoAsync et PopToRootAsync,
        // le nom dans la barre de navigation du shell change mais le contenu ne s'affiche pas
        // il a été réglé en .NET 7 => https://github.com/dotnet/maui/issues/10524
    }
}
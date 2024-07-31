using DemoCRUDnet7.Models;
using DemoCRUDnet7.Services;

namespace DemoCRUDnet7.Views;

public partial class PhotoDetailsPage : ContentPage
{
    private readonly ICRUDService<Photo> _photoService;
    public Photo Photo { get; set; }
	public PhotoDetailsPage(ICRUDService<Photo> photoService, Photo photo)
	{
		InitializeComponent();
        _photoService = photoService;
        BindingContext = Photo = photo;
    }

    public async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PhotoAddEditPage(_photoService, Photo));
    }

    public async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _photoService.Delete(Photo.Id);
        await Navigation.PopAsync();
    }

}
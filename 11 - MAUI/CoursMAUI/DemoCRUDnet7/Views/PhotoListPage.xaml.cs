using DemoCRUDnet7.Models;
using DemoCRUDnet7.Services;
using System.Collections.ObjectModel;

namespace DemoCRUDnet7.Views;

public partial class PhotoListPage : ContentPage
{
    private readonly ICRUDService<Photo> _photoService;
    public ObservableCollection<Photo> PhotoList { get; private set; } = new ObservableCollection<Photo>();

    public PhotoListPage(ICRUDService<Photo> photoService)
	{
		InitializeComponent();
        _photoService = photoService;
    }

    protected override async void OnAppearing() // similaire au OnInitialized de Blazor
    {
        BindingContext = PhotoList = new ObservableCollection<Photo>(await _photoService.GetAll());
    }

    public async void OnPhotoSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new PhotoDetailsPage(_photoService, (e.SelectedItem as Photo)!));
        }
    }
    public async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PhotoAddEditPage(_photoService));
    }

    public async void OnRefreshClicked(object sender, EventArgs e)
    {
        //BindingContext = PhotoList = new ObservableCollection<Photo>(await _photoService.GetAll());

        //réordonnement aléatoire pour simuler une mise à jour des données
        var list = (await _photoService.GetAll()).OrderBy(a => Guid.NewGuid()).ToList();
        BindingContext = PhotoList = new ObservableCollection<Photo>(list);
    }
    
}
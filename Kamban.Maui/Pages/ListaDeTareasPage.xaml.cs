using Kamban.Maui.ModelViews;
using Kamban.Maui.Services;

namespace Kamban.Maui.Pages;

public partial class ListaDeTareasPage : ContentPage
{
    private readonly ListaDeTareasModelView _listaDeTareasModelView;

    public ListaDeTareasPage(KambanService kambanService)
    {
        InitializeComponent();

        _listaDeTareasModelView = new ListaDeTareasModelView(Navigation, kambanService);
        BindingContext = _listaDeTareasModelView;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _listaDeTareasModelView.ObtenerTareasAsync();
    }
}
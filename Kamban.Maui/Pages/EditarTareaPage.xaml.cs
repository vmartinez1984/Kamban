using Kamban.Application.Commands.Tareas;
using Kamban.Maui.Services;

namespace Kamban.Maui.ModelViews;

public partial class EditarTareaPage : ContentPage
{
    private EditarTareaModelView _editarTareaModelView;
    public EditarTareaPage(ObtenerTareaCommandResponse tarea ,KambanService kambanService)
    {
        InitializeComponent();
        _editarTareaModelView = new EditarTareaModelView(tarea, Navigation, kambanService);
        BindingContext = _editarTareaModelView;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _editarTareaModelView.ObtenerEstadosAsync();
    }
}
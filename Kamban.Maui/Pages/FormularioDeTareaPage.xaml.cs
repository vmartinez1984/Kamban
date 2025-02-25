using Kamban.Maui.Services;

namespace Kamban.Maui.ModelViews;

public partial class FormularioDeTareaPage : ContentPage
{
    public FormularioDeTareaPage(KambanService kambanService)
    {
        InitializeComponent();
        BindingContext = new FormularioDeTareaModelView(Navigation, kambanService);
    }
}
using CommunityToolkit.Maui.Alerts;
using Kamban.Application.Commands.Tareas;
using Kamban.Maui.Services;
using System.Windows.Input;

namespace Kamban.Maui.ModelViews
{
    public class FormularioDeTareaModelView : BaseModelView
    {
        private AgregarTareaCommand tarea;
        private readonly INavigation _navigation;
        private readonly KambanService _kambanService;        

        public AgregarTareaCommand Tarea
        {
            get { return tarea; }
            set { tarea = value; OnPropertyChanged(); }
        }

        private bool estaCargando;

        public bool EstaCargando
        {
            get { return estaCargando; }
            set { estaCargando = value; OnPropertyChanged(); }
        }


        public ICommand GuardarCommand { get; }

        public FormularioDeTareaModelView()
        {
        }

        public FormularioDeTareaModelView(INavigation navigation, KambanService kambanService)
        {
            EstaCargando = false;
            Tarea = new AgregarTareaCommand();//Inicializar el objeto, de lo contrario no enlaza
            Tarea.EncodedKey = Guid.NewGuid().ToString();
            _navigation = navigation;
            _kambanService = kambanService;
            GuardarCommand = new Command(async () => await GuardarAsync());            
        }

        private async Task GuardarAsync()
        {
            EstaCargando = true;
            await _kambanService.AgregarTareaAsync(Tarea);
            _navigation.PopAsync();
            Toast.Make("Datos registrados").Show();
            EstaCargando = false;
        }
    }
}

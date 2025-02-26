using CommunityToolkit.Maui.Alerts;
using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Tareas;
using Kamban.Maui.Services;
using System.Windows.Input;

namespace Kamban.Maui.ModelViews
{
    public class EditarTareaModelView : BaseModelView
    {
        public INavigation _navigation { get; }
        private readonly KambanService _kambanService;

        #region Properties changed
        private List<GetEstadosCommandResponse> estados;
        public List<GetEstadosCommandResponse> Estados
        {
            get => estados;
            set { estados = value; OnPropertyChanged(); }
        }

        private GetEstadosCommandResponse estadoSeleccionado;
        public GetEstadosCommandResponse EstadoSeleccionado
        {
            get => estadoSeleccionado;
            set { estadoSeleccionado = value; OnPropertyChanged(); }
        }

        private ObtenerTareaCommandResponse _tarea;
        public ObtenerTareaCommandResponse Tarea
        {
            get { return _tarea; }
            set { _tarea = value; OnPropertyChanged(); }
        }
        #endregion

        #region ICommands
        public ICommand GuardarCommand { get; }
        #endregion

        public EditarTareaModelView()
        {

        }

        public EditarTareaModelView(ObtenerTareaCommandResponse tarea, INavigation navigation, KambanService kambanService)
        {
            Tarea = tarea;
            _navigation = navigation;
            _kambanService = kambanService;
            GuardarCommand = new Command(async () => await GuardarAsync());
        }

        private async Task GuardarAsync()
        {
            try
            {
                EstaCargando = true;
                Tarea.Estado = EstadoSeleccionado.Nombre;
                await _kambanService.ActualizarTareaAsync(Tarea);
                _ = _navigation.PopAsync();
                _ = Toast.Make("Datos registrados").Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _ = Toast.Make("Valio pepino :(").Show();
            }
            finally
            {
                EstaCargando = false;
            }
        }

        internal async Task ObtenerEstadosAsync()
        {
            try
            {
                EstaCargando = true;
                Estados = await _kambanService.ObtenerEstadosAsync();
                EstadoSeleccionado = Estados.Where(x => x.Nombre == Tarea.Estado).FirstOrDefault();
            }
            catch (Exception)
            {
                _ = Toast.Make("Valio pepino :(").Show();
            }
            finally
            {
                EstaCargando = false;
            }
        }

    }
}

using CommunityToolkit.Maui.Alerts;
using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Tareas;
using Kamban.Maui.Services;
using System.Windows.Input;

namespace Kamban.Maui.ModelViews;

public class ListaDeTareasModelView : BaseModelView
{
    private readonly KambanService _kambanService;

    #region
    private List<ObtenerTareaCommandResponse> _tareas;
    public List<ObtenerTareaCommandResponse> Tareas
    {
        get => _tareas;
        set { _tareas = value; }
    }

    private List<ObtenerTareaCommandResponse> _tareasFiltradas;
    public List<ObtenerTareaCommandResponse> TareasFiltradas
    {
        get => _tareasFiltradas;
        set { _tareasFiltradas = value; }
    }

    private bool _estaCargando;
    public bool EstaCargando
    {
        get => _estaCargando;
        set { _estaCargando = value; OnPropertyChanged(); }
    }

    private ObtenerTareaCommandResponse _tareaSeleccionada;

    public ObtenerTareaCommandResponse TareaSeleccionada
    {
        get { return _tareaSeleccionada; }
        set { _tareaSeleccionada = value; OnPropertyChanged(); }
    }

    private List<GetEstadosCommandResponse> estados;
    public List<GetEstadosCommandResponse> Estados
    {
        get { return estados; }
        set { estados = value; OnPropertyChanged(); }
    }

    private string textoABuscar;
    public string TextoABuscar
    {
        get { return textoABuscar; }
        set
        {
            textoABuscar = value;
            FiltrarTareas();
        }
    }

    private GetEstadosCommandResponse estadoSeleccionado;
    public GetEstadosCommandResponse EstadoSeleccionado
    {
        get { return estadoSeleccionado; }
        set
        {
            estadoSeleccionado = value;
            FiltrarTareas();
        }
    }
    #endregion

    public INavigation Navigation { get; }

    public ICommand TareaSeleccionadaCommand { get; }

    public ICommand AgregarNuevaTareaCommand { get; set; }

    #region Contructores
    public ListaDeTareasModelView()
    {

    }

    public ListaDeTareasModelView(INavigation navigation, KambanService kambanService)
    {
        TareaSeleccionada = new ObtenerTareaCommandResponse();
        Navigation = navigation;
        _kambanService = kambanService;
        TareaSeleccionadaCommand = new Command(SeleccionarTarea);
        AgregarNuevaTareaCommand = new Command(NavegarAFormularioDeTarea);
        EstaCargando = false;
    }

    private void NavegarAFormularioDeTarea(object obj)
    {
        Navigation.PushAsync(new FormularioDeTareaPage(_kambanService));
    }
    #endregion

    private void SeleccionarTarea()
    {
        if (TareaSeleccionada.Id != 0)
            Navigation.PushAsync(new EditarTareaPage(TareaSeleccionada, _kambanService));
    }

    public async Task ObtenerTareasAsync()
    {
        try
        {
            EstaCargando = true;
            var estados = await _kambanService.ObtenerEstadosAsync();
            estados.Insert(0, new GetEstadosCommandResponse { Id = "0", Nombre = "Todos" });
            Estados = estados;
            EstadoSeleccionado = Estados[0];
            OnPropertyChanged("EstadoSeleccionado");
            Tareas = await _kambanService.ObtenerAsync();
            TareasFiltradas = Tareas.OrderByDescending(x => x.FechaDeRegistro).ToList();
            OnPropertyChanged("TareasFiltradas");
        }
        catch (Exception ex)
        {
            _ = Toast.Make("Valio pepino :( ").Show();
        }
        finally
        {
            EstaCargando = false;
        }
    }

    private void FiltrarTareas()
    {
        if (estadoSeleccionado.Id == "0")
            TareasFiltradas = Tareas;
        else
            TareasFiltradas = Tareas.Where(x => x.Estado == estadoSeleccionado.Nombre).ToList();
        if (!string.IsNullOrEmpty(TextoABuscar))
        {
            var temporal = new List<ObtenerTareaCommandResponse>();
            foreach (var item in TareasFiltradas)
            {
                var nombre = item.Nombre.ToLower();
                var descripcion = string.IsNullOrEmpty(item.Descripcion) ? "" : item.Descripcion.ToLower();
                var texto = TextoABuscar.ToLower();
                if ($"{nombre} {descripcion}".Trim().Contains(texto))
                    temporal.Add(item);
            }
            TareasFiltradas = temporal;
        }
        OnPropertyChanged("TareasFiltradas");
    }
}
using Kamban.Domain.Entities;

namespace Kamban.Domain.Interfaces
{
    public interface ITareaRepository
    {
        Task ActualizarAsync(Tarea tarea);
        Task<string> Agregar(Tarea item);
        Task<Tarea> ObtenerPorIdAsync(string idGuid);
        Task<List<Tarea>> ObtenerTodosAsync();
    }
}

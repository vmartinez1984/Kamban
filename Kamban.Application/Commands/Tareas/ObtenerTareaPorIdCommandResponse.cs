using Kamban.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaPorIdCommandResponse
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaFinal { get; set; } = null;

        [DataType(DataType.Date)]
        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;

        public List<Bitacora> Bitacora { get; set; }

        public List<SubtareaCommand> Subtareas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kamban.Application.Commands.Tareas
{
    public class SubtareaCommand
    {
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

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;

        public List<BitacoraCommand> Bitacora { get; set; } = new List<BitacoraCommand>();

        [DataType(DataType.Date)]
        public DateTime FechaDeRegistro { get; set; }
    }
}
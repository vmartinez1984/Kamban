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

        [Required]
        public DateTime FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; } = null;

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;

        public List<BitacoraCommand> Bitacora { get; set; } = new List<BitacoraCommand>();
    }
}

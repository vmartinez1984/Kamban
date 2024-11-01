using System.ComponentModel;
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
                
        public string Descripcion { get; set; }

        [DisplayName("Inicial")]
        [DataType(DataType.Date)]
        public DateTime? FechaInicial { get; set; }

        [DisplayName("Final")]
        [DataType(DataType.Date)]
        public DateTime? FechaFinal { get; set; } = null;

        [DisplayName("Estimado")]
        public int TiempoEstimado { get; set; } = 0;

        [DisplayName("Consumido")]
        public int TiempoConsumido { get; set; } = 0;

        public List<BitacoraCommand> Bitacora { get; set; } = new List<BitacoraCommand>();

        [DisplayName("Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime FechaDeRegistro { get; set; }
    }
}
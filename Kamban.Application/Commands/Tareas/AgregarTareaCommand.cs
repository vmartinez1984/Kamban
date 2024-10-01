using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Kamban.Application.Commands.Tareas
{
    public class AgregarTareaCommand : IRequest<AgregarTareaCommandResponse>
    {
        [Required]
        public string EncodedKey { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; } = null;

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;
    }
}

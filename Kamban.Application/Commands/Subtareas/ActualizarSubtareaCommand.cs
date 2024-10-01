using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kamban.Application.Commands.Tareas
{
    public class ActualizarSubtareaCommand : IRequest<ActualizarSubtareaCommandResponse>
    {
        [JsonIgnore]
        public string SubtareaIdEncodedKey { get; set; }
        
        [JsonIgnore]
        public string TareaIdEncodedKey { get; set; }

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
    }  
}
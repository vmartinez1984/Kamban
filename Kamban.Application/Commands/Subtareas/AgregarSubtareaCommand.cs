using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Kamban.Application.Commands.Subtareas
{
    public class AgregarSubtareaCommand: IRequest<AgregarSubtareaCommandResponse>
    {
        [JsonIgnore]
        public string TareaIdEncodedkey { get; set; }

        [DefaultValue("")]
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
        
    }
}

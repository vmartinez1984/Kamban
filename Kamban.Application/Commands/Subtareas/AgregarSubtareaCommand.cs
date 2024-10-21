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

        public string Estado { get; set; } = "Enchilame esta";

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha incial")]
        public DateTime? FechaInicial { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha final")]
        public DateTime? FechaFinal { get; set; } = null;

        [DisplayName("Tiempo estimado")]
        public int? TiempoEstimado { get; set; } = 0;

        [DisplayName("Tiempo consumido")]
        public int? TiempoConsumido { get; set; } = 0;
        
    }
}

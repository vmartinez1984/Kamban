using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kamban.Application.Commands.Tareas
{
    public class AgregarTareaCommand : IRequest<AgregarTareaCommandResponse>
    {        
        public string EncodedKey { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(64)]
        public string Nombre { get; set; }
                
        [DisplayName("Descripción")]
        [MaxLength(250)]
        public string Descripcion { get; set; }

        [DisplayName("Fecha inicial")]
        [DataType(DataType.Date)]
        public DateTime? FechaInicial { get; set; } = null;

        [DisplayName("Fecha final")]
        [DataType(DataType.Date)]
        public DateTime? FechaFinal { get; set; } = null;

        [DisplayName("Tiempo estimado")]
        [Range(0,24)]
        public int? TiempoEstimado { get; set; } = null;

        [DisplayName("Tiempo consumido")]
        [Range(0, 24)]
        public int? TiempoConsumido { get; set; } = null;
    }
}
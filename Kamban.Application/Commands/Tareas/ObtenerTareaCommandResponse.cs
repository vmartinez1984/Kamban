using System.ComponentModel.DataAnnotations;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaCommandResponse
    {
        public int Id { get; set; }

        [Required]
        public string EncodedKey { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Inicio")]
        public DateTime? FechaInicial { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fin")]
        public DateTime? FechaFinal { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Registro")]
        public DateTime FechaDeRegistro { get; set; }

        [Display(Name = "Hrs estimadas")]
        public int TiempoEstimado { get; set; }

        [Display(Name = "Hrs consumidas")]
        public int TiempoConsumido { get; set; }
    }
}
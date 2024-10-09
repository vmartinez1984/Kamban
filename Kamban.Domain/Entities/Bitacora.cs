using System.ComponentModel;

namespace Kamban.Domain.Entities
{
    public class Bitacora
    {
        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Fecha")]
        public DateTime FechaDeRegistro { get; set; }
    }
}

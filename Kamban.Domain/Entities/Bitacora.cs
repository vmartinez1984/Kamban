namespace Kamban.Domain.Entities
{
    public class Bitacora
    {
        public string Encodedkey { get; set; } = Guid.NewGuid().ToString();

        public string Descripcion { get; set; }

        public DateTime FechaDeRegistro { get; set; }
    }
}

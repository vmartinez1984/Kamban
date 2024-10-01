using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kamban.Domain.Entities
{
    public class Tarea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public int Id { get; set; }

        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public string Estado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime? FechaInicial { get; set; } = null;

        public DateTime? FechaFinal { get; set; } = null;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;

        public List<Bitacora> Bitacora { get; set; } = new List<Bitacora>();

        public List<Subtarea> Subtareas { get; set; } = new List<Subtarea>();
    }

    public class Subtarea 
    {
        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public string Estado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; } = null;

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public int TiempoEstimado { get; set; } = 0;

        public int TiempoConsumido { get; set; } = 0;

        public List<Bitacora> Bitacora { get; set; }
    }
}

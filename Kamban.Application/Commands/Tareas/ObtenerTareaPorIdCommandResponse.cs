using Kamban.Domain.Entities;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaPorIdCommandResponse
    {
        public int Id { get; set; }

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

        public List<SubtareaCommand> Subtareas { get; set; }
    }

    //public class SubtareaCommand
    //{
    //    public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

    //    public string Estado { get; set; }

    //    public string Nombre { get; set; }

    //    public string Descripcion { get; set; }

    //    public DateTime FechaInicial { get; set; }

    //    public DateTime? FechaFinal { get; set; } = null;

    //    public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

    //    public int TiempoEstimado { get; set; } = 0;

    //    public int TiempoConsumido { get; set; } = 0;

    //    public List<Bitacora> Bitacora { get; set; }
    //}
}

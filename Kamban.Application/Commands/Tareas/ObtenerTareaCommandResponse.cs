namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaCommandResponse
    {
        public int Id { get; set; }

        public string EncodedKey { get; set; }

        public string Estado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }


        public DateTime? FechaFinal { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public int TiempoEstimado { get; set; }

        public int TiempoConsumido { get; set; }
    }
}

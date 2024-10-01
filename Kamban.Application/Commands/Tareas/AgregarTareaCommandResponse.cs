namespace Kamban.Application.Commands.Tareas
{
    public class AgregarTareaCommandResponse
    {
        public string Id { get; set; }

        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; }
    }
}
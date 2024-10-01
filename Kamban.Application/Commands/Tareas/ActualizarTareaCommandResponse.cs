namespace Kamban.Application.Commands.Tareas
{
    public class ActualizarTareaCommandResponse
    {
        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}

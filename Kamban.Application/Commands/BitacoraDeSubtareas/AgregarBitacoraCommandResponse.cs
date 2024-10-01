namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraASubtareaCommandResponse
    {
        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}

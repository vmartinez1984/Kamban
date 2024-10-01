namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraCommandResponse
    {
        public string EncodedKey { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;
    }
}

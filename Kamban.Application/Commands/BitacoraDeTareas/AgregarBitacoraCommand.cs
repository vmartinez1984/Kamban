using MediatR;
using System.Text.Json.Serialization;

namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraCommand: IRequest<AgregarBitacoraCommandResponse>
    {
        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        [JsonIgnore]
        public string TareaIdEncodedKey { get; set; }

        public string Descripcion { get; set; }
    }
}
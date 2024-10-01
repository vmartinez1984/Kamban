using MediatR;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraASubtareaCommand: IRequest<AgregarBitacoraASubtareaCommandResponse>
    {
        [JsonIgnore]
        public string TareaIdEncodedKey { get; set; }

        [JsonIgnore]
        public string SubareaIdEncodedKey { get; set; }

        [DefaultValue("")]
        public string EncodedKey { get; set; } = Guid.NewGuid().ToString();

        public string Descripcion { get; set; }
    }
}
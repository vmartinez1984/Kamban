using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaCommand : IRequest<List<ObtenerTareaCommandResponse>>
    {
        public string IdEncodedKey { get; set; }

        public string Estado { get; set; }
    }
}

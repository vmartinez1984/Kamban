using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaPorIdCommand : IRequest<ObtenerTareaPorIdCommandResponse>
    {
        public string IdEncodedKey { get; set; }
    }
}

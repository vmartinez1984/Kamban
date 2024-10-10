using MediatR;

namespace Kamban.Application.Commands.Estados
{
    public class GetEstadosCommand: IRequest<List<GetEstadosCommandResponse>>
    {
    }
}

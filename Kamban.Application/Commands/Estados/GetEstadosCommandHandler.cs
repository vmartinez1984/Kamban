using MediatR;

namespace Kamban.Application.Commands.Estados
{
    internal class GetEstadosCommandHandler : IRequestHandler<GetEstadosCommand, List<GetEstadosCommandResponse>>
    {
        public Task<List<GetEstadosCommandResponse>> Handle(GetEstadosCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<GetEstadosCommandResponse> {
                new GetEstadosCommandResponse { Id = "1", Nombre = "Enchilame esta" },
                new GetEstadosCommandResponse { Id = "2", Nombre = "Talacha" },
                new GetEstadosCommandResponse { Id = "3", Nombre = "Yasta" }
            });
        }
    }
}

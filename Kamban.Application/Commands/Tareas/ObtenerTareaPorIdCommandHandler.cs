using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaPorIdCommandHandler(
        ITareaRepository tareaRepository,
        IMapper mapper
    )
    : IRequestHandler<ObtenerTareaPorIdCommand, ObtenerTareaPorIdCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ObtenerTareaPorIdCommandResponse> Handle(ObtenerTareaPorIdCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;
            ObtenerTareaPorIdCommandResponse response;

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.IdEncodedKey);
            response = _mapper.Map<ObtenerTareaPorIdCommandResponse>(tarea);

            return response;
        }
    }
}

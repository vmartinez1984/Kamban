using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ActualizarSubtareaCommandHandler(
        ITareaRepository tareaRepository,
        IMapper mapper
    ) : IRequestHandler<ActualizarSubtareaCommand, ActualizarSubtareaCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ActualizarSubtareaCommandResponse> Handle(ActualizarSubtareaCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;
            Subtarea subtarea;

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.TareaIdEncodedKey);
            subtarea = tarea.Subtareas.FirstOrDefault(x=> x.EncodedKey == request.SubtareaIdEncodedKey);
            subtarea = _mapper.Map(request, subtarea);
            await _tareaRepository.ActualizarAsync(tarea);

            return new ActualizarSubtareaCommandResponse
            {
                 EncodedKey = subtarea.EncodedKey
            };
        }
    }
}

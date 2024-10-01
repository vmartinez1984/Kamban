using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Subtareas
{
    public class AgregarSubtareaCommandHandler(
        ITareaRepository tareaRepository
        , IMapper mapper
    ) : IRequestHandler<AgregarSubtareaCommand, AgregarSubtareaCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        async Task<AgregarSubtareaCommandResponse> IRequestHandler<AgregarSubtareaCommand, AgregarSubtareaCommandResponse>.Handle(AgregarSubtareaCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;
            Subtarea subtarea;

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.TareaIdEncodedkey);
            subtarea = _mapper.Map<Subtarea>(request);
            tarea.Subtareas.Add(subtarea);
            await _tareaRepository.ActualizarAsync(tarea);

            return new AgregarSubtareaCommandResponse { EncodedKey = request.EncodedKey, FechaDeRegistro = DateTime.Now };
        }
    }
}
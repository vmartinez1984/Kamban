using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ActualizarTareaCommandHandler(
        ITareaRepository tareaRepository,
        IMapper mapper
    ) : IRequestHandler<ActualizarTareaCommand, ActualizarTareaCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ActualizarTareaCommandResponse> Handle(ActualizarTareaCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;            

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.TareaIdEncodedKey);            
            tarea = _mapper.Map(request, tarea);
            await _tareaRepository.ActualizarAsync(tarea);

            return new ActualizarTareaCommandResponse
            {
                 EncodedKey = tarea.EncodedKey                 
            };
        }
    }
}

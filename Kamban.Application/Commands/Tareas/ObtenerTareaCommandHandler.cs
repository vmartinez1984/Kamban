using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class ObtenerTareaCommandHandler(
        ITareaRepository tareaRepository
        , IMapper mapper
    ) : IRequestHandler<ObtenerTareaCommand, List<ObtenerTareaCommandResponse>>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ObtenerTareaCommandResponse>> Handle(ObtenerTareaCommand request, CancellationToken cancellationToken)
        {
            List<ObtenerTareaCommandResponse> response;
            List<Tarea> tareas;

            tareas = await _tareaRepository.ObtenerTodosAsync(request.Estado);
            response = _mapper.Map<List<ObtenerTareaCommandResponse>>(tareas);            

            return response;
        }

    }//end class
}
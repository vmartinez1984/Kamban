using AutoMapper;
using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.Tareas
{
    public class AgregarTareaCommandHandler(
        ITareaRepository tareaRepository,
        IMapper mapper
    ) : IRequestHandler<AgregarTareaCommand, AgregarTareaCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AgregarTareaCommandResponse> Handle(AgregarTareaCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;
            string id;

            if (string.IsNullOrEmpty(request.EncodedKey))
                request.EncodedKey = Guid.NewGuid().ToString();
            tarea = _mapper.Map<Tarea>(request);
            tarea.Estado = "Enchilame esta";
            id = await _tareaRepository.Agregar(tarea);

            return new AgregarTareaCommandResponse
            {
                Id = id,
                EncodedKey = request.EncodedKey,
                FechaDeRegistro = DateTime.Now
            };
        }
    }
}

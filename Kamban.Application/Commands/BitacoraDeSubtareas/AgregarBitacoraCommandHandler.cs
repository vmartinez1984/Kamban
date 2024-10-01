using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraASubtareaCommandHandler(
        ITareaRepository tareaRepository
    ) : IRequestHandler<AgregarBitacoraASubtareaCommand, AgregarBitacoraASubtareaCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;

        public async Task<AgregarBitacoraASubtareaCommandResponse> Handle(AgregarBitacoraASubtareaCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;
            Subtarea subtarea;

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.TareaIdEncodedKey);
            subtarea = tarea.Subtareas.FirstOrDefault(x => x.EncodedKey == request.TareaIdEncodedKey);
            if (subtarea.Bitacora is null)
                subtarea.Bitacora = new List<Bitacora>();
            subtarea.Bitacora.Add(new Bitacora
            {
                Descripcion = request.Descripcion,
                FechaDeRegistro = DateTime.Now,
                Encodedkey = request.EncodedKey
            });
            await _tareaRepository.ActualizarAsync(tarea);

            return new AgregarBitacoraASubtareaCommandResponse { 
                EncodedKey = request.EncodedKey,
                FechaDeRegistro = DateTime.Now
            };
        }
    }
}

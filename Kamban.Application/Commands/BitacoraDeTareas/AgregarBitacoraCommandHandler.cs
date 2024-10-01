using Kamban.Domain.Entities;
using Kamban.Domain.Interfaces;
using MediatR;

namespace Kamban.Application.Commands.BitacoraDeTareas
{
    public class AgregarBitacoraCommandHandler(
        ITareaRepository tareaRepository
    ) : IRequestHandler<AgregarBitacoraCommand, AgregarBitacoraCommandResponse>
    {
        private readonly ITareaRepository _tareaRepository = tareaRepository;

        public async Task<AgregarBitacoraCommandResponse> Handle(AgregarBitacoraCommand request, CancellationToken cancellationToken)
        {
            Tarea tarea;

            tarea = await _tareaRepository.ObtenerPorIdAsync(request.TareaIdEncodedKey);
            tarea.Bitacora.Add(new Bitacora { Descripcion = request.Descripcion, FechaDeRegistro = DateTime.Now, Encodedkey = request.EncodedKey });
            await _tareaRepository.ActualizarAsync(tarea);

            return new AgregarBitacoraCommandResponse
            {
                EncodedKey = request.EncodedKey,
                FechaDeRegistro = DateTime.Now
            };
        }
    }
}

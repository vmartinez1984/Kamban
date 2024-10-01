using AutoMapper;
using Kamban.Application.Commands.Subtareas;
using Kamban.Application.Commands.Tareas;
using Kamban.Domain.Entities;

namespace Kamban.Application.Helpers
{
    public class TareaMapper : Profile
    {
        public TareaMapper()
        {
            CreateMap<AgregarTareaCommand, Tarea>();

            CreateMap<Tarea, ObtenerTareaCommandResponse>();

            CreateMap<Tarea, ObtenerTareaPorIdCommandResponse>();

            CreateMap<BitacoraCommand, Bitacora>();

            CreateMap<AgregarSubtareaCommand, Subtarea>();

            CreateMap<Bitacora, BitacoraCommand>();

            CreateMap<Subtarea, SubtareaCommand>();

            CreateMap<ActualizarSubtareaCommand, Subtarea>();

            CreateMap<ActualizarTareaCommand, Tarea>();
        }
    }
}

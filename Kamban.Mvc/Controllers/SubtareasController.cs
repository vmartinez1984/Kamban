using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Subtareas;
using Kamban.Application.Commands.Tareas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kamban.Mvc.Controllers
{
    public class SubtareasController : Controller
    {
        private readonly IMediator _mediator;

        public SubtareasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Agregar(int tareaId)
        {
            ViewData["tareaId"] = tareaId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarSubtarea(AgregarSubtareaCommand command)
        {
            var data = await _mediator.Send(command);

            return RedirectToAction("Detalles", "Home", new { Id = command.TareaIdEncodedkey });
        }

        public async Task<IActionResult> Editar(string tareaId, string subtareaId)
        {
            ObtenerTareaPorIdCommandResponse response;
            SubtareaCommand subtarea;

            response = await _mediator.Send(new ObtenerTareaPorIdCommand { IdEncodedKey = tareaId });
            subtarea = response.Subtareas.FirstOrDefault(x => x.EncodedKey == subtareaId);
            ViewData["tareaId"] = tareaId;
            ViewBag.Estados = (await _mediator.Send(new GetEstadosCommand())).Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Nombre
            });

            return View(subtarea);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(SubtareaCommand subtarea, string tareaId)
        {
            ActualizarSubtareaCommandResponse response;
            ActualizarSubtareaCommand command;

            command = new ActualizarSubtareaCommand
            {
                Descripcion = subtarea.Descripcion,
                Estado = subtarea.Estado,
                FechaFinal = subtarea.FechaFinal,
                FechaInicial = subtarea.FechaInicial,
                Nombre = subtarea.Nombre,
                SubtareaIdEncodedKey = subtarea.EncodedKey,
                TareaIdEncodedKey = tareaId,
                TiempoConsumido = subtarea.TiempoConsumido,
                TiempoEstimado = subtarea.TiempoEstimado
            };
            response = await _mediator.Send(command);

            return RedirectToAction("Detalles", "Home", new { Id = command.TareaIdEncodedKey });
        }
    }
}

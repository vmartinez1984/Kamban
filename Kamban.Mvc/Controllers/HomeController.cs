using Kamban.Application.Commands.BitacoraDeTareas;
using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Tareas;
using Kamban.Mvc.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Kamban.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            List<ObtenerTareaCommandResponse> response;

            response = await _mediator.Send(new ObtenerTareaCommand());

            return View(response);
        }

        public IActionResult AgregarTarea()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarTarea(AgregarTareaCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction("Index");
        }

        public IActionResult AgregarSubtarea(int tareaId)
        {
            ViewBag["tareaId"] = tareaId;

            return View();
        }

        public async Task<IActionResult> EditarTarea(int id)
        {
            ObtenerTareaPorIdCommandResponse response;

            response = await _mediator.Send(new ObtenerTareaPorIdCommand { IdEncodedKey = id.ToString() });
            ViewBag.Estados = (await _mediator.Send(new GetEstadosCommand())).Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Nombre
            });

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarea(ObtenerTareaCommandResponse commandResponse)
        {
            await _mediator.Send(new ActualizarTareaCommand
            {
                Descripcion = commandResponse.Descripcion,
                Estado = commandResponse.Estado,
                FechaFinal = commandResponse.FechaFinal,
                FechaInicial = commandResponse.FechaInicial,
                Nombre = commandResponse.Nombre,
                TareaIdEncodedKey = commandResponse.Id.ToString(),
                TiempoConsumido = commandResponse.TiempoConsumido,
                TiempoEstimado = commandResponse.TiempoEstimado
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detalles(int id)
        {
            ObtenerTareaPorIdCommandResponse response;

            response = await _mediator.Send(new ObtenerTareaPorIdCommand { IdEncodedKey = id.ToString() });
            ViewData["tareaId"] = id;

            return View(response);
        }

        public IActionResult AgregarBitacora(string tareaId)
        {
            ViewData["tareaId"] = tareaId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarBitacora(AgregarBitacoraCommand command)
        {
            var data = await _mediator.Send(command);

            return RedirectToAction("Detalles", new { Id = command.TareaIdEncodedKey });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

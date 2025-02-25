using Kamban.Application.Commands.BitacoraDeTareas;
using Kamban.Application.Commands.Estados;
using Kamban.Application.Commands.Subtareas;
using Kamban.Application.Commands.Tareas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kamban.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AgregarAsync(AgregarTareaCommand command, IMediator mediator)
        {
            AgregarTareaCommandResponse response;

            response = await mediator.Send(command);

            return Created($"Tareas/{response.Id}", response);
        }

        [HttpPost("{idEncodekey}/Bitacoras")]
        public async Task<IActionResult> AgregarBitacoraAsync(string idEncodekey,AgregarBitacoraCommand command, IMediator mediator)
        {
            AgregarBitacoraCommandResponse response;

            command.TareaIdEncodedKey = idEncodekey;
            response = await mediator.Send(command);

            return Created(string.Empty,response);
        }

        [HttpPost("{idEncodekey}/subtareas")]
        public async Task<IActionResult> AgregarSubtareaAsync(string idEncodekey,AgregarSubtareaCommand command,IMediator mediator)
        {
            AgregarSubtareaCommandResponse response;

            command.TareaIdEncodedkey = idEncodekey;
            response = await mediator.Send(command);

            return Created(string.Empty, response);
        }

        [HttpPost("{idEncodekey}/subtareas/{subtareaIdEncodedKey}/Bitacoras")]
        public async Task<IActionResult> AgregarBitacoraASubtareaAsync(string idEncodekey, string subtareaIdEncodedKey, AgregarBitacoraASubtareaCommand command,IMediator mediator)
        {
            AgregarBitacoraASubtareaCommandResponse response;

            command.TareaIdEncodedKey = idEncodekey;
            command.SubareaIdEncodedKey = subtareaIdEncodedKey;
            response = await mediator.Send(command);

            return Created(string.Empty, response);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos(IMediator mediator)
        {
            List<ObtenerTareaCommandResponse> response;

            response = await mediator.Send(new ObtenerTareaCommand());

            return Ok(response);
        }

        [HttpGet("{idEncodedKey}")]
        public async Task<IActionResult> ObtenerPorId(string idEncodedKey, IMediator mediator)
        {
            ObtenerTareaPorIdCommandResponse response;

            response = await mediator.Send(new ObtenerTareaPorIdCommand { IdEncodedKey = idEncodedKey });

            return Ok(response);
        }

        [HttpPut("{idEncodedKey}")]
        public async Task<IActionResult> Actualizar(string idEncodedKey, ActualizarTareaCommand command, IMediator mediator)
        {
            command.TareaIdEncodedKey = idEncodedKey;
            await mediator.Send(command);

            return Accepted();
        }

        [HttpPut("{idEncodedKey}/Subtareas/{subtareaIdEncodedKey}")]
        public async Task<IActionResult> ActualizarSubtarea(string idEncodedKey, string subtareaIdEncodedKey, ActualizarSubtareaCommand command, IMediator mediator)
        {
            ActualizarSubtareaCommandResponse response;

            command.TareaIdEncodedKey = idEncodedKey;
            command.SubtareaIdEncodedKey = subtareaIdEncodedKey;
            response = await mediator.Send(command);

            return Accepted(response);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {        
        [HttpGet()]
        public  async Task<IActionResult> ObtenerEstados(IMediator mediator)
        {
            return Ok(await mediator.Send(new GetEstadosCommand { }));
        }
    }
}

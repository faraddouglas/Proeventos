using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class EventoController : ControllerBase
   {
      private readonly IEventoService _eventoService;

      public EventoController(IEventoService eventoService)
      {
         _eventoService = eventoService;
      }

      [HttpGet]
      public async Task<ActionResult> Get()
      {
         try
         {
            var eventos = await _eventoService.GetAllEventosAsync(true);

            if (eventos == null) return NotFound("Nenhum evento encontrado.");

            return Ok(eventos);
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
         }
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetById(int id)
      {
         try
         {
            var evento = await _eventoService.GetAllEventosByIdAsync(id, true);

            if (evento == null) return NotFound("Evento não encontrado.");

            return Ok(evento);
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
         }
      }

      [HttpGet("/tema/{tema}")]
      public async Task<IActionResult> GetByTema(string tema)
      {
         try
         {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);

            if (eventos == null) return NotFound("Não encontrado eventos com esse tema.");

            return Ok(eventos);
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
         }
      }

      [HttpPost]
      public async Task<IActionResult> Post(Evento evento)
      {
         try
         {
            var _evento = await _eventoService.AddEvento(evento);

            if (evento == null) return BadRequest("Erro ao adicionar evento.");

            return Ok(evento);
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
         }
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, Evento evento)
      {
         try
         {
            var _evento = await _eventoService.UpdateEvento(id, evento);

            if (evento == null) return BadRequest("Erro ao atulizar evento.");

            return Ok(evento);
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar atualizar evento. Erro: {ex.Message}");
         }
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         try
         {
            if(await _eventoService.DeleteEvento(id)) return Ok();
            else return BadRequest("Evento não deletado.");
         }
         catch (Exception ex)
         {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro ao tentar deletar evento. Erro: {ex.Message}");
         }
      }
   }

}

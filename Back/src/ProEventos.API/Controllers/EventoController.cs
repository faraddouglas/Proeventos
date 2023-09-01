using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
      public IEnumerable<Evento> _eventos = new Evento[] {
               new Evento() {
                           EventoId = 1,
                           Tema = "Angular e .NET5",
                           Local = "Belo horizonte",
                           Lote = "1° lote",
                           QtdPessoas = 250,
                           DataEvento = DateTime.Now.AddDays(2).ToString(),
                           ImageURL = "foto.png"
                        },
                  new Evento() {
                           EventoId = 2,
                           Tema = "Angular e .NET5 e suas novidades",
                           Local = "Belo horizonte",
                           Lote = "2° lote",
                           QtdPessoas = 350,
                           DataEvento = DateTime.Now.AddDays(3).ToString(),
                           ImageURL = "foto.png"
                        }
           };

        public EventoController()
        {
           
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
           return  _eventos;       
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
           return  _eventos.Where(evento => evento.EventoId == id);       
        }


        [HttpPost]
        public string Post()
        {
           return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
           return $"Exemplo de put {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           return $"Exemplo de delete {id}";
        }
    }
    
}

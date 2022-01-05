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
        private readonly ILogger<EventoController> _logger;
        private IEnumerable<Evento> _eventos;

        public EventoController(ILogger<EventoController> logger)
        {
            _logger = logger;
            _eventos = new Evento[]
            {
                new Evento()
                {
                    EventoId = 1,
                    DataEvento = DateTime.Now,
                    ImagemURL = "",
                    Local = "Juiz de Fora",
                    Lote = "1º Lote",
                    QtdPessoas = 100,
                    Tema = "Angular 11 e .NET 5"
                },
                new Evento()
                {
                    EventoId = 2,
                    DataEvento = DateTime.Now,
                    ImagemURL = "",
                    Local = "São João Nepomuceno",
                    Lote = "1º Lote",
                    QtdPessoas = 300,
                    Tema = "Angular 11 e .NET 5"
                }
            };
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _eventos.Where(x => x.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "value";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "value";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "value";
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.ListarTodos());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_personagemRepository.BuscarPorId(Id));
        }

        [HttpGet("classe")]
        public IActionResult ListarComClasse()
        {
            return Ok(_personagemRepository.ListarComClasse());
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novapersonagem)
        {
            _personagemRepository.Cadastrar(novapersonagem);

            return StatusCode(201);
        }

        [HttpPut("{idPersonagem}")]
        public IActionResult AtualizarIdUrl(int idPersonagem, Personagem personagemAtualizado)
        {
            _personagemRepository.AtualizarIdUrl(idPersonagem, personagemAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _personagemRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}

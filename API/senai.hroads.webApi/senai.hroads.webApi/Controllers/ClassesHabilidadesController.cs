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
    public class ClassesHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClassesHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeHabilidadeRepository.ListarTodos());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_classeHabilidadeRepository.BuscarPorId(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade novaClasseHabilidade)
        {
            _classeHabilidadeRepository.Cadastrar(novaClasseHabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult AtualizarIdUrl(ClasseHabilidade classeHabilidadeAtualizado)
        {
            _classeHabilidadeRepository.AtualizarIdUrl(classeHabilidadeAtualizado.IdClasseHabilidade, classeHabilidadeAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(short Id)
        {
            _classeHabilidadeRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}

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
    public class TiposHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TiposHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(Id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novatipoHabilidade)
        {
            _tipoHabilidadeRepository.Cadastrar(novatipoHabilidade);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult AtualizarIdUrl(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado)
        {
            _tipoHabilidadeRepository.AtualizarIdUrl(idTipoHabilidade, tipoHabilidadeAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _tipoHabilidadeRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}

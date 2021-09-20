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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.ListarTodos());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            return Ok(_usuarioRepository.BuscarPorId(Id));
        }

        [HttpGet("tipo")]
        public IActionResult ListarComTipo()
        {
            return Ok(_usuarioRepository.ListarComTipo());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novausuario)
        {
            _usuarioRepository.Cadastrar(novausuario);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult AtualizarIdCorpo(Usuario usuarioAtualizado)
        {
            _usuarioRepository.AtualizarIdCorpo(usuarioAtualizado.IdUsuario, usuarioAtualizado);

            return StatusCode(204);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _usuarioRepository.Deletar(Id);

            return StatusCode(204);

        }
    }
}

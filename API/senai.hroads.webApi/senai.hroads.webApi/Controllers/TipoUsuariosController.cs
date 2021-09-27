using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using senai.hroads.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TipoUsuariosController : ControllerBase
        {
            private ITipoUsuarioRepository _tipousuarioRepository { get; set; }

            public TipoUsuariosController()
            {
                _tipousuarioRepository = new TipoUsuarioRespoitory();
            }

            [HttpGet]
            public IActionResult Listar()
            {
                return Ok(_tipousuarioRepository.ListarTodos());
            }

            [HttpGet("{Id}")]
            public IActionResult BuscarPorId(int Id)
            {
                return Ok(_tipousuarioRepository.BuscarPorId(Id));
            }

            [Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Cadastrar(TipoUsuario novatipousuario)
            {
                _tipousuarioRepository.Cadastrar(novatipousuario);

                return StatusCode(201);
            }

            [HttpPut]
            public IActionResult AtualizarIdUrl(int idTipoUsuario, TipoUsuario tipousuarioAtualizado)
            {
                _tipousuarioRepository.AtualizarIdUrl(idTipoUsuario, tipousuarioAtualizado);

                return StatusCode(204);

            }

            [HttpDelete("{Id}")]
            public IActionResult Deletar(int Id)
            {
                _tipousuarioRepository.Deletar(Id);

                return StatusCode(204);

            }
        }
    }

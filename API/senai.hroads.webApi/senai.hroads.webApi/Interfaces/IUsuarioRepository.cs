using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        void Cadastrar(Usuario novoUsuario);

        public Usuario BuscarPorId(int IdUsuario);

        void AtualizarIdUrl(int IdUsuario, Usuario UsuarioAtualizado);

        void Deletar(int IdUsuario);

        Usuario Login(string senha, string email);

        List<Usuario> ListarComTipo();
    }
}

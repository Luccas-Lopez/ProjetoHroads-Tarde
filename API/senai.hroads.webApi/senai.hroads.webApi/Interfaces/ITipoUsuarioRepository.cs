using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();
        void Cadastrar(TipoUsuario novoTipoUsuario);

        TipoUsuario BuscarPorId(int IdTipoUsuario);

        void AtualizarIdUrl(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado);

        void Deletar(int IdTipoUsuario);
    }
}

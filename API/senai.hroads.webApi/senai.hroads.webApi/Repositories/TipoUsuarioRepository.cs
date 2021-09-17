using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoUsuario : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<.TipoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

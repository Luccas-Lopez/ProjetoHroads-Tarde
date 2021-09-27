using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoUsuarioRespoitory : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void AtualizarIdUrl(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == IdTipoUsuario);


            if (TipoUsuarioAtualizado.nomeTipoUsuario != null)
            {
                tipoUsuarioBuscado.nomeTipoUsuario = TipoUsuarioAtualizado.nomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int IdTipoUsuario)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == IdTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int IdTipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = BuscarPorId(IdTipoUsuario);
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}

using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado)
        {
            TipoHabilidade tipoHabilidadeBuscado = BuscarPorId(IdTipoHabilidade);

            if (tipoHabilidadeAtualizado.NomeTipoHabilidade != null)
            {
                tipoHabilidadeBuscado.NomeTipoHabilidade = tipoHabilidadeAtualizado.NomeTipoHabilidade;
            }

            ctx.TipoHabilidades.Update(tipoHabilidadeBuscado);

            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int IdTipoHabilidade)
        {
            return ctx.TipoHabilidades.FirstOrDefault(e => e.IdTipoHabilidade == IdTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int IdTipoHabilidade)
        {
            TipoHabilidade TipoHabilidadeBuscado = BuscarPorId(IdTipoHabilidade);
            ctx.TipoHabilidades.Remove(TipoHabilidadeBuscado);
            ctx.SaveChanges();
        }

        public List<TipoHabilidade> ListarTodos()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}

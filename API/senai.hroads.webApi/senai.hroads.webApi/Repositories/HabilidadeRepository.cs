using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = BuscarPorId(IdHabilidade);

            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int IdHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == IdHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int IdHabilidade)
        {
            Habilidade habilidadeBuscada = BuscarPorId(IdHabilidade);
            ctx.Habilidades.Remove(habilidadeBuscada);
            ctx.SaveChanges();
        }

        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.ToList();  
        }

        public List<Habilidade> ListarComTipo()
        {
            return ctx.Habilidades.Include(h => h.IdTipoHabilidadeNavigation).ToList();
        }
    }
}

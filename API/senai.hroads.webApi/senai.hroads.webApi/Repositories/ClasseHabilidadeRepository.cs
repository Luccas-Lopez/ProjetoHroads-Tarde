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
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdUrl(short id, ClasseHabilidade classeHabilidadeAtualizada)
        {
            ClasseHabilidade classeHabilidadeBuscada = ctx.ClasseHabilidades.Find(id);

            if (classeHabilidadeAtualizada.IdClasse < 0 || classeHabilidadeAtualizada.IdHabilidade < 0)
            {
                classeHabilidadeBuscada.IdClasse = classeHabilidadeAtualizada.IdClasse;
                classeHabilidadeBuscada.IdHabilidade = classeHabilidadeAtualizada.IdHabilidade;

                ctx.ClasseHabilidades.Update(classeHabilidadeBuscada);

                ctx.SaveChanges();
            }
        }

        public ClasseHabilidade BuscarPorId(int id)
        {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).FirstOrDefault(ch => ch.IdClasseHabilidade == id);
        }

        public void Cadastrar(ClasseHabilidade novaClassseHabilidade)
        {
            ctx.ClasseHabilidades.Add(novaClassseHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            ctx.ClasseHabilidades.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<ClasseHabilidade> ListarTodos()
        {
            return ctx.ClasseHabilidades.Include(ch => ch.IdClasseNavigation).Include(ch => ch.IdHabilidadeNavigation).ToList();
        }
    }
}

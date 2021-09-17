using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdClasse, Classe classeAtualizada)
        {
            Classe classeBuscada = BuscarPorId(IdClasse);

            if (classeAtualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int IdClasse)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == IdClasse);
        }

        public void Cadastrar(Classe novoClasse)
        {
            ctx.Classes.Add(novoClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int IdClasse)
        {
            Classe classeBuscada = BuscarPorId(IdClasse);
            ctx.Classes.Remove(classeBuscada);
            ctx.SaveChanges();
        }

        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}

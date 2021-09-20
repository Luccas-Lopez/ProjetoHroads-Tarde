using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClasseHabilidade> ListarTodos();
        void Cadastrar(ClasseHabilidade novaClassseHabilidade);

        ClasseHabilidade BuscarPorId(int id);

        void AtualizarIdCorpo(short id, ClasseHabilidade classeHabilidadeAtualizada);

        void Deletar(short id);
    }
}

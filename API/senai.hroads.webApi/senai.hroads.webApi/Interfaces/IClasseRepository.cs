using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> ListarTodos();
        void Cadastrar(Classe novaClassse);

        Classe BuscarPorId(int IdClasse);

        void AtualizarIdCorpo(int IdClasse, Classe classeAtualizada);

        void Deletar(int IdClasse);
    }
}

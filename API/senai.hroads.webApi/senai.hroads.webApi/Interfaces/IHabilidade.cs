using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidade
    {
        List<Habilidade> ListarTodos();
        void Cadastrar();

        void BuscarPorId();

        void AtualizarIdCorpo();

        void Deletar();
    }
}

using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> ListarTodos();
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        TipoHabilidade BuscarPorId(int IdTipoHabilidade);

        void AtualizarIdCorpo(int IdTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizado);

        void Deletar(int IdTipoHabilidade);


    }
}

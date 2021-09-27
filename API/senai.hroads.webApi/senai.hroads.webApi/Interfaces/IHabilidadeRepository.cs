using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> ListarTodos();
        void Cadastrar(Habilidade novaHabilidade);

        Habilidade BuscarPorId(int IdHabilidade);

        void AtualizarIdUrl(int IdHabilidade, Habilidade habilidadeAtualizada);

        void Deletar(int IdHabilidade);

        List<Habilidade> ListarComTipo();
    }
}

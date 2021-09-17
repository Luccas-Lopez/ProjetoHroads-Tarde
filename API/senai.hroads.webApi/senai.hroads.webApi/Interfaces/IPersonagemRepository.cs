using senai.hroads.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> ListarTodos();
        void Cadastrar(Personagem novoPersonagem);

        Personagem BuscarPorId(int IdPersonagem);

        void AtualizarIdCorpo(int IdPersonagem, Personagem personagemAtualizado);

        void Deletar(int IdPersonagem);
    }
}

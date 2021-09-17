﻿using senai.hroads.webApi_.Contexts;
using senai.hroads.webApi_.Domains;
using senai.hroads.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi_.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdPersonagem, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = BuscarPorId(IdPersonagem);

            if (personagemAtualizado.NomePersonagem != null)
            {
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }

            ctx.Personagems.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int IdPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == IdPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int IdPersonagem)
        {
            Personagem personagemBuscado = BuscarPorId(IdPersonagem);
            ctx.Personagems.Remove(personagemBuscado);
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.ToList();
        }
    }
}

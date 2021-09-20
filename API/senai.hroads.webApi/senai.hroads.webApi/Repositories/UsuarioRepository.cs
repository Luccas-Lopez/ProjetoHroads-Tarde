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
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void AtualizarIdCorpo(int IdUsuario, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(IdUsuario);

            if (UsuarioAtualizado.NomeUsuario != null)
            {
                usuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int IdUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(IdUsuario);
            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarComTipo()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string senha, string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Senha == senha || u.Email == email);
        }
    }
}

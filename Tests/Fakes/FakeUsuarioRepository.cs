using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Fakes
{
    public class FakeUsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> usuarios;

        public FakeUsuarioRepository()
        {
            usuarios = new List<Usuario>();
        }

        public bool Criar(Usuario entity)
        {
            int count = usuarios.Count;

            usuarios.Add(entity);
            return usuarios.Count > count;
        }

        public bool Alterar(Usuario entity)
        {
            int index = usuarios.FindIndex(x => x.Id == entity.Id);
            usuarios[index] = entity;
            return true;
        }

        public bool Excluir(Usuario entity)
        {
            return usuarios.Remove(entity);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return usuarios;
        }

        public Usuario BuscarPorId(Guid id)
        {
            return usuarios.Where(x => x.Id == id).FirstOrDefault();   
        }

        public Usuario BuscarPorCodigoSenha(string codigo, string senha)
        {
            return usuarios.Where(x => x.Codigo == codigo && x.Senha == senha).FirstOrDefault();
        }
    }
}

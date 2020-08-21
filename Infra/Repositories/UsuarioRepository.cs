using Api.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;
        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        public bool Alterar(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Usuario BuscarPorCodigoSenha(string codigo, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Codigo == codigo && x.Senha == senha);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _context.Usuarios.AsNoTracking().ToList().OrderBy(x => x.Nome);
        }

        public bool Criar(Usuario entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Usuario entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }
}

using Api.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Infra.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DataContext _context;
        public MedicoRepository(DataContext context)
        {
            _context = context;
        }
        public bool Alterar(Medico entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Medico BuscarPorId(Guid id)
        {
            return _context.Medicos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Medico> BuscarTodos()
        {
            return _context.Medicos.AsNoTracking().ToList().OrderBy(x => x.Nome);
        }

        public bool Criar(Medico entity)
        {
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Medico entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Medico> BuscarPorEspecialidade(string especialidade)
        {
           var medicos = _context.Medicos.AsNoTracking().ToList();
            return medicos.Where(x => x.Especialidades.Contains(especialidade)).OrderBy(x => x.Nome);
        }

        public bool ExisteMedicoJaCadastrado(string cpf, string crm)
        {
            return _context.Medicos.AsNoTracking().Where(x => x.Cpf == cpf || x.Crm == crm).ToList().Count > 0;
        }
    }
}

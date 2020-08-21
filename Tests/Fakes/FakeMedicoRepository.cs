using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Fakes
{
    public class FakeMedicoRepository : IMedicoRepository
    {
        private readonly List<Medico> medicos;

        public FakeMedicoRepository()
        {
            medicos = new List<Medico>();
        }

        public bool Alterar(Medico entity)
        {
            int index = medicos.FindIndex(x => x.Id == entity.Id);
            medicos[index] = entity;
            return true;
        }

        public IEnumerable<Medico> BuscarPorEspecialidade(string especialidade)
        {
            return medicos.Where(x => x.Especialidades.Contains(especialidade)).ToList();
        }

        public Medico BuscarPorId(Guid id)
        {
            return medicos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Medico> BuscarTodos()
        {
            return medicos.OrderBy(x => x.Nome);
        }

        public bool Criar(Medico entity)
        {
            int count = medicos.Count;
            medicos.Add(entity);
            return count < medicos.Count;
        }

        public bool Excluir(Medico entity)
        {
            int count = medicos.Count;
            medicos.Remove(entity);
            return count > medicos.Count;
        }

        public bool ExisteMedicoJaCadastrado(string cpf, string crm)
        {
            var retorno = medicos.Where(x => x.Cpf == cpf || x.Crm == crm);
            return retorno.Count() > 0;
        }
    }
}

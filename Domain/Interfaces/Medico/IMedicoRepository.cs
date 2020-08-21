using Api.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        IEnumerable<Medico> BuscarPorEspecialidade(string especialidade);
        bool ExisteMedicoJaCadastrado(string cpf, string crm);
    }
}

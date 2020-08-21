using Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IMedicoService : IService<MedicoDTO>
    {
        IRetorno BuscarPorEspecialidade(string especialidade);
        bool ExisteMedicoJaCadastrado(string cpf, string crm);
    }
}

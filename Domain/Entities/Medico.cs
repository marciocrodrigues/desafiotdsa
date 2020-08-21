using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Medico : EntidadeBase
    {
        public Medico(string nome, string cpf, string crm, List<string> especialidades)
        {
            Nome = nome;
            Cpf = cpf;
            Crm = crm;
            Especialidades = especialidades;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Crm { get; private set; }
        public List<string> Especialidades { get; private set; }

        public void AlterarNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                Nome = nome;
            }
        }

        public void AlterarCpf(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                Cpf = cpf;
            }
        }

        public void AlterarCrm(string crm)
        {
            if (!string.IsNullOrEmpty(crm))
            {
                Crm = crm;
            }
        }

        public void AdicionarEspecialidade(string especialidade)
        {
            if (!string.IsNullOrEmpty(especialidade) && !Especialidades.Contains(especialidade))
            {
                Especialidades.Add(especialidade);
            }
        }

        
    }
}

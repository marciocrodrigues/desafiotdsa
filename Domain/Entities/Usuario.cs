using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public Usuario(string nome, string senha)
        {
            Codigo= Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
            Nome = nome;
            Senha = senha;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
    
        public void AlterarNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                Nome = nome;
            }
        }

        public void AlterarSenha(string senha)
        {
            if (!string.IsNullOrEmpty(senha))
            {
                Senha = senha;
            }
        }

    }
}

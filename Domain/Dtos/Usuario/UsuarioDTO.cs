using Api.Dtos;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class UsuarioDTO : Notifiable, IBaseDTO
    {
        public UsuarioDTO(){}

        public UsuarioDTO(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Senha para realizar acesso
        /// </summary>
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "nome é obrigatorio")
                .IsNotNullOrEmpty(Senha, "Senha", "senha é obrigatorio")
                .HasMaxLen(Nome, 120, "Nome", "nome deve conter no maximo 120 caracteres")
                .HasMaxLen(Senha, 10, "Senha", "senha deve conter no maximo 10 caracteres")
            );
        }
    }
}

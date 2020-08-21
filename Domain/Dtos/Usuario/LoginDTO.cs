using Api.Dtos;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Usuario
{
    public class LoginDTO : Notifiable, IBaseDTO
    {
        public LoginDTO(){ }
        public LoginDTO(string codigo, string senha)
        {
            Codigo = codigo;
            Senha = senha;
        }

        public string Codigo { get; set; }
        public string Senha { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Codigo, "Codigo", "Codigo obrigatorio")
                    .IsNotNullOrEmpty(Senha, "Senha", "Senha obrigatoria")
            );
        }
    }
}

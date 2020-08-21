using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class RetornoDTO : IRetorno
    {
        public RetornoDTO(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        /// <summary>
        /// Se os dados foram salvos: true ou false
        /// </summary>
        public bool Sucesso { get; set; }
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Mensagem { get; set; }
        /// <summary>
        /// Dados retornados
        /// </summary>
        public object Data { get; set; }
    }
}

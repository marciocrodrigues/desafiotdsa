using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class ErroDTO
    {
        public ErroDTO(string campo, string erro)
        {
            Campo = campo;
            Erro = erro;
        }

        public string Campo { get; set; }
        public string Erro { get; set; }
    }
}

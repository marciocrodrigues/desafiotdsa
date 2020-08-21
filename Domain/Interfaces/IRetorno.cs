using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRetorno
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }
    }
}

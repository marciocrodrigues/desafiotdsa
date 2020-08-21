using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Criar(T entity);
        bool Alterar(T entity);
        bool Excluir(T entity);
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(Guid id);
    }
}

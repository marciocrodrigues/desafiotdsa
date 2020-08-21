using Api.Dtos;
using System;

namespace Domain.Interfaces
{
    public interface IService<T> where T : class
    {
        IRetorno Criar(T input);
        IRetorno Alterar(Guid id, T input);
        bool Excluir(Guid id);
        IRetorno BuscarTodos();
        IRetorno BuscarPorId(Guid id);
    }
}

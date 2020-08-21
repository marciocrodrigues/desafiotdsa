using Api.Models;
using Domain.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUsuarioService : IService<UsuarioDTO>
    {
        IRetorno BuscarPorCodigoSenha(LoginDTO input);
    }
}

using Api.Models;
using Domain.Dtos;
using Domain.Dtos.Usuario;
using Domain.Entities;
using Domain.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class UsuarioService : Notifiable, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IRetorno Alterar(Guid id, UsuarioDTO input)
        {
            input.Validate();

            if (input.Invalid)
            {
                List<ErroDTO> erros = new List<ErroDTO>();
                erros.AddRange(input.Notifications.ToList().Select(x =>
                {
                    return new ErroDTO(x.Property, x.Message);
                }));

                return new RetornoDTO(false, "Erro ao alterar usuário", new { erros });
            }

            var usuario = _repository.BuscarPorId(id);

            usuario.AlterarNome(input.Nome);
            usuario.AlterarSenha(input.Senha);

            if (!_repository.Alterar(usuario))
            {
                return new RetornoDTO(false, "Erro ao alterar usuário na base de dados", null);
            }

            return new RetornoDTO(true, "Usuário alterado com sucesso", usuario);
        }

        public IRetorno BuscarPorCodigoSenha(LoginDTO input)
        {
            input.Validate();

            if (input.Invalid)
            {
                List<ErroDTO> erros = new List<ErroDTO>();
                erros.AddRange(input.Notifications.ToList().Select(x =>
                {
                    return new ErroDTO(x.Property, x.Message);
                }));

                return new RetornoDTO(false, "Erro ao realizar login", new { erros });
            }

            var usuario = _repository.BuscarPorCodigoSenha(input.Codigo, input.Senha);

            if(usuario != null)
            {
                return new RetornoDTO(true, "", usuario);
            }

            return new RetornoDTO(false, "Usuário não encontrado", null);
        }

        public IRetorno BuscarPorId(Guid id)
        {
            var usuario = _repository.BuscarPorId(id);

            if(usuario != null)
            {
                return new RetornoDTO(true, "", usuario);
            }

            return new RetornoDTO(false, "Usuário não encontrado", null);
        }

        public IRetorno BuscarTodos()
        {
            var usuarios = _repository.BuscarTodos();

            if (usuarios.Count() > 0)
            {
                return new RetornoDTO(true, "", usuarios);
            }

            return new RetornoDTO(false, "Usuário não encontrado", null);
        }

        public IRetorno Criar(UsuarioDTO input)
        {
            input.Validate();

            if (input.Invalid)
            {
                List<ErroDTO> erros = new List<ErroDTO>();
                erros.AddRange(input.Notifications.ToList().Select(x =>
                {
                    return new ErroDTO(x.Property, x.Message);
                }));

                return new RetornoDTO(false, "Erro ao incluir usuário", new  { erros });
            }

            var usuario = new Usuario(input.Nome, input.Senha);

            if (!_repository.Criar(usuario))
            {
                return new RetornoDTO(false, "Erro ao gravar usuário na base de dados", null);
            }

            return new RetornoDTO(true, "Usuário criado com sucesso", usuario);
        }

        public bool Excluir(Guid id)
        {
            var usuario = _repository.BuscarPorId(id);

            return _repository.Excluir(usuario);
        }
    }
}

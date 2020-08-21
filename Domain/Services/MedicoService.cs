using Api.Models;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class MedicoService : Notifiable, IMedicoService
    {
        private readonly IMedicoRepository _repository;

        public MedicoService(IMedicoRepository repository)
        {
            _repository = repository;
        }

        public IRetorno Alterar(Guid id, MedicoDTO input)
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

            var medico = _repository.BuscarPorId(id);

            medico.AlterarNome(input.Nome);
            medico.AlterarCpf(input.Cpf);
            medico.AlterarCrm(input.Crm);

            foreach (var item in input.Especialidades)
            {
                medico.AdicionarEspecialidade(item);
            }

            if (!_repository.Alterar(medico))
            {
                return new RetornoDTO(false, "Erro ao alterar usuário na base de dados", null);
            }

            return new RetornoDTO(true, "Usuário alterado com sucesso", medico);
        }

        public IRetorno BuscarPorEspecialidade(string especialidade)
        {
            var medicos = _repository.BuscarPorEspecialidade(especialidade);

            return new RetornoDTO(true, "", medicos);
        }

        public IRetorno BuscarPorId(Guid id)
        {
            var medico = _repository.BuscarPorId(id);

            return new RetornoDTO(true, "", medico);
        }

        public IRetorno BuscarTodos()
        {
            var medicos = _repository.BuscarTodos();

            return new RetornoDTO(true, "", medicos);
        }

        public IRetorno Criar(MedicoDTO input)
        {
            input.Validate();

            if (input.Invalid)
            {
                List<ErroDTO> erros = new List<ErroDTO>();
                erros.AddRange(input.Notifications.ToList().Select(x =>
                {
                    return new ErroDTO(x.Property, x.Message);
                }));

                return new RetornoDTO(false, "Erro ao incluir usuário", new { erros });
            }

            if(ExisteMedicoJaCadastrado(input.Cpf, input.Crm))
            {
                return new RetornoDTO(false, "Já existe médico cadastrado para o cpf ou crm informados", null);
            }

            var medico = new Medico(input.Nome, input.Cpf, input.Crm, input.Especialidades);

            if (!_repository.Criar(medico))
            {
                return new RetornoDTO(false, "Erro ao gravar usuário na base de dados", null);
            }

            return new RetornoDTO(true, "Usuário criado com sucesso", medico);
        }

        public bool Excluir(Guid id)
        {
            var medico = _repository.BuscarPorId(id);

            return _repository.Excluir(medico);
        }

        public bool ExisteMedicoJaCadastrado(string cpf, string crm)
        {
            return _repository.ExisteMedicoJaCadastrado(cpf, crm);
        }
    }
}

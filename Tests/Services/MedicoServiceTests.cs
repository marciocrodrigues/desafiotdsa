using Api.Models;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Fakes;

namespace Tests.Services
{
    [TestClass]
    public class MedicoServiceTests
    {
        private readonly MedicoService _service;
        private MedicoDTO _input;
        private MedicoDTO _inputInvalido;
        private List<string> _especialidades;

        public MedicoServiceTests()
        {
            _service = new MedicoService(new FakeMedicoRepository());

            _especialidades = new List<string>() { "Ortopedia", "Pediatria" };

            _input = new MedicoDTO("Medico Teste", "12345678909", "123456", _especialidades);

            _inputInvalido = new MedicoDTO("", "123", "", new List<string>());
        }

        [TestMethod]
        public void Cadastra_Novo_Medico()
        {
            var retorno = _service.Criar(_input);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Nao_Cadastrar_Medico_Com_Cpf_Ou_Crm_Ja_Utilizados()
        {
            var novoMedico = new MedicoDTO("Medico Teste", "12345678909", "123456", _especialidades);
            var retorno1 = _service.Criar(_input);
            var retorno2 = _service.Criar(novoMedico);

            Assert.AreEqual(true, retorno1.Sucesso);
            Assert.AreEqual(false, retorno2.Sucesso);
        }

        [TestMethod]
        public void Nao_Cadastrar_Medico_Sem_As_Informacoes_Obrigatorias()
        {
            var retorno = _service.Criar(_inputInvalido);
            Assert.AreEqual(false, retorno.Sucesso);
        }

        [TestMethod]
        public void Buscar_Medico_Por_Id()
        {
            var retorno = _service.Criar(new MedicoDTO("Medico1", "30163604037", "12345", new List<string>() { "Ortopedia", "Pneumologia" }));

            var medico = _service.BuscarPorId(((Medico)retorno.Data).Id);

            Assert.AreEqual(true, medico.Data != null);

        }

        [TestMethod]
        public void Listar_Todos_Os_Medicos()
        {
            var retorno = _service.Criar(new MedicoDTO("Medico1", "30163604037", "12345", new List<string>() { "Ortopedia", "Pneumologia" }));
            var retorno2 = _service.Criar(_input);

            var medicos = (IEnumerable<Medico>)_service.BuscarTodos().Data;

            Assert.AreEqual(true, medicos.Count() == 2);
        }

        [TestMethod]
        public void Listar_Medico_Por_Especialidade()
        {
            var retorno = _service.Criar(new MedicoDTO("Medico1", "30163604037", "12345", new List<string>() { "Ortopedia", "Pneumologia" }));
            var retorno2 = _service.Criar(_input);

            var medicos = (IEnumerable<Medico>)_service.BuscarPorEspecialidade("Ortopedia").Data;
            var medicos2 = (IEnumerable<Medico>)_service.BuscarPorEspecialidade("Pneumologia").Data;

            Assert.AreEqual(true, medicos.Count() == 2);
            Assert.AreEqual(true, medicos2.Count() == 1);
        }

        [TestMethod]
        public void Alterar_Medico()
        {
            var medico = (Medico)_service.Criar(_input).Data;

            var nome = medico.Nome;

            var input = new MedicoDTO("Medico2", medico.Cpf, medico.Crm, medico.Especialidades);

            var medicoAlterado = (Medico)_service.Alterar(medico.Id, input).Data;

            Assert.AreEqual(true, medico.Id == medicoAlterado.Id);
            Assert.AreEqual(true, nome != medicoAlterado.Nome);
        }
    }
}

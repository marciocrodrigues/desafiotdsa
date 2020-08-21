using Api.Models;
using Domain.Dtos.Usuario;
using Domain.Entities;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Fakes;

namespace Tests.Services
{
    [TestClass]
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _service;
        private UsuarioDTO _input;
        private LoginDTO _login;


        public UsuarioServiceTests()
        {
            _service = new UsuarioService(new FakeUsuarioRepository());
            _input = new UsuarioDTO("usuarioteste", "123456");
        }

        [TestMethod]
        public void Criar_Usuario()
        {
            var retorno = _service.Criar(_input);
            Assert.AreEqual(true, retorno.Sucesso);
        }

        [TestMethod]
        public void Buscar_Usuario_Por_Id()
        {
            var retorno = (Usuario)_service.Criar(_input).Data;

            var Id = retorno.Id;

            var usuario = (Usuario)_service.BuscarPorId(Id).Data;

            Assert.AreEqual(true, Id == usuario.Id);
        }

        [TestMethod]
        public void Buscar_Por_Codigo_E_Senha()
        {
            var retorno = (Usuario)_service.Criar(_input).Data;

            _login = new LoginDTO(retorno.Codigo, retorno.Senha);

            var usuario = (Usuario)_service.BuscarPorCodigoSenha(_login).Data;

            Assert.AreEqual(false, string.IsNullOrEmpty(usuario.Codigo));

        }
    }
}

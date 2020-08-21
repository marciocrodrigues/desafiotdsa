using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Config;
using Domain.Dtos.Usuario;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/login")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public LoginController(IUsuarioService service)
        {
            _service = service;
        }


        /// <summary>
        /// Gerar token de autenticação
        /// </summary>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("")]
        [HttpPost]
        public IActionResult Criar([FromBody]LoginDTO input)
        {
            var retorno = _service.BuscarPorCodigoSenha(input);

            if (retorno.Sucesso)
            {
                var usuario = (Usuario)retorno.Data;
                var token = Token.GerarToken(usuario);

                return Ok(new { usuario = usuario.Nome, token });
            }

            return BadRequest(retorno.Data);
        }
    }
}

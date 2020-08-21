using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Incluir novo usuario
        /// </summary>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public IActionResult Criar([FromBody] UsuarioDTO input)
        {
            var retorno = _service.Criar(input);

            if (retorno.Sucesso)
            {
                return Ok(retorno.Data);
            }

            return BadRequest(retorno.Data);
        }

        /// <summary>
        /// Alterar informações do usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("{id:Guid}")]
        [HttpPut]
        public IActionResult Alterar(Guid id,[FromBody]UsuarioDTO input)
        {
            var retorno = _service.Alterar(id, input);

            if (retorno.Sucesso)
            {
                return Ok(retorno.Data);
            }

            return BadRequest(retorno.Data);
        }

        /// <summary>
        /// Listar Todos Usuários
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.BuscarTodos().Data);
        }

        /// <summary>
        /// Buscar usuário pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Authorize]
        [Route("{id:Guid}")]
        [HttpGet]
        public IActionResult ListarPorId(Guid id)
        {
            return Ok(_service.BuscarPorId(id).Data);
        }

        /// <summary>
        /// Exluir usuário
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não autorizado</response>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("{id:Guid}")]
        [HttpDelete]
        public IActionResult Excluir(Guid id)
        {

            if (_service.Excluir(id))
            {
                return Ok("Usuário removido com sucesso");
            }

            return BadRequest("Erro ao tentar excluir usuário");
        }
    }
}

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
    [Route("v1/medico")]
    [Authorize]
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoService _service;

        public MedicoController(IMedicoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Incluir novo medico
        /// </summary>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("")]
        [HttpPost]
        public IActionResult Criar([FromBody]MedicoDTO input)
        {
            var retorno = _service.Criar(input);

            if (retorno.Sucesso)
            {
                return Ok(retorno.Data);
            }

            return BadRequest(retorno.Data);
        }

        /// <summary>
        /// Alterar informações do medico
        /// </summary>
        /// <param name="input"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("{id:Guid}")]
        [HttpPut]
        public IActionResult Alterar(Guid id, [FromBody]MedicoDTO input)
        {
            var retorno = _service.Alterar(id, input);

            if (retorno.Sucesso)
            {
                return Ok(retorno.Data);
            }

            return BadRequest(retorno.Data);
        }

        /// <summary>
        /// Listar todos os medicos
        /// </summary>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_service.BuscarTodos().Data);
        }

        /// <summary>
        /// Buscar medico pelo Identificador
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [Route("{id:Guid}")]
        [HttpGet]
        public IActionResult BuscarPorId(Guid id)
        {
            return Ok(_service.BuscarPorId(id).Data);
        }

        /// <summary>
        /// Exluir medico
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("{id:Guid}")]
        [HttpDelete]
        public IActionResult Excluir(Guid id)
        {

            if (_service.Excluir(id))
            {
                return Ok("Medico removido com sucesso");
            }

            return BadRequest("Erro ao tentar excluir medico");
        }

        /// <summary>
        /// Buscar medico por especialidade
        /// </summary>
        /// <param name="especialidade"></param>
        /// <response code="200">Sucesso no retorno</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="401">Não Autorizado</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(IRetorno), 200)]
        [Route("{especialidade}")]
        [HttpGet]
        public IActionResult BuscarPorEspecialidade(string especialidade)
        {
            return Ok(_service.BuscarPorEspecialidade(especialidade).Data);
        }

    }
}

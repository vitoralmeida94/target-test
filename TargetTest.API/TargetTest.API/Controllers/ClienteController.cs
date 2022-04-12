using Microsoft.AspNetCore.Mvc;
using System;
using TargetTest.Application.InputModels;
using TargetTest.Application.Services.Interfaces;
using TargetTest.Core.Entities;
using TargetTest.Core.Enums;

namespace TargetTest.API.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogService _logService;
        public ClienteController(IClienteService clienteService, ILogService logService)
        {
            _clienteService = clienteService;
            _logService = logService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CriacaoClienteInputModel inputModel)
        {
            try
            {
                var clienteCriado = _clienteService.Inserir(inputModel);
                return Ok(clienteCriado);
            }
            catch (System.Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpPost("{id}/vip")]
        public IActionResult PostVIP([FromRoute] int id)
        {
            try
            {
                _clienteService.AplicarVIP(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpGet("periodo/{dataInicio}/{dataFim}")]
        public IActionResult GetClientePeriodo([FromRoute] DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio > dataFim)
            {
                return BadRequest("A data início não pode ser maior do que a data fim.");
            }
            var inputModel = new ListaPeriodoClienteInputModel { DataInicio = dataInicio, DataFim = dataFim };
            try
            {
                var clientesViewModel = _clienteService.ListaClientesPorPeriodo(inputModel);
                return Ok(clientesViewModel);
            }
            catch (Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpGet("renda/{valor}")]
        public IActionResult GetClientePorRenda([FromRoute] decimal valor)
        {
            try
            {
                if (valor < 0)
                {
                    return BadRequest("O valor da renda não pode ser menor do que zero.");
                }

                var clientesViewModel = _clienteService.ListaPelaRenda(valor,false);
                return Ok(clientesViewModel);
            }
            catch (Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpGet("{id}/endereco")]
        public IActionResult GetEnderecoCliente([FromRoute] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Id de cliente precisa ser válido.");
                
                var clienteEndereco = _clienteService.ListaEnderecoCliente(id);

                if (clienteEndereco is null)
                    return NotFound("Cliente não foi encontrado");

                return Ok(clienteEndereco);
            }
            catch (Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpPut("{id}/endereco")]
        public IActionResult PutEnderecoCliente([FromRoute] int id,[FromBody] AtualizaEnderecoInputModel inputModel)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Id de cliente precisa ser válido.");
                var resultado = _clienteService.AtualizaEnderecoCliente(id,inputModel);
                if (resultado)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("O Cliente não foi encontrado para atualizar o endereço");
                }
            }
            catch (Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }

        [HttpGet("podemvip")]
        public IActionResult GetClientePodemVIP()
        {
            try
            {
                var clientesViewModel = _clienteService.ListaPelaRenda((decimal)PlanoValorEnum.VIP,true);
                return Ok(clientesViewModel);
            }
            catch (Exception ex)
            {
                _logService.Registra(new Log(ex.Message));
                return StatusCode(500, "Ocorreu um erro interno.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.InputModels;
using TargetTest.Application.Services.Interfaces;
using TargetTest.Application.ViewModels;
using TargetTest.Core.Entities;
using TargetTest.Core.Repositories;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.Application.Services.Implemetations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPlanoRepository _planoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public ClienteService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, IPlanoRepository planoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _planoRepository = planoRepository;
        }

        public ClienteCriadoViewModel Inserir(CriacaoClienteInputModel inputModel)
        {
            var cliente = new Cliente(inputModel.NomeCompleto,inputModel.DataNascimento,inputModel.CPF,inputModel.Renda,null);
            cliente = _clienteRepository.Insert(cliente);

            var enderecoCliente = new Endereco(cliente.Id,inputModel.Logradouro, inputModel.Bairro, inputModel.CEP,inputModel.Cidade, inputModel.UF, inputModel.Complemento);
            _enderecoRepository.Insert(enderecoCliente);

            return new ClienteCriadoViewModel(cliente.Id, cliente.NomeCompleto, true, cliente.Renda);

        }

        public List<ClienteViewModel> ListaClientesPorPeriodo(ListaPeriodoClienteInputModel inputModel)
        {
            var clientes = _clienteRepository.GetAll();
            clientes = clientes.Where(x => x.DataCriacao >= inputModel.DataInicio && x.DataCriacao <= inputModel.DataFim).ToList();

            var clientesViewModel = clientes.Select(c => new ClienteViewModel(c.Id, c.NomeCompleto, c.Cpf, c.Renda)).ToList();

            return clientesViewModel;
        }

        public List<ClienteViewModel> ListaPelaRenda(decimal renda)
        {
            var clientes = _clienteRepository.GetAll();
            clientes = clientes.Where(x => x.Renda >= renda).ToList();

            var clientesViewModel = clientes.Select(c => new ClienteViewModel(c.Id, c.NomeCompleto, c.Cpf, c.Renda)).ToList();

            return clientesViewModel;
        }

        public void AplicarVIP(int clienteId)
        {
            var planoVIP = _planoRepository.GetPlanoVIP();
            var cliente = _clienteRepository.GetById(clienteId);
            cliente.AplicaPlano(planoVIP.Id);
            _clienteRepository.Update(cliente);
        }

        public bool AtualizaEnderecoCliente(int id,AtualizaEnderecoInputModel inputModel)
        {
            if (_clienteRepository.GetById(id) != null)
            {
                var enderecoCliente = _enderecoRepository.GetByClienteId(id);
                enderecoCliente.AtualizaEndereco(inputModel.Logradouro, inputModel.Bairro, inputModel.CEP, inputModel.Cidade, inputModel.Uf, inputModel.Complemento);
                _enderecoRepository.Update(enderecoCliente);

                return true;
            }
            else
            {
                return false;
            }

        }

        public ClienteEnderecoViewModel ListaEnderecoCliente(int clienteId)
        {
            var cliente = _clienteRepository.GetById(clienteId);
            if (cliente == null)
                return null;
            var endereco = _enderecoRepository.GetByClienteId(clienteId);

            return new ClienteEnderecoViewModel(clienteId, cliente.NomeCompleto, endereco.Logradouro, endereco.Bairro,endereco.Cep, endereco.Cidade, endereco.Uf, endereco.Complemento);
        }
    }
}

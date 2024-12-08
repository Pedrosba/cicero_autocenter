using AutoMapper;
using cicero_autocenterAPI.DTOs;
using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using cicero_autocenterAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cicero_autocenterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.SelecionarTodos();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO_Cadastro clienteDTO_Cadastro)
        {
            if (clienteDTO_Cadastro == null)
            {
                return BadRequest("clienteDTO_Cadastro é obrigatório.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO_Cadastro);
            _clienteRepository.Incluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o cliente.");
        }


        [HttpPut]
        public async Task<ActionResult> AlterarCliente(ClienteDTO_Alterar clienteDTO_Alterar)
        {
            if (clienteDTO_Alterar.ClienteId == 0)
            {
                return BadRequest("Não é possivel alterar o cliente. É preciso informar o ID.");
            }

            var clienteExiste = await _clienteRepository.SelecionarByPk(clienteDTO_Alterar.ClienteId);
            if (clienteExiste == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO_Alterar);
            _clienteRepository.Alterar(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o cliente.");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluido com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o cliente.");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> Selecionar(int id)
        {

            var cliente = await _clienteRepository.SelecionarByPk(id);
            {

                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

                return Ok(clienteDTO);
            }
        }
    }
}

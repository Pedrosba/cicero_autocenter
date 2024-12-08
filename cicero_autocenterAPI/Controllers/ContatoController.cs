using AutoMapper;
using cicero_autocenterAPI.DTOs;
using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatoDTO>>> GetContatos()
        {
            var contatos = await _contatoRepository.SelecionarTodos();
            var contatosDTO = _mapper.Map<IEnumerable<ContatoDTO>>(contatos);
            return Ok(contatosDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarContato(ContatoDTO_Cadastro contatoDTO_Cadastro)
        {
            if (contatoDTO_Cadastro == null)
            {
                return BadRequest("Contato é obrigatório.");
            }

            var contato = _mapper.Map<Contato>(contatoDTO_Cadastro);
            _contatoRepository.Incluir(contato);

            if (await _contatoRepository.SaveAllAsync())
            {
                return Ok("Contato cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o contato.");
        }

        [HttpPut]
        public async Task<ActionResult> AlterarContato(ContatoDTO_Alterar contatoDTO_Alterar)
        {
            if (contatoDTO_Alterar.Idcliente == 0)
            {
                return BadRequest("Não é possível alterar o contato. É preciso informar o ID.");
            }

            var contatoExiste = await _contatoRepository.SelecionarByPk(contatoDTO_Alterar.Idcliente);
            if (contatoExiste == null)
            {
                return NotFound("Contato não encontrado.");
            }

            var contato = _mapper.Map<Contato>(contatoDTO_Alterar);
            _contatoRepository.Alterar(contato);

            if (await _contatoRepository.SaveAllAsync())
            {
                return Ok("Contato alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o contato.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirContato(int id)
        {
            var contato = await _contatoRepository.SelecionarByPk(id);

            if (contato == null)
            {
                return NotFound("Contato não encontrado");
            }

            _contatoRepository.Excluir(contato);

            if (await _contatoRepository.SaveAllAsync())
            {
                return Ok("Contato excluído com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o contato.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var contato = await _contatoRepository.SelecionarByPk(id);
            if (contato == null)
            {
                return NotFound("Contato não encontrado.");
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contato);

            return Ok(contatoDTO);
        }
    }
}

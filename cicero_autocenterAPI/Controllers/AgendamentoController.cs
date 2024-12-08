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
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDTO>>> GetAgendamentos()
        {
            var agendamentos = await _agendamentoRepository.SelecionarTodos();
            var agendamentosDTO = _mapper.Map<IEnumerable<AgendamentoDTO>>(agendamentos);
            return Ok(agendamentosDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarAgendamento(AgendamentoDTO_Cadastro agendamentoDTO_Cadastro)
        {
            if (agendamentoDTO_Cadastro == null)
            {
                return BadRequest("Agendamento é obrigatório.");
            }

            var agendamento = _mapper.Map<Agendamento>(agendamentoDTO_Cadastro);
            _agendamentoRepository.Incluir(agendamento);

            if (await _agendamentoRepository.SaveAllAsync())
            {
                return Ok("Agendamento cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o agendamento.");
        }

        [HttpPut]
        public async Task<ActionResult> AlterarAgendamento(AgendamentoDTO_Alterar agendamentoDTO_Alterar)
        {
            if (agendamentoDTO_Alterar.Idagendamento == 0)
            {
                return BadRequest("Não é possível alterar o agendamento. É preciso informar o ID.");
            }

            var agendamentoExiste = await _agendamentoRepository.SelecionarByPk(agendamentoDTO_Alterar.Idagendamento);
            if (agendamentoExiste == null)
            {
                return NotFound("Agendamento não encontrado.");
            }

            var agendamento = _mapper.Map<Agendamento>(agendamentoDTO_Alterar);
            _agendamentoRepository.Alterar(agendamento);

            if (await _agendamentoRepository.SaveAllAsync())
            {
                return Ok("Agendamento alterado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar o agendamento.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAgendamento(int id)
        {
            var agendamento = await _agendamentoRepository.SelecionarByPk(id);

            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado");
            }

            _agendamentoRepository.Excluir(agendamento);

            if (await _agendamentoRepository.SaveAllAsync())
            {
                return Ok("Agendamento excluído com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o agendamento.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var agendamento = await _agendamentoRepository.SelecionarByPk(id);
            if (agendamento == null)
            {
                return NotFound("Agendamento não encontrado.");
            }

            var agendamentoDTO = _mapper.Map<AgendamentoDTO>(agendamento);

            return Ok(agendamentoDTO);
        }
    }
}

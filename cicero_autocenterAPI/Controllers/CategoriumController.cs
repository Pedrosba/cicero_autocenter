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
    public class CategoriumController : ControllerBase
    {
        private readonly ICategoriumRepository _categoriumRepository;
        private readonly IMapper _mapper;

        public CategoriumController(ICategoriumRepository categoriumRepository, IMapper mapper)
        {
            _categoriumRepository = categoriumRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriumDTO>>> GetCategorias()
        {
            var categorias = await _categoriumRepository.SelecionarTodos();
            var categoriasDTO = _mapper.Map<IEnumerable<CategoriumDTO>>(categorias);
            return Ok(categoriasDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCategorium(CategoriumDTO_Cadastro categoriumDTO_Cadastro)
        {
            if (categoriumDTO_Cadastro == null)
            {
                return BadRequest("Categoria é obrigatória.");
            }

            var categorium = _mapper.Map<Categorium>(categoriumDTO_Cadastro);
            _categoriumRepository.Incluir(categorium);

            if (await _categoriumRepository.SaveAllAsync())
            {
                return Ok("Categoria cadastrada com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar a categoria.");
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCategorium(CategoriumDTO_Alterar categoriumDTO_Alterar)
        {
            if (categoriumDTO_Alterar.CategoriaId == 0)
            {
                return BadRequest("Não é possível alterar a categoria. É preciso informar o ID.");
            }

            var categoriumExiste = await _categoriumRepository.SelecionarByPk(categoriumDTO_Alterar.CategoriaId);
            if (categoriumExiste == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            var categorium = _mapper.Map<Categorium>(categoriumDTO_Alterar);
            _categoriumRepository.Alterar(categorium);

            if (await _categoriumRepository.SaveAllAsync())
            {
                return Ok("Categoria alterada com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao alterar a categoria.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCategorium(int id)
        {
            var categorium = await _categoriumRepository.SelecionarByPk(id);

            if (categorium == null)
            {
                return NotFound("Categoria não encontrada");
            }

            _categoriumRepository.Excluir(categorium);

            if (await _categoriumRepository.SaveAllAsync())
            {
                return Ok("Categoria excluída com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir a categoria.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var categorium = await _categoriumRepository.SelecionarByPk(id);
            if (categorium == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            var categoriumDTO = _mapper.Map<CategoriumDTO>(categorium);

            return Ok(categoriumDTO);
        }
    }
}

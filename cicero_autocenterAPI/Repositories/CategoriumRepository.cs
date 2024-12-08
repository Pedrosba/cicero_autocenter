using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Repositories
{
    public class CategoriumRepository : ICategoriumRepository
    {
        private readonly cicero_injecao_eletronica_autocenter_Context _context;

        public CategoriumRepository(cicero_injecao_eletronica_autocenter_Context context)
        {
            _context = context;
        }

        public void Incluir(Categorium categorium)
        {
            _context.Categoria.Add(categorium);
        }

        public void Alterar(Categorium categorium)
        {
            _context.Entry(categorium).State = EntityState.Modified;
        }

        public void Excluir(Categorium categorium)
        {
            _context.Categoria.Remove(categorium);
        }

        public async Task<Categorium> SelecionarByPk(int id)
        {
            return await _context.Categoria.FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public async Task<IEnumerable<Categorium>> SelecionarTodos()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

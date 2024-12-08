using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly cicero_injecao_eletronica_autocenter_Context _context;

        public ContatoRepository(cicero_injecao_eletronica_autocenter_Context context)
        {
            _context = context;
        }

        public void Incluir(Contato contato)
        {
            _context.Contatos.Add(contato);
        }

        public void Alterar(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
        }

        public void Excluir(Contato contato)
        {
            _context.Contatos.Remove(contato);
        }

        public async Task<Contato> SelecionarByPk(int id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(c => c.Idcliente == id);
        }

        public async Task<IEnumerable<Contato>> SelecionarTodos()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

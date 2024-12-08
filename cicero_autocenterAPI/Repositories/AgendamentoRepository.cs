using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly cicero_injecao_eletronica_autocenter_Context _context;

        public AgendamentoRepository(cicero_injecao_eletronica_autocenter_Context context)
        {
            _context = context;
        }

        public void Incluir(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
        }

        public void Alterar(Agendamento agendamento)
        {
            _context.Entry(agendamento).State = EntityState.Modified;
        }

        public void Excluir(Agendamento agendamento)
        {
            _context.Agendamentos.Remove(agendamento);
        }

        public async Task<Agendamento> SelecionarByPk(int id)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(a => a.Idagendamento == id);
        }

        public async Task<IEnumerable<Agendamento>> SelecionarTodos()
        {
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

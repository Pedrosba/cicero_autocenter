using cicero_autocenterAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        void Incluir(Agendamento agendamento);
        void Alterar(Agendamento agendamento);
        void Excluir(Agendamento agendamento);
        Task<Agendamento> SelecionarByPk(int id);
        Task<IEnumerable<Agendamento>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}

using cicero_autocenterAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Interfaces
{
    public interface IContatoRepository
    {
        void Incluir(Contato contato);
        void Alterar(Contato contato);
        void Excluir(Contato contato);
        Task<Contato> SelecionarByPk(int id);
        Task<IEnumerable<Contato>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}

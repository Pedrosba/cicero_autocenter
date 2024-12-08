using cicero_autocenterAPI.Models;

namespace cicero_autocenterAPI.Interfaces
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        void Alterar (Cliente cliente);
        void Excluir (Cliente cliente);
        Task<Cliente> SelecionarByPk (int id);
        Task<IEnumerable<Cliente>> SelecionarTodos ();
        Task<bool> SaveAllAsync();


    }
}
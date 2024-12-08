using cicero_autocenterAPI.Interfaces;
using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace cicero_autocenterAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly cicero_injecao_eletronica_autocenter_Context _Context;
        private object _context;

        public ClienteRepository(cicero_injecao_eletronica_autocenter_Context context) => _Context = context;

        public void Alterar(Cliente cliente)
        {
            _Context.Entry(cliente).State = EntityState.Modified;
        }

        public void Excluir(Cliente cliente)
        {
            _Context.Cliente.Remove(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            _Context.Cliente.Add(cliente);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _Context.SaveChangesAsync() >0;
        }

        public async Task<Cliente> SelecionarByPk(int id)
        {
            return await _Context.Cliente.Where(x => x.ClienteId == id).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {
            return await _Context.Cliente.ToListAsync();
        }

      //  public Task<Cliente> SelecionarByPk(int id)
      // {
      //      throw new NotImplementedException();
      //  }
    }
}

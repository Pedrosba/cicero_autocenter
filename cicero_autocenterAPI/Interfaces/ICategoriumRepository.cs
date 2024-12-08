using cicero_autocenterAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cicero_autocenterAPI.Interfaces
{
    public interface ICategoriumRepository
    {
        void Incluir(Categorium categorium);
        void Alterar(Categorium categorium);
        void Excluir(Categorium categorium);
        Task<Categorium> SelecionarByPk(int id);
        Task<IEnumerable<Categorium>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        #region "Metodos Sincronos"
        IEnumerable<T> GetAll();
        T Get(string Id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(string Id);
        #endregion

        #region "Metodos Asincronos"
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string Id);
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);
        #endregion
    }
}

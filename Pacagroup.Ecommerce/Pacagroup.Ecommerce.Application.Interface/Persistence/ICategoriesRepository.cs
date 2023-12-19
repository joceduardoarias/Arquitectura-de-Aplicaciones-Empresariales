using Pacagroup.Ecommerce.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}

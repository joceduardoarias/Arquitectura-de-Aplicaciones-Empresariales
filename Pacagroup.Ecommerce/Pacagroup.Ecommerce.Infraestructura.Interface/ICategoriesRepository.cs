using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAll();
    }
}

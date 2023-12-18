using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface
{
    public interface ICategoriesApplication
    {
       Task<Response<IEnumerable<CategoriesDto>>> GetAll();
    }
}

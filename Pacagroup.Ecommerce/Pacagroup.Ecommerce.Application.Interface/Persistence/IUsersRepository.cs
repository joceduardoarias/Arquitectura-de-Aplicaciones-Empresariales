using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string userName, string password);        
    }
}

using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User Authenticate(string userName, string password);        
    }
}

using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface.UseCase
{
    public interface IUsersApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
    }
}

using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infraestructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {   
        private readonly IUnitOfWork _unitOfWork;
        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Users Authenticate(string userName, string password)
        {
            return _unitOfWork.usersRepository.Authenticate(userName, password);
        }
    }
}

using Pacagroup.Ecommerce.Infraestructura.Interface;
using Pacagroup.Ecommerce.Infraestructure.Interface;

namespace Pacagroup.Ecommerce.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
       
        public ICustomersRepository customersRepository { get; }

        public IUsersRepository usersRepository { get; }
        public UnitOfWork(ICustomersRepository customers, IUsersRepository users)
        {
            customersRepository = customers;
            usersRepository = users;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}

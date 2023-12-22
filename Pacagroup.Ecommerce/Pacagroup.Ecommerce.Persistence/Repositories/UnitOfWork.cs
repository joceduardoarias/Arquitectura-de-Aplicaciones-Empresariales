using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICustomersRepository customersRepository { get; }

        public IUsersRepository usersRepository { get; }

        public ICategoriesRepository categoriesRepository { get; }

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories)
        {
            customersRepository = customers;
            usersRepository = users;
            categoriesRepository = categories;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}

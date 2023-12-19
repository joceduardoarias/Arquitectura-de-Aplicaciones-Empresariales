using System;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository customersRepository { get; }
        IUsersRepository usersRepository { get; }
        ICategoriesRepository categoriesRepository { get; }
    }
}

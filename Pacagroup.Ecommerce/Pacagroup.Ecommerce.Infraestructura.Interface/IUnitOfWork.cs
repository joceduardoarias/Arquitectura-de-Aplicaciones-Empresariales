using Pacagroup.Ecommerce.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository customersRepository { get; }
        IUsersRepository usersRepository { get; }
    }
}

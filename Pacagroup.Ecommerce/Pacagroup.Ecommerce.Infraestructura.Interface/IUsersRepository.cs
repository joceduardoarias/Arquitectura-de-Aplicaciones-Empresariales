using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Infraestructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string userName, string password);        
    }
}

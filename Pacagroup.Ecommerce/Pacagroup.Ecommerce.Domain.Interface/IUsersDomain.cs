using Pacagroup.Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string userName, string password);
    }
}

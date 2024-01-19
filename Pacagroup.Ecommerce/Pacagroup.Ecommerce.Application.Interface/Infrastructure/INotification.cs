using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.Infrastructure
{
    public interface INotification
    {
        Task<bool> SendMailAsync(string subject, string body, CancellationToken cancellationToken = new ());
    }
}

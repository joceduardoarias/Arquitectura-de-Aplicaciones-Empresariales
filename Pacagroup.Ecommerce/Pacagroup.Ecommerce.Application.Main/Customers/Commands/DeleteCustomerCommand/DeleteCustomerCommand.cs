using MediatR;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.DeleteCustomerCommand;

public sealed class DeleteCustomerCommand : IRequest<Response<bool>>
{
    public string CustomerId { get; set; }
}

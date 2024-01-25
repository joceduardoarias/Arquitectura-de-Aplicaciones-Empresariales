using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetCustomerQuery;

public sealed record GetCustomerQuery : IRequest<Response<CustomerDto>>
{
    public string CustomerId { get; set; }
}

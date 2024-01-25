using MediatR;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.DeleteCustomerCommand;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;        

    public DeleteCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;            
    }

    public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<bool>();

        response.Data = await _unitOfWork.customersRepository.DeleteAsync(request.CustomerId);
        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = "Success";
        }


        return response;
    }
}

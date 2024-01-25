using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.CreateCustomerCommand;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<bool>();

        var customerEntity = _mapper.Map<Customer>(request);
        response.Data = await _unitOfWork.customersRepository.InsertAsync(customerEntity);
        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = "Success";
            //_logger.LogInformation("Customer insertado correctamente");
        }

        return response;
    }
}

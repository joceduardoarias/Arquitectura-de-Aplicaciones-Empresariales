using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetCustomerQuery;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Response<CustomerDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<CustomerDto>();

        response.Data = _mapper.Map<CustomerDto>(await _unitOfWork.customersRepository.GetAsync(request.CustomerId));
        if (response.Data != null)
        {
            response.IsSuccess = true;
            response.Message = "Success";
            //_logger.LogInformation("Customer obtenido correctamente");
        }

        return response;
    }
}

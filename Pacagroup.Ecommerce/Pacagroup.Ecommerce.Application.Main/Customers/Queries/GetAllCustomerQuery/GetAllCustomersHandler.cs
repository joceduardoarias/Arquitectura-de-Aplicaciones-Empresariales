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

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetAllCustomerQuery;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomerQuery, Response<IEnumerable<CustomerDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCustomersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = new Response<IEnumerable<CustomerDto>>();

        var customers = _unitOfWork.customersRepository.GetAll();
        response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
        if (response.Data.Any())
        {
            response.IsSuccess = true;
            response.Message = "Success";
            //_logger.LogInformation("Customers obtenidos correctamente");
        }

        return response;
    }
}

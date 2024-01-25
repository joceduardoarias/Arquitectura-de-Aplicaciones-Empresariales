using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetCustomerWithPagination;

public class GetCustomerWithPaginationHandler : IRequestHandler<GetCustomerWithPaginationQuery, ResponsePagination<IEnumerable<CustomerDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerWithPaginationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponsePagination<IEnumerable<CustomerDto>>> Handle(GetCustomerWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var response = new ResponsePagination<IEnumerable<CustomerDto>>();

        var count = await _unitOfWork.customersRepository.CountAsync();
        var custOmers = await _unitOfWork.customersRepository.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
        response.Data = _mapper.Map<IEnumerable<CustomerDto>>(custOmers);

        if (response.Data != null)
        {
            response.PageNumber = request.PageNumber;
            response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
            response.TotalCount = count;
            response.IsSuccess = true;
            response.Message = "Consulta Paginada Exitosa!!!";
        }

        return response;
    }
}

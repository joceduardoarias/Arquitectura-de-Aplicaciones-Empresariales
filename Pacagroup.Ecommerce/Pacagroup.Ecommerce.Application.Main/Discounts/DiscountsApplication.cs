using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCase.Discounts;

public class DiscountsApplication : IDiscountsApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IloggerApp<DiscountsApplication> _logger;
    private readonly DiscountDotValidator _discountDtoValidator;

    public DiscountsApplication(IUnitOfWork unitOfWork, IMapper mapper, IloggerApp<DiscountsApplication> logger, DiscountDotValidator discountDtoValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _discountDtoValidator = discountDtoValidator;
    }

    public async Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken CancellationToken = default)
    {
        var response = new Response<bool>();

        try
        {
            var validation = await _discountDtoValidator.ValidateAsync(discountDto, CancellationToken);
            
            if (!validation.IsValid)
            {
                response.Message = "Error de validación";
                response.Errors = validation.Errors;
                return response;
            }
            
            var discountEntity = _mapper.Map<Discount>(discountDto);
            await _unitOfWork.discountRepository.InsertAsync(discountEntity);

            response.Data = await _unitOfWork.Save(CancellationToken)>0; /* Si es mayor a 0 es true */  //TODO buscar como mejorar este control.
                
            if (response.Data is true)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                _logger.LogInformation("Discount creado correctamente");                    
            }
           
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }

    public async Task<Response<bool>> Delete(int id, CancellationToken CancellationToken = default)
    {
        var response = new Response<bool>();

        try
        {
            await _unitOfWork.discountRepository.DeleteAsync(id.ToString());
            
            response.Data = await _unitOfWork.Save(CancellationToken) > 0; /* Si es mayor a 0 es true */  //TODO buscar como mejorar este control.
            
            if (response.Data is true)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                _logger.LogInformation("Delete Success!!!");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }

    public async Task<Response<DiscountDto>> Get(int id, CancellationToken CancellationToken = default)
    {
        var response = new Response<DiscountDto>();
        
        try
        {
            var discount= await _unitOfWork.discountRepository.GetAsycn(id,CancellationToken);

            response.Data = _mapper.Map<DiscountDto>(discount);

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                _logger.LogInformation("Get success!!!");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }

    public async Task<Response<List<DiscountDto>>> GetAll(CancellationToken CancellationToken = default)
    {
        var response = new Response<List<DiscountDto>>();

        try
        {
            var discount = await _unitOfWork.discountRepository.GetAllsycn(CancellationToken);

            response.Data = _mapper.Map<List<DiscountDto>>(discount);

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                _logger.LogInformation("GetAll Success");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }

    public async Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
    {
        var response = new ResponsePagination<IEnumerable<DiscountDto>>();

        try
        {
            var count = await _unitOfWork.discountRepository.CountAsync();
            var custOmers = await _unitOfWork.discountRepository.GetAllWithPaginationAsync(pageNumber, pageSize);

            response.Data = _mapper.Map<IEnumerable<DiscountDto>>(custOmers);

            if (response.Data != null)
            {
                response.PageNumber = pageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta Paginada Exitosa!!!";
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }

    public async Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken CancellationToken = default)
    {
        var response = new Response<bool>();

        try
        {
            var validation = await _discountDtoValidator.ValidateAsync(discountDto, CancellationToken);

            if (!validation.IsValid)
            {
                response.Message = "Error de validación";
                response.Errors = validation.Errors;
                return response;
            }

            var discountEntity = _mapper.Map<Discount>(discountDto);
            await _unitOfWork.discountRepository.UpdateAsync(discountEntity);

            response.Data = await _unitOfWork.Save(CancellationToken) > 0; /* Si es mayor a 0 es true */  //TODO buscar como mejorar este control.

            if (response.Data is true)
            {
                response.IsSuccess = true;
                response.Message = "Success";
                _logger.LogInformation("Update success");
            }

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }

        return response;
    }
}

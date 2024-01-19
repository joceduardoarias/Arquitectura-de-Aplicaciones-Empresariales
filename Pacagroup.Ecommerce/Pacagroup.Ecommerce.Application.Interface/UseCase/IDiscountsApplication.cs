using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface.UseCase
{
    public interface IDiscountsApplication
    {
        Task<Response<bool>> Create(DiscountDto discountDto, CancellationToken CancellationToken = default);
        Task<Response<bool>> Update(DiscountDto discountDto, CancellationToken CancellationToken = default);
        Task<Response<bool>> Delete(int id, CancellationToken CancellationToken = default);
        Task<Response<DiscountDto>> Get(int id, CancellationToken CancellationToken = default);
        Task<Response<List<DiscountDto>>> GetAll(CancellationToken CancellationToken = default);
        Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}

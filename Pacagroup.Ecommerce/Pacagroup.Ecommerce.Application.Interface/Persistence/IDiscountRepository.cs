using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
        Task<Discount> GetAsycn(int id, CancellationToken cancellationToken = default);
        Task<List<Discount>> GetAllsycn(CancellationToken cancellationToken = default);
    }
}

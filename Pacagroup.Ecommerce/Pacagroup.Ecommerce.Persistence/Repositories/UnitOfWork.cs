using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Context;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICustomersRepository customersRepository { get; }

        public IUsersRepository usersRepository { get; }

        public ICategoriesRepository categoriesRepository { get; }

        public IDiscountRepository discountRepository { get; }

        private readonly ApplicationDbContext _applicationDbContext; 

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories, IDiscountRepository discount, ApplicationDbContext applicationDbContext)
        {
            customersRepository = customers;
            usersRepository = users;
            categoriesRepository = categories;
            discountRepository = discount;
            _applicationDbContext = applicationDbContext;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

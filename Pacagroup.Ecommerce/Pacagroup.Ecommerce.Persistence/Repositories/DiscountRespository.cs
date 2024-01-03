using Microsoft.EntityFrameworkCore;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Persistence.Context;
using Pacagroup.Ecommerce.Persistence.Mocks;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class DiscountRespository : IDiscountRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext; //Contexto que se desarrolló para trabajar con EF

        public DiscountRespository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #region Métodos Sincronos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public Discount Get(string Id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(string Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Discount> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Discount> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Discount entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(Discount entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Métodos Asincronos
        public async Task<int> CountAsync()
        {
            return await Task.Run(() => 1000); //La cantidad de regitros.
        }        
        public async Task<bool> DeleteAsync(string Id)
        {
            var entity = await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(Id)));

            if (entity is null)
            {
                return await Task.FromResult(false);
            }

            _applicationDbContext.Remove(entity);

            return await Task.FromResult(true);
        }              
        public Task<IEnumerable<Discount>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Discount>> GetAllsycn(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Set<Discount>().AsNoTracking().ToListAsync(cancellationToken);                
        }        
        public async Task<IEnumerable<Discount>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var faker = new DiscountGetAllWithPaginationAsyncBogusConfig();
            var result = await Task.Run(() => faker.Generate(1000)); // Se están generando 1000 registros fake.

            return result.Skip((pageNumber - 1) * pageSize).Take(pageSize); // Agregando paginación a la respuesta.                                                         
        }
        public async Task<Discount> GetAsycn(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _applicationDbContext.Set<Discount>()
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.Id.Equals(id),cancellationToken);            

            return entity;
        }
        public Task<Discount> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }      
        public async Task<bool> InsertAsync(Discount entity)
        {
            _applicationDbContext.Add(entity);

            return await Task.FromResult(true);
        }      
        public async Task<bool> UpdateAsync(Discount discount)
        {
            var entity = await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));
            
            if (entity is null)
            {
                return await Task.FromResult(false);
            }
            entity.Name = discount.Name;
            entity.Percent = discount.Percent;
            entity.Description = discount.Description;
            entity.Status = discount.Status;
            
            _applicationDbContext.Update(entity);

            return await Task.FromResult(true);
        }
        #endregion
    }
}

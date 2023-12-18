using Dapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infraestructure.Data;
using Pacagroup.Ecommerce.Infraestructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infraestructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "select * From Categories";
                var rs = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
                return rs;
            }
        }
    }
}

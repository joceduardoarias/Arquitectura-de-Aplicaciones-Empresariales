using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Categories>> GetAll()
        {
            return _unitOfWork.categoriesRepository.GetAll();
        }
    }
}

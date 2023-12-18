using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly ICategoriesDomain _categoriesDomain;
        private readonly IMapper _mapper;
        private readonly IloggerApp<CategoriesApplication> _logger;

        public CategoriesApplication(ICategoriesDomain categories, IMapper mapper, IloggerApp<CategoriesApplication> logger)
        {
            _categoriesDomain = categories;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CategoriesDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoriesDto>>();
            try
            {
                response.Data = _mapper.Map<IEnumerable<CategoriesDto>>(await _categoriesDomain.GetAll());
                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Categories obtenidos correctamente");
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
}

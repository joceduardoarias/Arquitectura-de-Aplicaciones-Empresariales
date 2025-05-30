﻿using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Microsoft.Extensions.Logging;

namespace Pacagroup.Ecommerce.Application.UseCase.Categories
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public CategoriesApplication(IUnitOfWork categories, IMapper mapper, ILogger<CategoriesApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = categories;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CategoryDto>>();
            var cacheKey = "categoriesList";
            try
            {
                var redisCategories = await _distributedCache.GetAsync(cacheKey);

                if (redisCategories != null)
                {   //Si la lista de categorias esta cargada en caché la lee desde ahí
                    response.Data = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(redisCategories);
                }
                else
                {   //Si el caché esta vacío busca en la base de datos.
                    response.Data = _mapper.Map<IEnumerable<CategoryDto>>(await _unitOfWork.categoriesRepository.GetAll());

                    if (response.Data != null)
                    {
                        //Cargar el caché
                        var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(2)) //Configura el tiempo de caducidad de la información en caché. 
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60)); //Configura si los datos no se consultan durante 60 minutos caducan.

                        await _distributedCache.SetAsync(cacheKey, serializedCategories, options);
                    }
                }

                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Categories obtenidas correctamente");
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

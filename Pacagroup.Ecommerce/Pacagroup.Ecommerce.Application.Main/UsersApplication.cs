using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;

using System;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _userDtoValidator;
        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UserDtoValidator userDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }

        public Response<UsersDTO> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDTO>();
            var validation = _userDtoValidator.Validate(new UsersDTO() { UserName = userName, Password = password });
            if (!validation.IsValid)
            {
                response.Message = "Error de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                response.Data = _mapper.Map<UsersDTO>(_usersDomain.Authenticate(userName, password));
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    response.Message = "Username or password is empty";
                    return response;
                }
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }                
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = false;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;                
            }
            return response;
        }
    }
}

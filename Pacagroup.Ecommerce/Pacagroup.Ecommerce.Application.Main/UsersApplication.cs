using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }

        public Response<UsersDTO> Authenticate(string userName, string password)
        {
            var response = new Response<UsersDTO>();
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

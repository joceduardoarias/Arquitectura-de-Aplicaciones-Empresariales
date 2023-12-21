using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Transversal.Common;

using System;

namespace Pacagroup.Ecommerce.Application.UseCase.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _userDtoValidator;
        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper, UserDtoValidator userDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }

        public Response<UserDTO> Authenticate(string userName, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _userDtoValidator.Validate(new UserDTO() { UserName = userName, Password = password });
            if (!validation.IsValid)
            {
                response.Message = "Error de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                response.Data = _mapper.Map<UserDTO>(_unitOfWork.usersRepository.Authenticate(userName, password));
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

using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCase.Users.Command.CreateUserTokenCommand;

public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<UserDTO>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<UserDTO>();
        var user = await _unitOfWork.usersRepository.Authenticate(request.UserName, request.Password); 
        if (user == null)
        {
            response.IsSuccess = false;
            response.Message = "Usuario no existe";
            return response;
        }
        response.Data = _mapper.Map<UserDTO>(user);
        response.IsSuccess = true;
        response.Message = "Autenticación Exitosa!!!";

        return response;
        
    }
}

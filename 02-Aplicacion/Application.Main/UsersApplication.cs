using System;
using Application.DTO;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using Transversal.Common;
using Application.Validator;

namespace Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDTOValidator _usersDTOValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDTOValidator usersDTOValidator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersDTOValidator = usersDTOValidator;
        }
        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _usersDTOValidator.Validate(new UsersDto() { UserName = username, Password = password });

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            if(!validation.IsValid)
            {
                //response.Message = "Usuario y/o contraseña no pueden ser vacios.";
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa!";
            }
            catch (InvalidOperationException)  //Se ejecuta cuando el usuario no existe, propio de mapper
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}

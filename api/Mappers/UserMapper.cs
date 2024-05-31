using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserRegisterDto userRegister) => new()
        {
            UserName = userRegister.UserName,
            Email = userRegister.Email,
        };

        public static UserNewUserDto ToNewUserDto(this User user, ITokenService tokenService) => new()
        {
            UserName = user.UserName!,
            Email = user.Email!,
            Token = tokenService.CreateToken(user)
        };
    }
}
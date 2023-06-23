using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using OptimaProject.Entities.Concrete;
using Utilities.Aspects.Autofac;
using Utilities.Results;
using Utilities.Security.Jwt;

namespace OptimaProject.Repositories.Abstract
{
    public interface IAuthRepository
    {
        [SecuredOperation("Admin")]
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

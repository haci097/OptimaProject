using System.Collections.Generic;
using OptimaProject.Entities.Concrete;

namespace Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

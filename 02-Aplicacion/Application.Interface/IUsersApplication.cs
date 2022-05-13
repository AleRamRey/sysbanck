using Application.DTO;
using Transversal.Common;

namespace Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}

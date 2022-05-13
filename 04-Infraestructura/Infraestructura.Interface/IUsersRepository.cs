using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username, string password);
    }
}

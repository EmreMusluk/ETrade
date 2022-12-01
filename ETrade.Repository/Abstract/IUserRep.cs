using ETrade.Core;
using ETrade.DTO;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repository.Abstract
{
    public interface IUserRep :IBaseRepository<Users>
    {
        Users CreateUser(Users user);
        UserDTO Login(string Mail, string Password);

    }
}

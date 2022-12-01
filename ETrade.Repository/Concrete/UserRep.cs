using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concrete;
using ETrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ETrade.DTO;

namespace ETrade.Repository.Concrete
{
    public class UserRep<T> : BaseRepository<Users>, IUserRep where T : class
    {
        TradeContext _db;
        public UserRep(TradeContext db) : base(db)
        {
            _db = db;
        }

        public Users CreateUser(Users user)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == user.Mail);
            if (selectedUser != null) //Hata
            {
                user.Error = true;
            }
            else
            {
                user.Error = false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";
            return user;
        }

        public UserDTO Login(string Mail, string Password)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == Mail);
            UserDTO user = new UserDTO();
            user.Mail = Mail;
            
            if (selectedUser != null)
            {
                user.Error = false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            else user.Error = true;
            return user;
        }
    }
}

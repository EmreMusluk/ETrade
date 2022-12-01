using ETrade.DTO;
using ETrade.Entity.Concrete;
using ETrade.UI.Models.ViewModel;
using ETrade.Uw;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class AuthController : Controller
    {
        public const string SessionUser = "";

        UsersModel _model;
        IUnitofWork _uow;
        public AuthController(UsersModel model, IUnitofWork uow)
        {
            _model = model;
            _uow = uow;
        }
        public IActionResult Register()
        {
            _model.Users = new Users();
            _model.Counties = _uow._CountyRep.List();
            return View(_model);

        }
        [HttpPost]
        public IActionResult Register(UsersModel m)
        {
            m.Users = _uow._UserRep.CreateUser(m.Users);
            if (m.Users.Error == false)
            {

                _uow._UserRep.Add(m.Users);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                m.Counties = _uow._CountyRep.List();
                m.Msg = $"{m.Users.Mail} zaten mevcut";
                return View(m);
            }

        }
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(string Mail, string Password)
        {
            UserDTO user = _uow._UserRep.Login(Mail, Password);

            if (user.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
         
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}



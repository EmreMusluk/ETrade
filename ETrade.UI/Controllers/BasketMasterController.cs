using ETrade.DTO;
using ETrade.Entity.Concrete;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class BasketMasterController : Controller
    {
        IUnitofWork _uow;
        BasketMaster _basketMaster;
        public BasketMasterController(IUnitofWork uow, BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }

        public IActionResult Create()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            
            var selectedBasket = _uow._BasketMasterRep.Set().FirstOrDefault(x => x.Copmleted == false && x.EntityId == usr.Id);
            if (selectedBasket != null)
            {
                return RedirectToAction("Add", "BasketDetail", new {id=selectedBasket.Id});
            }
            else
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.EntityId = usr.Id;
                _uow._BasketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new {id=_basketMaster.Id});
            }


            return View();
        }
    }
}

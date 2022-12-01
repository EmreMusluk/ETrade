using ETrade.Entity.Concrete;
using ETrade.UI.Models.ViewModel;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetailModel _detailModel;
        BasketDetail _basketDetail;
        IUnitofWork _uow;
        public BasketDetailController(BasketDetailModel detailModel,BasketDetail basketDetail, IUnitofWork uow)
        {
            _detailModel = detailModel;
            _basketDetail = basketDetail;
            _uow = uow;
        }

        public IActionResult Add(int id)
        {
            _detailModel.ProductsDTO = _uow._ProductsRep.GetProductsSelect();
            _detailModel.BasketDetailDTO = _uow._BasketDetailRep.BasketDetailDTO(id);
            return View(_detailModel);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel m,int id)
        {
            Products products = _uow._ProductsRep.FindWithVat(m.ProductId);
            _basketDetail.Amount = m.Amount;
            _basketDetail.ProductId=m.ProductId;
            _basketDetail.Id = id;
            _basketDetail.OrderId = id;
            _basketDetail.UnitId=products.UnitId;
            _basketDetail.Ratio = products.Vat.Ratio;//eager looading elle metot girmek lazım.
            _basketDetail.UnitPrice = products.UnitPrice;
            _uow._BasketDetailRep.Add(_basketDetail);
            _uow.Commit();
            return RedirectToAction("Add", new {id});
        }
        public IActionResult Update(int id,int productId)
        {
            return View(_uow._BasketDetailRep.Find(id, productId));
        }
        [HttpPost]
        public IActionResult Update(int Amount,int id, int productId)
        {
            var selectedBasDetail = _uow._BasketDetailRep.Find(id, productId);
            selectedBasDetail.Amount = Amount;
            _uow._BasketDetailRep.Update(selectedBasDetail);
            _uow.Commit();
            return RedirectToAction("Add", new {id});
        }
        public IActionResult Delete(int id, int productId)
        {
            _uow._BasketDetailRep.Delete(id, productId);
            _uow.Commit();
            return RedirectToAction("Add", new { id });

        }

    }
}

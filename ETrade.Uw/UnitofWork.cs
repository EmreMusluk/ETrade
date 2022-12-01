using ETrade.Dal;
using ETrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uw
{
    public class UnitofWork : IUnitofWork
    {
        TradeContext _db;
        public UnitofWork(TradeContext db, IBasketDetailRep basketDetail,IUserRep userRep, IBasketMasterRep basketMasterRep, ICategoriesRep categoriesRep, ICityRep cityRep, ICountyRep countyRep, IProductsRep productsRep, ISuppliersRep suppliersRep, IUnitRep unitRep, IVatRep vatRep)
        {
            _db = db;
            _BasketDetailRep = basketDetail;
            _BasketMasterRep = basketMasterRep;
            _CategoriesRep = categoriesRep;
            _CityRep = cityRep;
            _CountyRep = countyRep;
            _ProductsRep = productsRep;
            _SuppliersRep = suppliersRep;
            _UnitRep = unitRep;
            _VatRep = vatRep;
            _UserRep = userRep;
        }

        public IBasketDetailRep _BasketDetailRep { get; private set; }

        public IBasketMasterRep _BasketMasterRep { get; private set; }

        public ICategoriesRep _CategoriesRep { get; private set; }

        public ICityRep _CityRep { get; private set; }

        public IProductsRep _ProductsRep { get; private set; }

        public IUnitRep _UnitRep { get; private set; }
        public IUserRep _UserRep { get; private set; }

        public ICountyRep _CountyRep { get; private set; }

        public ISuppliersRep _SuppliersRep { get; private set; }

        public IVatRep _VatRep { get; private set; }

        public void Commit()
        {
            _db.SaveChanges();  
        }
    }
}

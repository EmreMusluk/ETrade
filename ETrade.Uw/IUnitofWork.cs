using ETrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uw
{
    public interface IUnitofWork
    {
        IBasketDetailRep _BasketDetailRep { get;  }
        IBasketMasterRep _BasketMasterRep { get; }
        ICategoriesRep _CategoriesRep { get; }
        ICityRep _CityRep { get; }
        ICountyRep _CountyRep { get; }
        IProductsRep _ProductsRep { get; }
        ISuppliersRep _SuppliersRep { get; }
        IUnitRep _UnitRep { get; }
        IVatRep _VatRep { get; }
        IUserRep _UserRep { get; }  

        void Commit();
    }
}

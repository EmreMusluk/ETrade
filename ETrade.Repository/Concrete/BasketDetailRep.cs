using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
using ETrade.Entity.Concrete;
using ETrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repository.Concrete
{
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {
        public BasketDetailRep(TradeContext db) : base(db)
        {
        }

        public List<BasketDetailDTO> BasketDetailDTO(int BasketMasterId)
        {
           return Set().Where(x=>x.Id==BasketMasterId).Select(x => new BasketDetailDTO
            {
                Amount = x.Amount,
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName= x.Products.ProductName,
                UnitPrice = x.UnitPrice,
                Ratio = x.Ratio,
                Total=(x.UnitPrice*x.Amount)*(1+x.Ratio/100),
                UnitName =  x.Unit.Description
            }
            ).ToList();
        }
    }
}

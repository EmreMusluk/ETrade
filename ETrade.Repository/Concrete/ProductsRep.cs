using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
using ETrade.Entity.Concrete;
using ETrade.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repository.Concrete
{
    public class ProductsRep<T> : BaseRepository<Products>, IProductsRep where T : class
    {
        public ProductsRep(TradeContext db) : base(db)
        {
        }

        public Products FindWithVat(int Id)
        {
            return Set().Where(x=>x.Id == Id).Include(x=>x.Vat).FirstOrDefault();   //lazy looding
        }

        public List<ProductsDTO> GetProductsSelect()
        {
            return Set().Select(x=> new ProductsDTO { Id=x.Id,ProductName=x.ProductName}).ToList();
        }
    }
}

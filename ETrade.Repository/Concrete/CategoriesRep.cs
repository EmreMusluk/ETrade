using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concrete;
using ETrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repository.Concrete
{
    public class CategoriesRep<T> : BaseRepository<Categories>, ICategoriesRep where T : class
    {
        public CategoriesRep(TradeContext db) : base(db)
        {
        }
    }
}

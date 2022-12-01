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
    public class SuppliersRep<T> : BaseRepository<Suppliers>, ISuppliersRep where T : class
    {
        public SuppliersRep(TradeContext db) : base(db)
        {
        }
    }
}

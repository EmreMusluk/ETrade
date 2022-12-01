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
    public class CountyRep<T> : BaseRepository<County>, ICountyRep where T : class
    {
        public CountyRep(TradeContext db) : base(db)
        {
        }
    }
}

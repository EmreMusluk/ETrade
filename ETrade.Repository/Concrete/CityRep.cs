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
    public class CityRep<T> : BaseRepository<City>, ICityRep where T : class
    {
        public CityRep(TradeContext db) : base(db)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class Unit:BaseDescription
    {
        public ICollection<Products> Products { get; set; }
        public ICollection<BasketDetail> BasketDetail { get; set; }
    }
}

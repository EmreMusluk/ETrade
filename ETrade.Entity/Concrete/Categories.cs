using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class Categories : BaseDescription
    {
        public ICollection<Products> Products { get; set; }
    }
}

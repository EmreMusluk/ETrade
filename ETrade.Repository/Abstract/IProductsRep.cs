﻿using ETrade.Core;
using ETrade.DTO;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repository.Abstract
{
    public interface IProductsRep:IBaseRepository<Products>
    {
        List<ProductsDTO> GetProductsSelect();
        Products FindWithVat(int Id);
    }
}

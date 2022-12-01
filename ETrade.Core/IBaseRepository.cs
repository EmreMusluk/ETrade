using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public interface IBaseRepository<T> where T : class
    {
        public List<T> List();
        public T Find(int Id);
        public T Find(int Id,int Id2);
        public bool Update(T entity);
        public bool Delete(int Id);
        public bool Delete(int Id,int Id2);
        public bool Add(T entity);
        public DbSet<T> Set();
    }
}

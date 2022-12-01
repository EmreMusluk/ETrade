using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        TradeContext _db;
        public BaseRepository(TradeContext db) 
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int Id, int Id2)
        {
            try
            {
                Set().Remove(Find(Id,Id2));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Find(int Id, int Id2)
        {
            return Set().Find(Id,Id2);
            //BasketDetail Id= Bd.Id   Id2= Bd.ProductId
            //sıra önemli ilk Key hangisi ise ona göre yapılır. yoksa yanlış kayıt gider.
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;      
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

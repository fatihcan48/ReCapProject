using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepositary<T> where T : class, IEntity,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);  // Filtreleme yapılabilsin, yapılmazsa yinede çalış..(filter=null)
        T Get(Expression<Func<T, bool>> filter); 
    }
}

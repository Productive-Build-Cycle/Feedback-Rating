using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Domain
{
    public interface IRepository<Tkey,T> where T : class 
    {
        T Get(Tkey id); //just give us depends on one Id it means getby Id
        List<T> Get(); // give us everything
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}

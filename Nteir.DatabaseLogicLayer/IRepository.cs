using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nteir.DatabaseLogicLayer
{
   public interface IRepository<T> where T:class
    {
        T GetById(Guid Id);
        int Insert(T temp);
        int Delete(T temp);
   
        int Update(T temp);
        List<T> GetAll();
        T GetByExpression(Expression<Func<T, bool>> kosul);
        List<T> GetManyByExpression(Expression<Func<T, bool>> kosul);
        int SAVE();

    }
}

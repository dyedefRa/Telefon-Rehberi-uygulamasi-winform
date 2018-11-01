using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nteir.Entities;

namespace Nteir.DatabaseLogicLayer
{
    public  class Repository<T> : IRepository<T> where T : class
    {
        private readonly nteirContext ctx = new nteirContext();

        private readonly DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = ctx.Set<T>();
        }



        public int Delete(T temp)
        {
            _objectSet.Remove(temp);
            return SAVE();
        }

    

        public List<T> GetAll()
        {
            return _objectSet.ToList();
        }

        public T GetByExpression(Expression<Func<T, bool>> kosul)
        {
            return _objectSet.FirstOrDefault(kosul);
        }

        public T GetById(Guid Id)
        {
           return _objectSet.Find(Id);
        }

        public List<T> GetManyByExpression(Expression<Func<T, bool>> kosul)
        {
            return _objectSet.Where(kosul).ToList();
        }

        public int Insert(T temp)
        {
            _objectSet.Add(temp);
            return SAVE();
        }

        public int SAVE()
        {
            var sayi= ctx.SaveChanges();
            return sayi;
        }

        public int Update(T temp)
        {
            _objectSet.AddOrUpdate(temp);
            return SAVE();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.SqlClient;
using iS3.Core;

namespace iS3.Core.Server
{
    public class RepositoryForServer<T> : IRepository<T> where T : class, new()
    {
        protected readonly iS3DbContext dbContext;

        protected RepositoryForServer(iS3DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public virtual int BatchDelete(IList<Guid> guids)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                foreach (var item in guids)
                {
                    var model = dbcontext.Set<T>().Find(item);
                    dbcontext.Entry(model).State = EntityState.Deleted;
                }
                return dbcontext.SaveChanges();
            }
        }

        public virtual T Create(T model)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                dbcontext.Entry(model).State = EntityState.Added;
                var createRowCount = dbcontext.SaveChanges();
                return createRowCount > 0 ? model : null;
            }
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="guid">指定的全局标识</param>
        /// <returns>删除数量</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual int Delete(Guid guid)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                var model = dbcontext.Set<T>().Find(guid);
                if (model == null) throw new ArgumentOutOfRangeException(nameof(guid));
                dbcontext.Entry(model).State = EntityState.Deleted;
                return dbcontext.SaveChanges();
            }
        }
        public virtual int Delete(int key)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                var model = dbcontext.Set<T>().Find(key);
                if (model == null) throw new ArgumentOutOfRangeException(nameof(key));
                dbcontext.Entry(model).State = EntityState.Deleted;
                return dbcontext.SaveChanges();
            }
        }
        public virtual List<T> GetAll()
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                return dbcontext.Set<T>().Where(q => true).ToList();
            }
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> expression, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int skip, int take, out int total)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                total = dbcontext.Set<T>().Where(expression).Count();
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return dbcontext.Set<T>().Where(expression).OrderBy(sortPredicate).Skip(skip).Take(take).ToList();

                    case SortOrder.Descending:
                        return dbcontext.Set<T>().Where(expression).OrderByDescending(sortPredicate).Skip(skip).Take(take).ToList();

                }
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
            }
        }

        /// <summary>
        /// 返回序列中的第一个元素
        /// </summary>
        /// <param name="expression">查询表达式</param>
        /// <returns>T</returns>
        /// <exception cref="ArgumentNullException">source 为 null</exception>
        public virtual T Retrieve(Expression<Func<T, bool>> expression)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                return dbcontext.Set<T>().FirstOrDefault(expression);
            }
        }

        public virtual T Retrieve(Guid guid)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                return dbcontext.Set<T>().Find(guid);
            }
        }

        public virtual T Update(T model)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                dbcontext.Entry(model).State = EntityState.Modified;
                var updateRowAcount = dbcontext.SaveChanges();
                return updateRowAcount > 0 ? model : null;
            }
        }

        public virtual T Retrieve(int key)
        {
            using (var dbcontext = dbContext.GetInstance())
            {
                return dbcontext.Set<T>().Find(key);
            }
        }

        public List<T> BatchCreate(List<T> models)
        {
            return null;
        }

        public List<T> BatchUpdate(List<T> models)
        {
            return null;
        }
    }
}
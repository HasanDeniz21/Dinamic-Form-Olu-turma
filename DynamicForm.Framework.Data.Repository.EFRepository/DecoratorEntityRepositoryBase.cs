using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Framework.Data.Infrastructure;
using DynamicForm.Framework.Data.Repository.Infrastructure;
using DynamicForm.Framework.Data.Repository.Infrastructure.EntityFramework;

namespace DynamicForm.Framework.Data.Repository.EFRepositoryBase
{
    public class DecoratorEntityRepositoryBase<C, T> : IRepository<T>, ISelectableRepository<T>, IInsertableRepository<T>, IUpdatableRepository<T>, IDeleteAbleRepository<T>, ISelectableAsyncRepository<T>, ISelectableGetByAsyncRepository<T>, ISelectableGetByRepository<T> where C : BaseDataContext where T : class, IEntity
    {
        protected DbSet<T> _dbSet { get; set; }

        protected DecoratorEntityRepositoryBase(C context)
        {

        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        /// </summary>
        /// <param name="filter">Apply WHERE conditions.</param>
        /// <returns></returns>

        private IQueryable<T> ApplyFilter(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            return filter == null ? query : query.Where(filter);
        }

        public virtual void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public virtual void DeleteById(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual T Insert(T item)
        {
            _dbSet.Add(item);
            return item;
        }

        public virtual T Update(T item)
        {
            _dbSet.AddOrUpdate(item);
            return item;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = ApplyFilter(filter);
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual T GetSingleBy(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? _dbSet.FirstOrDefault(filter) : _dbSet.FirstOrDefault();
        }

        #region AsyncMethods
        public virtual Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public virtual Task<T> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public virtual Task<List<T>> GetByAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = ApplyFilter(filter);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToListAsync();
        }

        public virtual Task<T> GetSingleByAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? _dbSet.FirstOrDefaultAsync(filter) : _dbSet.FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetTable(int start, int length, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
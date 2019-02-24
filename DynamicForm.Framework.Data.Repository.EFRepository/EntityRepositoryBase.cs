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
    public abstract class EntityRepositoryBase<C, T> : IRepository<T>, ISelectableRepository<T>, IInsertableRepository<T>, IUpdatableRepository<T>, IDeleteAbleRepository<T>, ISelectableAsyncRepository<T>, ISelectableGetByAsyncRepository<T>, ISelectableGetByRepository<T> where C : BaseDataContext where T : class, IEntity
    {
        protected DbSet<T> _dbSet { get; set; }
        protected C _dataContext { get; private set; }

        protected EntityRepositoryBase(C context)
        {
            this._dataContext = context;
            this._dbSet = _dataContext.Set<T>();

#if DEBUG
            this._dataContext.Database.Log = x => Debug.WriteLine(x);
#endif
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

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _dataContext.SaveChanges();
        }

        public void DeleteById(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public T Insert(T item)
        {
            _dbSet.Add(item);
            //_dataContext.Entry(item).State = EntityState.Added;
            _dataContext.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            _dbSet.AddOrUpdate(item);
            //_dataContext.Entry(item).State = EntityState.;
            //_dataContext.Entry(item).State = EntityState.Modified;
            _dataContext.SaveChanges();
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = ApplyFilter(filter);
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetSingleBy(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? _dbSet.FirstOrDefault(filter) : _dbSet.FirstOrDefault();
        }

        #region AsyncMethods

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task<List<T>> GetByAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = ApplyFilter(filter);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query.ToListAsync();
        }

        public Task<T> GetSingleByAsync(Expression<Func<T, bool>> filter)
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

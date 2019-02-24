﻿using System;
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
    public abstract class EntityRepositoryBaseUoW<C, T> : IRepository<T>, ISelectableRepository<T>, IInsertableRepository<T>, IUpdatableRepository<T>, IDeleteAbleRepository<T>, ISelectableGetByRepository<T> where C : BaseDataContext where T : class, IEntity
    {
        protected DbSet<T> _dbSet { get; set; }
        protected C _dataContext { get; private set; }

        protected EntityRepositoryBaseUoW(C context)
        {
            _dataContext = context;
            _dbSet = _dataContext.Set<T>();
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public void DeleteById(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public T Insert(T item)
        {
            _dbSet.Add(item);
            return item;
        }

        public T Update(T item)
        {
            _dbSet.AddOrUpdate(item);
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

        public IEnumerable<T> GetTable(int start, int length, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}

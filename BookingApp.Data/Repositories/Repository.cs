﻿using BookingApp.Data.Context;
using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {

        private readonly BookingAppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BookingAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);


          //  _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            //soft delete ile beraber bir modifiye etmek olduğu için işlem olan tarihi kaydediyoruz.
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);


           // _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);


        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate= DateTime.Now;
            _dbSet.Update(entity);


           // _dbContext.SaveChanges();

        }
    }
}

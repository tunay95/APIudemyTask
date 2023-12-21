using BlogApp.Core.Entities;
using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Implementation
{
    public class Repository<T>:IRepository<T> where T : BaseEntity,new() 
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table =>_context.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
        Expression<Func<T, object>>? orderbyExpression = null, bool isDescending = false, params string[] includes)
        {
            IQueryable<T> query = Table.Where(e=>!e.IsDeleted);

            if(expression is not null)
            {
                query = query.Where(expression);
            }

            if(orderbyExpression is not null)
            {
                query = isDescending ? query.OrderBy(orderbyExpression) : query.OrderBy(orderbyExpression);
            }

            if(includes is not null)
            {
                for(int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }

            return query;
        }
        public async Task<T> GetById(int id)
        {
            var brand = await Table.FirstOrDefaultAsync(b=>b.Id==id);
            return brand;
        }

        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            Table.Update(entity);
        } 

        public void Delete(T entity) 
        {
            Table.Remove(entity);
        }

        public async Task SavingChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

}

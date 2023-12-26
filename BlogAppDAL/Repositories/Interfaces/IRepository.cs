using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity,new()
    {

        DbSet<T> Table { get; }
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
        Expression <Func<T, object>>? orderbyExpression = null, bool isDescending = false, params string[] includes);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task SavingChanges();

    }
}

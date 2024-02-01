using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class BaseDBContext<T> where T : class, new()
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected BaseDBContext(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual async Task InsertAsync(T data)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _dbSet.AddAsync(data);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    //public virtual async Task<List<T>> GetAllAsync()
    //{
    //    var entities = await _dbSet.ToListAsync();

    //    foreach (var entity in entities)
    //    {
    //        HandleDBNullValues(entity);
    //    }

    //    return entities;
    //}

    private void HandleDBNullValues(T entity)
    {
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(byte[]))
            {
                var value = property.GetValue(entity);

                if (value != null && value.Equals(DBNull.Value))
                {
                    property.SetValue(entity, null);
                }
            }
        }
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var result = await _dbSet.ToListAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var result = await _dbSet.FindAsync(id);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public virtual async Task UpdateAsync(T updatedData)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbSet.Update(updatedData);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    var result = await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return result > 0;
                }
                return false;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    // You can add abstract methods here if needed
}

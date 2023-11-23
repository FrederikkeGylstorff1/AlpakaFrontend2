using Microsoft.EntityFrameworkCore;

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
        await _dbSet.AddAsync(data);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task UpdateAsync(T updatedData)
    {
        _dbSet.Update(updatedData);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
        return false;
    }

    // You can add abstract methods here if needed
}
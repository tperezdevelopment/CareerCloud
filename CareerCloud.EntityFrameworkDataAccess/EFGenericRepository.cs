using CareerCloud.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess;

public class EFGenericRepository<TPoco> : IDataRepository<TPoco>
    where TPoco : class
{
    private readonly CareerCloudContext _dbContext;


    public EFGenericRepository()
    {
        _dbContext = new CareerCloudContext();
    }

    public void Add(params TPoco[] items)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        foreach (var item in items)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }
    }

    public IList<TPoco> GetAll(params Expression<Func<TPoco, object>>[] navigationProperties)
    {
        IQueryable<TPoco> query = _dbContext.Set<TPoco>();

        foreach (var property in navigationProperties)
        {
            query = query.Include(property);
        }

        return query.ToList();
    }

    public TPoco GetSingle(Expression<Func<TPoco, bool>> where, params Expression<Func<TPoco, object>>[] navigationProperties)
    {
        IQueryable<TPoco> objGetAll = GetAll().AsQueryable();
        return objGetAll.Where(where).FirstOrDefault();
    }

    //Inferring this method
    public IList<TPoco> GetList(Expression<Func<TPoco, bool>> where, params Expression<Func<TPoco, object>>[] navigationProperties)
    {
        IQueryable<TPoco> query = _dbContext.Set<TPoco>()
                                  .Where(where);

        foreach (var property in navigationProperties)
        {
            query = query.Include(property);
        }

        return query.ToList();

    }
    // Inferring this method
    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        var parametersString = parameters.Select(p => $"{p.Item1} = '{p.Item2}'");
        var parameterSql = string.Join(", ", parametersString);
        _dbContext.Set<TPoco>().FromSqlInterpolated($"EXEC {name} {parameterSql}");
    }

    public void Remove(params TPoco[] items)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        foreach (var item in items)
        {
            _dbContext.RemoveRange(item);
            _dbContext.SaveChanges();
        }
    }

    public void Update(params TPoco[] items)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        foreach (var item in items)
        {
            _dbContext.UpdateRange(item);
            _dbContext.SaveChanges();
        }
    }

}

using Generator.DomainApi.Port;
using Generator.Persistence.Adapter.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Domain
{
    public class DealDomain<T> : IRequestDeal<T> where T : class
    {
        private readonly DbSet<T> table;
        private readonly ApplicationDbContext _dbContext;

        public DealDomain(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }
        public T GetDeal(int id)
        {
            return table.Find(id);
        }

        public List<T> GetDeals()
        {
            return table.ToList();
        }

        public void PostDeal(T model)
        {
            table.Add(model);
            _dbContext.SaveChangesAsync();
        }
    }
}

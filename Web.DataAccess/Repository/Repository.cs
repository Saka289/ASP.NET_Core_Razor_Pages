using Microsoft.EntityFrameworkCore;
using Web.DataAccess.Repository.IRepository;
using Web.DataAccesss.Data;

namespace Web.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //FoodType, Category
            //_context.MenuItem.Include(c => c.Category).Include(f => f.FoodType);
            this._dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}

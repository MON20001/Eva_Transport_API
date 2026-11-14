using Eva_Transport_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        protected AppDbContext _db;
        public Generic(AppDbContext db)
        {
            _db = db;
        }

        //Get All
        public virtual async Task<IEnumerable<T?>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
        //Get By ID
        public virtual async Task<T?> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        //Add
        public virtual async Task Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public virtual async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public virtual async Task<bool> Delete(int id)
        {
            var find = await _db.Set<T>().FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.Set<T>().Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}

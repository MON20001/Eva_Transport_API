using Eva_Transport_API.Data;
using Eva_Transport_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.Functional
{
    public class CompanyRepo : Generic<Company>
    {
        public CompanyRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<Company?>> GetAll()
        {
            return await _db.Companies.ToListAsync();
        }
        //Add
        public override async Task Add(Company entity)
        {
            await _db.Companies.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.Companies.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.Companies.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

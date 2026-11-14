using Eva_Transport_API.Data;
using Eva_Transport_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.Functional
{
    public class EmployeeRepo : Generic<Employee>
    {
        public EmployeeRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<Employee?>> GetAll()
        {
            return await _db.Employees.Include(x => x.company).Include(x => x.employeeBusTrips).ToListAsync();
        }
        //Get By ID
        public override async Task<Employee?> GetById(int id)
        {
            return await _db.Employees.Include(x => x.company).Include(x => x.employeeBusTrips).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(Employee entity)
        {
            await _db.Employees.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(Employee entity)
        {
            _db.Employees.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.Employees.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.Employees.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

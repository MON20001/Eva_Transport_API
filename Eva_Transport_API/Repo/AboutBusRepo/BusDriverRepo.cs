using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutBusRepo
{
    public class BusDriverRepo : Generic<BusDriver>
    {
        public BusDriverRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<BusDriver?>> GetAll()
        {
            return await _db.BusDrivers.Include(x => x.buses).ToListAsync();
        }
        //Get By ID
        public override async Task<BusDriver?> GetById(int id)
        {
            return await _db.BusDrivers.Include(x => x.buses).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(BusDriver entity)
        {
            await _db.BusDrivers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(BusDriver entity)
        {
            _db.BusDrivers.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.BusDrivers.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.BusDrivers.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

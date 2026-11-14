using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutTruckRepo
{
    public class TruckDriverRepo : Generic<TruckDriver>
    {
        public TruckDriverRepo(AppDbContext db) : base(db)
        {
        }

        //Get All
        public override async Task<IEnumerable<TruckDriver?>> GetAll()
        {
            return await _db.TruckDrivers.Include(x => x.trucks).ToListAsync();
        }
        //Get By ID
        public override async Task<TruckDriver?> GetById(int id)
        {
            return await _db.TruckDrivers.Include(x => x.trucks).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(TruckDriver entity)
        {
            await _db.TruckDrivers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(TruckDriver entity)
        {
            _db.TruckDrivers.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.TruckDrivers.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.TruckDrivers.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

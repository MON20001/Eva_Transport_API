using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutTruckRepo
{
    public class TruckRepo : Generic<Truck>
    {
        public TruckRepo(AppDbContext db) : base(db)
        {
        }
        
        //Get All
        public override async Task<IEnumerable<Truck?>> GetAll()
        {
            return await _db.Trucks
                .Include(x => x.truckDrivers)
                .Include(x => x.reports)
                .Include(x => x.company)
                .Include(x => x.truckDrivers)
                .ToListAsync();
        }
        //Get By ID
        public override async Task<Truck?> GetById(int id)
        {
            return await _db.Trucks
                .Include(x => x.truckDrivers)
                .Include(x => x.reports)
                .Include(x => x.company)
                .Include(x => x.truckDrivers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(Truck entity)
        {
            await _db.Trucks.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(Truck entity)
        {
            _db.Trucks.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.Trucks.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.Trucks.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

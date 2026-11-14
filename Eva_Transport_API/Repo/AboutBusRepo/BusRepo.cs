using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutBusRepo
{
    public class BusRepo : Generic<Bus>
    {
        public BusRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<Bus?>> GetAll()
        {
            return await _db.Buses
                .Include(x => x.busDrivers)
                .Include(x => x.reports)
                .Include(x => x.company)
                .Include(x => x.busTrips)
                .ToListAsync();
        }
        //Get By ID
        public override async Task<Bus?> GetById(int id)
        {
            return await _db.Buses
                .Include(x => x.busDrivers)
                .Include(x => x.reports)
                .Include(x => x.company)
                .Include(x => x.busTrips)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(Bus entity)
        {
            await _db.Buses.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(Bus entity)
        {
            _db.Buses.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.Buses.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.Buses.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
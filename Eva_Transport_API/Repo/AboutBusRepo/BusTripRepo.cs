using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutBusRepo
{
    public class BusTripRepo : Generic<BusTrip>
    {
        public BusTripRepo(AppDbContext db) : base(db)
        {
        }

        //Get All
        public override async Task<IEnumerable<BusTrip?>> GetAll()
        {
            return await _db.BusTrips
                .Include(x => x.bus)
                .Include(x => x.employees)
                .ToListAsync();
        }
        //Get By ID
        public override async Task<BusTrip?> GetById(int id)
        {
            return await _db.BusTrips
                .Include(x => x.bus)
                .Include(x => x.employees)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(BusTrip entity)
        {
            await _db.BusTrips.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(BusTrip entity)
        {
            _db.BusTrips.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.BusTrips.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.BusTrips.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}

using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutTruckRepo
{
    public class TruckTripRepo : Generic<TruckTrip>
    {
        public TruckTripRepo(AppDbContext db) : base(db)
        {
        }

        //Get All
        public override async Task<IEnumerable<TruckTrip?>> GetAll()
        {
            return await _db.TruckTrips
                .Include(x => x.truck)
                .ToListAsync();
        }
        //Get By ID
        public override async Task<TruckTrip?> GetById(int id)
        {
            return await _db.TruckTrips
                .Include(x => x.truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(TruckTrip entity)
        {
            await _db.TruckTrips.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(TruckTrip entity)
        {
            _db.TruckTrips.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.TruckTrips.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.TruckTrips.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}

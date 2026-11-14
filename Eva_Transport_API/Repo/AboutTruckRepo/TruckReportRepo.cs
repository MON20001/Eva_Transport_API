using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Eva_Transport_API.Models.AboutTruck;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutTruckRepo
{
    public class TruckReportRepo : Generic<TruckMaintenanceRequest>
    {
        public TruckReportRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<TruckMaintenanceRequest?>> GetAll()
        {
            return await _db.TruckReports.Include(x => x.truck).ToListAsync();
        }
        //Get By ID
        public override async Task<TruckMaintenanceRequest?> GetById(int id)
        {
            return await _db.TruckReports.Include(x => x.truck).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(TruckMaintenanceRequest entity)
        {
            await _db.TruckReports.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(TruckMaintenanceRequest entity)
        {
            _db.TruckReports.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.TruckReports.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.TruckReports.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

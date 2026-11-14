using Eva_Transport_API.Data;
using Eva_Transport_API.Models.AboutBus;
using Microsoft.EntityFrameworkCore;

namespace Eva_Transport_API.Repo.AboutBusRepo
{
    public class BusReportRepo : Generic<BusMaintenanceRequest>
    {
        public BusReportRepo(AppDbContext db) : base(db)
        {
        }
        //Get All
        public override async Task<IEnumerable<BusMaintenanceRequest?>> GetAll()
        {
            return await _db.BusReports.Include(x => x.bus).ToListAsync();
        }
        //Get By ID
        public override async Task<BusMaintenanceRequest?> GetById(int id)
        {
            return await _db.BusReports.Include(x => x.bus).FirstOrDefaultAsync(x => x.Id == id);
        }
        //Add
        public override async Task Add(BusMaintenanceRequest entity)
        {
            await _db.BusReports.AddAsync(entity);
            await _db.SaveChangesAsync();
        }
        //Update
        public override async Task Update(BusMaintenanceRequest entity)
        {
            _db.BusReports.Update(entity);
            await _db.SaveChangesAsync();
        }
        //Delete
        public override async Task<bool> Delete(int id)
        {
            var find = await _db.BusReports.FindAsync(id);
            if (find == null)
            {
                return false;
            }
            _db.BusReports.Remove(find);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

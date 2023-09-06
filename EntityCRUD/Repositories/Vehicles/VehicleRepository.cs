using EntityCRUD.Data;
using EntityCRUD.Interfaces.Vehicles;
using EntityCRUD.Models.Staffs;
using EntityCRUD.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUD.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _dbContext;
        public VehicleRepository(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(Vehicle entity)
        {
            await _dbContext.Vehicles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var deleteVehicle = _dbContext.Vehicles.FirstOrDefault(x => x.Id == Id);

            if (deleteVehicle != null)
            {
                _dbContext.Vehicles.Remove(deleteVehicle);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<Vehicle>> GetAllAsync()
        {
            var allVehicle = await _dbContext.Vehicles.ToListAsync();
            return allVehicle;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            var vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

            if (vehicle != null)
            {
                return vehicle;
            }

            return new Vehicle();
        }

        public async Task<bool> UpdateAsync(Vehicle entity)
        {
            _dbContext.Vehicles.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

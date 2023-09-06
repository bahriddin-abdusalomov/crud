using EntityCRUD.Data;
using EntityCRUD.Interfaces.Travels;
using EntityCRUD.Models.Staffs;
using EntityCRUD.Models.Travels;
using Microsoft.EntityFrameworkCore;

namespace EntityCRUD.Repositories.Travels
{
    public class TravelRepository : ITravelRepository
    {
        private readonly AppDbContext _dbContext;
        public TravelRepository(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(Travel entity)
        {
            await _dbContext.Travels.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var deleteTravel = _dbContext.Travels.FirstOrDefault(x => x.Id == Id);

            if (deleteTravel != null)
            {
                _dbContext.Travels.Remove(deleteTravel);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<Travel>> GetAllAsync()
        {
            var allTravel = await _dbContext.Travels.ToListAsync();
            return allTravel;
        }

        public async Task<Travel> GetByIdAsync(int id)
        {
            var travel = await _dbContext.Travels.FirstOrDefaultAsync(x => x.Id == id);

            if (travel != null)
            {
                return travel;
            }

            return new Travel();
        }

        public async Task<bool> UpdateAsync(Travel entity)
        {
            _dbContext.Travels.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

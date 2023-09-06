using EntityCRUD.Data;
using EntityCRUD.Interfaces.Users;
using EntityCRUD.Models.Staffs;
using Microsoft.EntityFrameworkCore;

namespace EntityCRUD.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(User entity)
        {
            await  _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var deleteUser = _dbContext.Users.FirstOrDefault(x => x.Id == Id);
            
            if (deleteUser != null)
            {
                _dbContext.Users.Remove(deleteUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            var allUser = await _dbContext.Users.ToListAsync();
            return allUser;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(user != null)
            {
                return user;
            }

            return new User();
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using trip_planner.Models;

namespace trip_planner.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}

public class UserRepository : IUserRepository
{
    private readonly TripPlannerContext _context;

    public UserRepository(TripPlannerContext context)
    {
        _context = context;

		if(_context.Users.Count() == 0)
		{
			_context.Users.Add(new User { UserID = 1, Name = "Manuel Carlos", Email = "manuel.carlos@example.com", Password = "password123", Description = "Escritor" });
			_context.SaveChanges();
		}
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        // SQL: SELECT * FROM Users
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        // SQL: SELECT * FROM Users WHERE UserID = [id]
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> AddAsync(User user)
    {
        // SQL: INSERT INTO Users (Name, Email, Password, Description) VALUES ([Name], [Email], [Password], [Description])
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
		// SQL: UPDATE Users SET Name = [Name], Email = [Email], Password = [Password], Description = [Description] WHERE UserID = [UserID]
		_context.Entry(await _context.Users.FirstOrDefaultAsync(us => us.UserID == user.UserID)).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            // SQL: DELETE FROM Users WHERE UserID = [id]
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
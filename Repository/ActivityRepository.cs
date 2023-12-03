using Microsoft.EntityFrameworkCore;
using trip_planner.Models;

namespace trip_planner.Repository;

public interface IActivityRepository
{
    Task<IEnumerable<Activity>> GetAllAsync();
    Task<Activity> GetByIdAsync(int id);
    Task<Activity> AddAsync(Activity activity);
    Task UpdateAsync(Activity activity);
    Task DeleteAsync(int id);
}

public class ActivityRepository : IActivityRepository
{
    private readonly TripPlannerContext _context;

    public ActivityRepository(TripPlannerContext context)
    {
        _context = context;

		if(_context.Activities.Count() == 0)
		{
			_context.Activities.Add(new Activity { ActivityID = 1, Name = "Tour pelo centro historico", Type = "Tour", Location = "Centro", Price = 20.00, Description = "Tour guiado pelo centro historico." });
			_context.SaveChanges();
		}
    }

    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        // SQL: SELECT * FROM Activities
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity> GetByIdAsync(int id)
    {
        // SQL: SELECT * FROM Activities WHERE ActivityID = [id]
        return await _context.Activities.FindAsync(id);
    }

    public async Task<Activity> AddAsync(Activity activity)
    {
        // SQL: INSERT INTO Activities (Name, Type, Location, Price, Description) VALUES ([Name], [Type], [Location], [Price], [Description])
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        return activity;
    }

    public async Task UpdateAsync(Activity activity)
    {
        // SQL: UPDATE Activities SET Name = [Name], Type = [Type], Location = [Location], Price = [Price], Description = [Description] WHERE ActivityID = [ActivityID]
		_context.Entry(await _context.Activities.FirstOrDefaultAsync(act => act.ActivityID == activity.ActivityID)).CurrentValues.SetValues(activity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity != null)
        {
            // SQL: DELETE FROM Activities WHERE ActivityID = [id]
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }
    }
}


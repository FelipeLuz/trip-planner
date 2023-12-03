using Microsoft.EntityFrameworkCore;
using trip_planner.Models;

namespace trip_planner.Repository;

public interface IAccommodationRepository
{
    Task<IEnumerable<Accommodation>> GetAllAsync();
    Task<Accommodation> GetByIdAsync(int id);
    Task<Accommodation> AddAsync(Accommodation accommodation);
    Task UpdateAsync(Accommodation accommodation);
    Task DeleteAsync(int id);
}

public class AccommodationRepository : IAccommodationRepository
{
    private readonly TripPlannerContext _context;

    public AccommodationRepository(TripPlannerContext context)
    {
        _context = context;

		if(_context.Accommodations.Count() == 0)
		{
			_context.Accommodations.Add(new Accommodation { AccommodationID = 1, Name = "Hotel com vista para o mar", Location = "Avenida Atlantica", Type = "Hotel", PricePerNight = 100.50, Description = "Vista ao mar maravilhosa com quartos luxuosos." });
		}
    }

    public async Task<IEnumerable<Accommodation>> GetAllAsync()
    {
        // SQL: SELECT * FROM Accommodations
        return await _context.Accommodations.ToListAsync();
    }

    public async Task<Accommodation> GetByIdAsync(int id)
    {
        // SQL: SELECT * FROM Accommodations WHERE AccommodationID = [id]
        return await _context.Accommodations.FindAsync(id);
    }

    public async Task<Accommodation> AddAsync(Accommodation accommodation)
    {
        // SQL: INSERT INTO Accommodations (Name, Location, Type, PricePerNight, Description) VALUES ([Name], [Location], [Type], [PricePerNight], [Description])
        _context.Accommodations.Add(accommodation);
        await _context.SaveChangesAsync();
        return accommodation;
    }

    public async Task UpdateAsync(Accommodation accommodation)
    {
        // SQL: UPDATE Accommodations SET Name = [Name], Location = [Location], Type = [Type], PricePerNight = [PricePerNight], Description = [Description] WHERE AccommodationID = [AccommodationID]
		_context.Entry(await _context.Accommodations.FirstOrDefaultAsync(acc => acc.AccommodationID == accommodation.AccommodationID)).CurrentValues.SetValues(accommodation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var accommodation = await _context.Accommodations.FindAsync(id);
        if (accommodation != null)
        {
            // SQL: DELETE FROM Accommodations WHERE AccommodationID = [id]
            _context.Accommodations.Remove(accommodation);
            await _context.SaveChangesAsync();
        }
    }
}

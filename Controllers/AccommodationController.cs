using Microsoft.AspNetCore.Mvc;
using trip_planner.Models;  // Replace with your actual namespace
using trip_planner.Repository;  // Replace with your actual namespace

namespace trip_planner.Controllers;

[ApiController]
[Route("[controller]")]
public class AccommodationController : ControllerBase
{
    private readonly IAccommodationRepository _accommodationRepository;

    public AccommodationController(IAccommodationRepository accommodationRepository)
    {
        _accommodationRepository = accommodationRepository;
    }

    // GET: api/Accommodation
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accommodations = await _accommodationRepository.GetAllAsync();
        return Ok(accommodations);
    }

    // GET: api/Accommodation/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var accommodation = await _accommodationRepository.GetByIdAsync(id);
        if (accommodation == null)
        {
            return NotFound();
        }
        return Ok(accommodation);
    }

    // POST: api/Accommodation
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Accommodation accommodation)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var created = await _accommodationRepository.AddAsync(accommodation);
        return CreatedAtAction(nameof(GetById), new { id = created.AccommodationID }, created);
    }

    // PUT: api/Accommodation/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Accommodation accommodation)
    {
        if (id != accommodation.AccommodationID)
        {
            return BadRequest();
        }

        await _accommodationRepository.UpdateAsync(accommodation);
        return NoContent();
    }

    // DELETE: api/Accommodation/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _accommodationRepository.DeleteAsync(id);
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using trip_planner.Models;  // Replace with your actual namespace
using trip_planner.Repository;  // Replace with your actual namespace

namespace trip_planner.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityRepository _activityRepository;

    public ActivityController(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _activityRepository.GetAllAsync();
        return Ok(activities);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var activity = await _activityRepository.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound();
        }
        return Ok(activity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Activity activity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var created = await _activityRepository.AddAsync(activity);
        return CreatedAtAction(nameof(GetById), new { id = created.ActivityID }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Activity activity)
    {
        if (id != activity.ActivityID)
        {
            return BadRequest();
        }

        await _activityRepository.UpdateAsync(activity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _activityRepository.DeleteAsync(id);
        return NoContent();
    }
}

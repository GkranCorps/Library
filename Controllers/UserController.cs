using Microsoft.AspNetCore.Mvc;
using SITE.Models;
using SITE.Repositories;

namespace SITE.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<User>>> GetAll() => Ok(await repository.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await repository.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        var created = await repository.AddAsync(user);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.Id) return BadRequest("ID в адресе и теле запроса должны совпадать.");
        return await repository.UpdateAsync(user) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => await repository.DeleteAsync(id) ? NoContent() : NotFound();
}

using Microsoft.AspNetCore.Mvc;
using poll_api.Models;
using poll_api.Services;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    protected readonly IUserService userService;

    public UserController(IUserService service)
    {
        userService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(userService.Get());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetId(Guid id)
    {
        User user = userService.GetById(id);
        if(user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        userService.Add(user);
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(Guid id, [FromBody] User user)
    {
        userService.Update(id, user);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        userService.Delete(id);
        return Ok();
    }
}
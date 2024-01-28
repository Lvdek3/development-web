using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using frontend.Models;

namespace frontend.Controllers;
[Route("exam/")]

public class UserController : Controller
{
    readonly IUserStorage UserStorage = new UserStorage();
    public UserController()
    {
    }

    [HttpPost("createStudent")]
    public async Task<IActionResult> CreateStudent([FromBody] User user)
    {
        await UserStorage.AddUser(user);
        return Ok();
    }

    [HttpDelete("deletestudent")]

    public async Task<IActionResult> DeleteStudent([FromQuery] String UserName)
    {
    await UserStorage.DeleteUser(UserName);
    return Ok();
    }

    [HttpGet()]
    public async Task<IActionResult> GetStudents([FromQuery] int from, [FromQuery] int to)
    {
        var users = await UserStorage.GetUsers(from, to);
        return Ok(users);
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace MicroServ.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(ILogger<TodoController> _logger, DbConnection _dbConnection) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Array.Empty<string>());
    }
}

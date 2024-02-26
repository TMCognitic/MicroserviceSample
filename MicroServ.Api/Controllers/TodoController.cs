using MicroServ.Api.Models.Entities;
using MicroServ.Api.Models.Queries;
using MicroServ.Api.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Tools.Cqs.Queries;

namespace MicroServ.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(ILogger<TodoController> _logger, ITodoRepository _repository) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation($"Request on : /Todo");

        IQueryResult<IEnumerable<Todo>> result = _repository.Execute(new GetAllTodoQuery());

        if(result.IsFailure)
            return BadRequest(new { result.ErrorMessage });

        return Ok(result.Value);
    }
}

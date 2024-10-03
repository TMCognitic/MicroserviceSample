using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MicroServ.Web.Models;
using MicroServ.Web.Models.Repositories;
using MicroServ.Web.Models.Queries;
using MicroServ.Web.Models.Entities;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace MicroServ.Web.Controllers;

public class HomeController(ILogger<HomeController> _logger, ITodoRepository _repository) : Controller
{
    public IActionResult Index()
    {
        IQueryResult<IEnumerable<Todo>> result = _repository.Execute(new GetAllTodoQuery());

        if (result.IsFailure)
            return BadRequest(new { result.ErrorMessage });

        IEnumerable<Todo> items = result.Result!;
        return View(items);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

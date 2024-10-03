using System.Data.Common;

namespace MicroServ.Api.Models.Entities;

public class Todo
{
    public int Id { get; init; }
    public string Title { get; init; }

    public Todo(int id, string title)
    {
        Id = id;
        Title = title;
    }
}
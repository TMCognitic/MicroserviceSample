using System.Data.Common;

namespace MicroServ.Api.Models.Entities;

public class Todo
{
    public static explicit operator Todo(DbDataReader dbDataReader)
    {
        return new Todo((int)dbDataReader["Id"], (string)dbDataReader["Title"]);
    }

    public int Id { get; init; }
    public string Title { get; init; }

    public Todo(int id, string title)
    {
        Id = id;
        Title = title;
    }
}
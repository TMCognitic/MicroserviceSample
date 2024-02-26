namespace MicroServ.Web.Models.Entities
{
    public class Todo(int id, string title)
    {
        public int Id { get; init; } = id;
        public string Title { get; init; } = title;
    }
}

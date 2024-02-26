using MicroServ.Web.Models.Entities;
using MicroServ.Web.Models.Queries;
using MicroServ.Web.Models.Repositories;
using System.Text.Json;
using Tools.Cqs.Queries;

namespace MicroServ.Web.Models.Services
{
    public class TodoService(IHttpClientFactory _httpClientFactory) : ITodoRepository
    {
        public IQueryResult<IEnumerable<Todo>> Execute(GetAllTodoQuery query)
        {
            using HttpClient client = _httpClientFactory.CreateClient("api");

            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync("todo").Result;

                if(!httpResponseMessage.IsSuccessStatusCode)
                {
                    string json = JsonSerializer.Serialize(httpResponseMessage, new JsonSerializerOptions() { WriteIndented = true});
                    return IQueryResult<IEnumerable<Todo>>.Failure(json);
                }

                string content = httpResponseMessage.Content.ReadAsStringAsync().Result;

                return IQueryResult<IEnumerable<Todo>>.Success(JsonSerializer.Deserialize<IEnumerable<Todo>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!);
            }
            catch (Exception ex)
            {
                return IQueryResult<IEnumerable<Todo>>.Failure(ex.Message);
            }
        }
    }
}

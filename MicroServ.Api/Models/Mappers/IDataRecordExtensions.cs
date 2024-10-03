using MicroServ.Api.Models.Entities;
using System.Data;

namespace MicroServ.Api.Models.Mappers
{
    internal static class IDataRecordExtensions
    {
        internal static Todo ToTodo(this IDataRecord record)
        {
            return new Todo((int)record["Id"], (string)record["Title"]);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace WebFrontEnd.Contracts
{
    public interface IRemoteTodoService
    {
        Task<List<TodoItem>> GetAll();
        Task<string> Add(TodoItem item);
        Task<string> Update(TodoItem item);
        Task<string> Delete(string id);
        Task<TodoItem> Get(string id);
    }
}
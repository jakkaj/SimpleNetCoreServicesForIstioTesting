using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;
using WebFrontEnd.Contracts;

namespace WebFrontEnd.Services
{
    public class RemoteTodoService : IRemoteTodoService
    {
        private const string SERVICEBASE = "http://services/api/todo";


        private WebClient _wc
        {
            get
            {
                var wc = new WebClient();
                wc.Headers.Add("Content-Type", "application/json");

                return wc;
            }
        }
       

        public async Task<string> Add(TodoItem item)
        {
            var ser = _serialise(item);
           
            try
            {
                var result = await _wc.UploadStringTaskAsync(SERVICEBASE, "POST", ser);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            
        }

        public async Task<string> Delete(string id)
        {
            var result = await _wc.UploadStringTaskAsync($"{SERVICEBASE}/{id}", "DELETE", "");

            return result;
        }

        public async Task<string> Update(TodoItem item)
        {
            var ser = _serialise(item);

            var result = await _wc.UploadStringTaskAsync($"{SERVICEBASE}/{item.Id}", "PUT", ser);

            return result;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            var result = await _wc.DownloadStringTaskAsync(SERVICEBASE);

            if (string.IsNullOrWhiteSpace(result)) 
            {
                return null;
            }

            var obj = _deserialise<List<TodoItem>>(result);

            return obj;
        }

        public async Task<TodoItem> Get(string id)
        {
            var result = await _wc.DownloadStringTaskAsync($"{SERVICEBASE}/{id}");

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }

            var obj = _deserialise<TodoItem>(result);

            return obj;
        }

        private string _serialise<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private T _deserialise<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}

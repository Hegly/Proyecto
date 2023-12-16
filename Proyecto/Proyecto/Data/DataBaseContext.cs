using Proyecto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClase2.Data
{
    public class DataBaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DataBaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<ToDoItem>().Wait();
        }

        //Guardar la informacion
        public async Task<int> InsertItemAsyn(ToDoItem item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<List<ToDoItem>> GetItemsAsync()
        {
            return await Connection.Table<ToDoItem>().ToListAsync();
        }

        public async Task<int> DeleteItemAsync(ToDoItem item)
        {
            return await Connection.DeleteAsync(item);
        }

        internal async Task<int> UpdateItemAsync(ToDoItem item)
        {
            return await Connection.UpdateAsync(item);
        }
    }
}
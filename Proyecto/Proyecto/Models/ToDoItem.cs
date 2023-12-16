using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}

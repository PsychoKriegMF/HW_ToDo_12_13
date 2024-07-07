using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ToDo_12_13
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ToDo() { }
        public ToDo(string title, DateTime date, string description = "Нет описания")
        {
            this.Title = title;
            this.Date = date;
            this.Description = description;
        }
    }
}

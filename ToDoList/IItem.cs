using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public interface IItem
    {
         int Id { get; set; }
         string Nome { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Status
    {
        public Status(int indice, string status)
        {
            Descricao = status;
            Indice = indice;
        }
        public int Indice { get; private set; }
        public string Descricao { get; private set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}

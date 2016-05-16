using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Projetos :IItem
    {
        public Projetos(int id, string nome)
        {
            _id = id;
            _nome = nome;
        }

        private int _id = -1;

        private string _nome = "";

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public override string ToString()
        {
            return _nome;
        }
    }
}

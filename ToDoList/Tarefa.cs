using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Tarefa
    {
        public Tarefa(int id, int idProgramador, int idPrograma, string descricaoAcao, string nomePrograma,
            string nomeProgramador, DateTime prazo, string titulo, int status)
        {
            _id = id;
            _idProgramador = idProgramador;
            _idPrograma = idPrograma;
            _descricaoAcao = descricaoAcao;
            _nomePrograma = nomePrograma;
            _nomeProgramador = nomeProgramador;
            _prazo = prazo;
            _titulo = titulo;
            _status = status;
        }

        private string _titulo = "";

        private int _id = -1;

        private int _idProgramador = -1;
        
        private int _idPrograma = -1;

        private string _descricaoAcao = "";

        private string _nomePrograma = "";

        private string _nomeProgramador = "";

        private int _status = -1;
        
        private DateTime _prazo = DateTime.MinValue;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdProgramador
        {
            get { return _idProgramador; }
            set { _idProgramador = value; }
        }

        public int IdPrograma
        {
            get { return _idPrograma; }
            set { _idPrograma = value; }
        }

        public string DescricaoAcao
        {
            get { return _descricaoAcao; }
            set { _descricaoAcao = value; }
        }

        public string NomePrograma
        {
            get { return _nomePrograma; }
            set { _nomePrograma = value; }
        }

        public string NomeProgramador
        {
            get { return _nomeProgramador; }
            set { _nomeProgramador = value; }
        }

        public DateTime Prazo
        {
            get { return _prazo; }
            set { _prazo = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}

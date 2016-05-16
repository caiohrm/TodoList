using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList
{
    public class BasicoColuna :IColunaGrade
    { 
        
        #region IColunas Members


        private Type _tipoDado = typeof (string);

        public Type TipoDado
        {
            get { return _tipoDado;}
            set { _tipoDado = value;}
        }

        private string _identificador = "";

        public string Identificador
        {
            get { return _identificador; }
            set { _identificador = value; }
        }

        private bool _isKey = false;

        public bool IsKey
        {
            get { return _isKey; }
            set { _isKey = value; }
        }

        private string _titulo = "";

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }


        private string _descricao = "";

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }


        private bool _ehInterno = false;

        public bool EhInterno
        {
            get { return _ehInterno; }
            set { _ehInterno = value; }
        }


        private bool _ehRequerido = false;

        public bool EhRequerido
        {
            get { return _ehRequerido; }
            set { _ehRequerido = value; }
        }


        private bool _ehVisivel = true;

        public bool EhVisivel
        {
            get { return _ehVisivel; }
            set { _ehVisivel = value; }
        }


        private string _vinculo = "";

        public string Vinculo
        {
            get { return _vinculo; }
            set { _vinculo = value; }
        }


        private int _tamanho = 0;

        public int Tamanho
        {
            get { return _tamanho; }
            set { _tamanho = value; }
        }


        public override string ToString()
        {
            return Titulo;
        }

        #endregion

    }
}

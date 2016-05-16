using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ToDoList
{
    public class DbSessao
    {
        private static volatile DbSessao msessao;
        private static object m_sync = new object();
        public static DbSessao Instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (msessao == null)
                {
                    lock (m_sync)
                    {
                        if (msessao == null)
                            msessao = new DbSessao();
                    }
                }
                return msessao;
            }
        }

        public IDbConnection Conection
        {
            get { return _connect; }
            set { _connect = value; }
        }

        public string CONNECTION_STRING = "Server={0};Port={1};User Id={2};Password={3};Database={4};Pooling=false;ContinuousProcessing=true;CommandTimeout=3";

         IDbConnection _connect = null;


        public bool Connect(string servidor, string porta, string usuario, string senha, string nomeBanco)
        {
            if(string.IsNullOrEmpty(servidor) || string.IsNullOrEmpty(porta) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(nomeBanco))
                return false;
            CONNECTION_STRING = string.Format(CONNECTION_STRING, servidor, porta, usuario, senha, nomeBanco);
            return CreateConection(CONNECTION_STRING);
        }

        private bool CreateConection(string con)
        {
            try
            {
                if (_connect == null)
                    _connect = new NpgsqlConnection(con);
                if (_connect.State == ConnectionState.Closed)
                    _connect.Open();
            }
            catch (Exception ee)
            {

                return false;
            }
            return true;
        }
        public IDbCommand CreateComand()
        {
            return _connect.CreateCommand();
        }

    }
}

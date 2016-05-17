using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public class FuncaoGlobal
    {

        private static volatile FuncaoGlobal msessao;
        private static object m_sync = new object();
        public static FuncaoGlobal Instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (msessao == null)
                {
                    lock (m_sync)
                    {
                        if (msessao == null)
                            msessao = new FuncaoGlobal();
                    }
                }
                return msessao;
            }
        }
        private delegate object AddToCombo();
        public void CarregaProgramas(ComboBox CbProjeto, Control control)
        {
            List<Projetos> lstProjetos = new List<Projetos>();
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = "select * from programa";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstProjetos.Add(new Projetos(reader.GetInt32(reader.GetOrdinal("nid____programa")),
                            reader.GetString(reader.GetOrdinal("vnome____programa"))));
                    }
                    reader.Close();
                }
            }
            AddToCombo delegateCombo = delegate()
            {
                CbProjeto.Items.Clear();
                CbProjeto.Items.Add(new Projetos(0, "[SELECIONAR]"));
                CbProjeto.Items.AddRange(lstProjetos.ToArray());
                CbProjeto.SelectedIndex = 0;
                return null;
            };

            control.Invoke(delegateCombo);
        }

        public void CarregaStatus(ComboBox CbStatus, Control control)
        {
            List<Status> lstProgramador = new List<Status>();
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = "select * from status";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstProgramador.Add(new Status(reader.GetInt32(reader.GetOrdinal("nid____status")),
                            reader.GetString(reader.GetOrdinal("vdescristatus"))));
                    }
                    reader.Close();
                }
            }
            AddToCombo delegateCombo = delegate()
            {
                //CbStatus.Items.Clear();
                CbStatus.Items.AddRange(lstProgramador.ToArray());
                CbStatus.SelectedIndex = 1;
                return null;
            };
            control.Invoke(delegateCombo);

        }


        public void CarregaProgramadores(ComboBox CbProgramador, Control control)
        {
            List<Programador> lstProgramador = new List<Programador>();
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = "select * from programador";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstProgramador.Add(new Programador(reader.GetInt32(reader.GetOrdinal("nid____programador")),
                            reader.GetString(reader.GetOrdinal("vnome__programador"))));
                    }
                    reader.Close();
                }
            }
            AddToCombo delegateCombo = delegate()
            {
                CbProgramador.Items.Clear();
                CbProgramador.Items.Add(new Programador(0, "[SELECIONAR]"));
                CbProgramador.Items.AddRange(lstProgramador.ToArray());
                CbProgramador.SelectedIndex = 0;
                return null;
            };
            control.Invoke(delegateCombo);

        }

        public string[] GetMac()
        {
            IEnumerable<string> macAddr =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                    );
            return macAddr.ToArray();
        }



    }
}

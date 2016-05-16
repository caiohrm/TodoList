using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using Npgsql;

namespace ToDoList
{
    public partial class FrmToDoList : Form
    {
        public FrmToDoList()
        {
            InitializeComponent();
            Inicializa();
            HandleCreated += Form1_HandleCreated;
            
        }

        private delegate object AddToCombo();

        private void Inicializa()
        {
            CbProgramador.DropDownStyle = ComboBoxStyle.DropDownList;
            CbProjeto.DropDownStyle = ComboBoxStyle.DropDownList;
            StartPosition = FormStartPosition.CenterScreen;
            BtAdd.Click += BtAdd_Click;
            BtConfig.Click += BtConfig_Click;
            LstTarefas.MultiSelect = false;
            LstTarefas.RowHeadersVisible = false;
            LstTarefas.AllowUserToAddRows = false;
            LstTarefas.AllowUserToDeleteRows = false;
            LstTarefas.AllowUserToResizeRows = false;
            LstTarefas.BackgroundColor = Color.White;
            LstTarefas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LstTarefas.DoubleClick += LstTarefas_DoubleClick;
            LstTarefas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            NtNotify.Icon = new Icon("ico.ico");
            NtNotify.Visible = true;
            DefineColunas();
            NotiFy();

        }

        void LstTarefas_DoubleClick(object sender, EventArgs e)
        {
            if(LstTarefas.SelectedRows.Count == 0)
                return;
            Tarefa tarefa = LstTarefas.SelectedRows[0].Tag as Tarefa;
            Tarefa.CarregaTarefa(tarefa);
            
        }

        private void BtConfig_Click(object sender, EventArgs e)
        {
            SalvaConfig();
        }
        static System.Threading.Timer timer;
        static NpgsqlConnection conn; 
        private void NotiFy()
        {

            conn = DbSessao.Instance.Conection as NpgsqlConnection;
            IDbCommand command = conn.CreateCommand();
            conn.Notification += conn_Notification;
            command.CommandText = "listen notifytest";
            command.ExecuteNonQuery();
        }
        void conn_Notification(object sender, NpgsqlNotificationEventArgs e)
        {
            Thread thread = new Thread(delegate()
            {
                AddToCombo combo = delegate
                {
                    
                    VerificaProgramador(e.AdditionalInformation);
                    return null;
                };
                Invoke(combo);
            });
            thread.Start();
        }

        private void VerificaProgramador(string id)
        {
            string mac = "";
            string nome = "";
            string criador = "";
            int status = -1;
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = string.Format("SELECT todo.vcreatotodolist, "+
                                                           "pro.vnome__programador, "+
                                                           "pro.vmac___config," +
                                                           "nstate__todolist "+
                                                    "FROM todolist as todo, "+
                                                         "programador as pro "+
                                                   "WHERE pro.nid____programador=todo.nid____programador AND "+
                                                         "nid____todolist={0}", id);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int i = reader.GetOrdinal("vmac___config");
                        mac = reader.IsDBNull(i) ? " " : reader.GetString(i);
                        nome = reader.GetString(reader.GetOrdinal("vnome__programador"));
                        criador = reader.GetString(reader.GetOrdinal("vcreatotodolist"));
                        status = reader.GetInt32(reader.GetOrdinal("nstate__todolist"));
                    }
                    reader.Close();
                }
            }
            string[] macs = FuncaoGlobal.Instance.GetMac();
            if (macs.Contains(mac))
                    NtNotify.ShowBalloonTip(5000, "Nova tarefa", string.Format("{0} você possui uma nova tarefa",nome), ToolTipIcon.Info);
            else if (macs.Contains(criador) && status!=1)
                   NtNotify.ShowBalloonTip(5000, "Alteração status", string.Format("{0} alterou o status de uma tarefa", nome), ToolTipIcon.Info);
            CarregaLista();
        }


        private void SalvaConfig()
        {
            Programador programador = (Programador) CbProgramador.SelectedItem;
            Projetos projetos = (Projetos) CbProjeto.SelectedItem;
            if (programador.Id == 0 || projetos.Id == 0)
                return;
            string macAddr = FuncaoGlobal.Instance.GetMac().FirstOrDefault();
            string sql = "";
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText =
                    string.Format(
                        "update programador set  nid____programa={0},vmac___config='{1}' where nid____programador={2}",
                        projetos.Id, macAddr, programador.Id);
                command.ExecuteNonQuery();
            }
        }

        private void CarregaConfig()
        {
            IEnumerable<string> macs = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString());
            int programador = 0;
            int programa = 0;
            foreach (string item in macs)
            {
                using (IDbCommand command = DbSessao.Instance.CreateComand())
                {
                    command.CommandText = string.Format("select * from programador where vmac___config='{0}'", item);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            programador = reader.GetInt32(reader.GetOrdinal("nid____programador"));
                            programa = reader.GetInt32(reader.GetOrdinal("nid____programa"));

                        }
                        reader.Close();
                    }
                }
                if(programador ==0 && programa ==0)
                    continue;
                AddToCombo delegateCombo = delegate()
                {
                    CbProjeto.SelectedItem = CbProjeto.Items.Cast<Projetos>().FirstOrDefault(x => x.Id == programa);
                    CbProgramador.SelectedItem = CbProgramador.Items.Cast<Programador>().FirstOrDefault(x => x.Id == programador);
                    return null;
                };
                Invoke(delegateCombo);
                return;
            }
        }

        void BtAdd_Click(object sender, EventArgs e)
        {
            Tarefa.ShowDialog();
            //CarregaLista();
        }

        private void DefineColunas()
        {
            foreach (DataGridViewTextBoxColumn cl in from item in LstColunas where item.EhVisivel && !item.EhInterno select new DataGridViewTextBoxColumn { Name = item.Titulo, FillWeight = item.Tamanho, Tag = item })
            {
                
                LstTarefas.Columns.Add(cl);
            }
        }

        void CbProgramador_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaLista();
        }

        private void CarregaLista()
        {
            
            LstTarefas.Rows.Clear();
            Projetos projetos = CbProjeto.SelectedItem as Projetos;
            Programador programador = CbProgramador.SelectedItem as Programador;
            if (projetos == null || programador == null)
                return;
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = string.Format("SELECT nid____todolist, " +
                                                            "todo.nid____programador, " +
                                                            "todo.nid____programa, " +
                                                            "vtitulotodolist,"+
                                                            "vdescritodolist, " +
                                                            "vnome____programa, " +
                                                            "vnome__programador," +
                                                            "dprazo_todolist," +
                                                            "nstate_todolist " +
                                                     "FROM todolist AS todo, " +
                                                            "programador AS pro, " +
                                                            "programa AS grama " +
                                                    "WHERE (0={0} or todo.nid____programador = {0}) AND  " +
                                                            "(0={1} or todo.nid____programa = {1}) AND " +
                                                            "pro.nid____programador = todo.nid____programador AND " +
                                                            "todo.nid____programa=grama.nid____programa " +
                                                            "order by nid____programador", programador.Id,
                    projetos.Id);
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarefa tarefa = new Tarefa(
                            reader.GetInt32(reader.GetOrdinal("nid____todolist")),
                            reader.GetInt32(reader.GetOrdinal("nid____programador")),
                            reader.GetInt32(reader.GetOrdinal("nid____programa")),
                            reader.GetString(reader.GetOrdinal("vdescritodolist")),
                            reader.GetString(reader.GetOrdinal("vnome____programa")),
                            reader.GetString(reader.GetOrdinal("vnome__programador")),
                            reader.GetDateTime(reader.GetOrdinal("dprazo_todolist")),
                            reader.GetString(reader.GetOrdinal("vtitulotodolist")),
                            reader.GetInt32(reader.GetOrdinal("nstate_todolist"))
                            );

                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(LstTarefas, new string[]
                        {
                            tarefa.NomeProgramador,
                            tarefa.NomePrograma,
                            tarefa.Titulo,
                            tarefa.Prazo.ToString()
                        });
                        row.Tag = tarefa;
                        LstTarefas.Rows.Add(row);

                    }
                    reader.Close();
                }
            }
        }

        void Form1_HandleCreated(object sender, EventArgs e)
        {
            if (!DbSessao.Instance.Connect("192.168.10.200", "5432", "postgres", "postgres", "PgToDoList"))
            {
                MessageBox.Show("Conexão banco de dados falhou");
                return;
            }
            
            Thread thread = new Thread(delegate()
            {
                FuncaoGlobal.Instance.CarregaProgramas(CbProjeto,this);
                FuncaoGlobal.Instance.CarregaProgramadores(CbProgramador, this);
                CarregaConfig();
                //NotiFyTest();
                AddToCombo deleToCombo = delegate()
                {
                    CarregaLista();
                    return null;
                };
                Invoke(deleToCombo);
                CbProgramador.SelectedIndexChanged += CbProgramador_SelectedIndexChanged;
                CbProjeto.SelectedIndexChanged += CbProgramador_SelectedIndexChanged;
            });
            thread.Start();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios.SetCadastro = FrmCadastro.Programador;
            Usuarios.ShowDialog();
            FuncaoGlobal.Instance.CarregaProgramadores(CbProgramador, this);
            
        }

        private FrmCadastro _frmUsuarios = null;
        public FrmCadastro Usuarios
        {
            get { return (_frmUsuarios ?? (_frmUsuarios = new FrmCadastro())); }
        }

        private FrmTarefa _frmTarefa = null;
        public FrmTarefa Tarefa
        {
            get { return (_frmTarefa ?? (_frmTarefa = new FrmTarefa())); }
        }

        private void programasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios.SetCadastro = FrmCadastro.Projetos;
            Usuarios.ShowDialog();
            FuncaoGlobal.Instance.CarregaProgramas(CbProjeto, this);
        }

        private List<IColunaGrade> _lstColunas = null;

        private List<IColunaGrade> LstColunas
        {
            get
            {
                if (_lstColunas == null)
                {
                    _lstColunas = new List<IColunaGrade>();
                    IColunaGrade col = new BasicoColuna()
                    {
                        Descricao = "Id produto",
                        Identificador = "nid_todolist",
                        IsKey = true,
                        Tamanho = 0,
                        EhInterno = true,

                        Titulo = "Id tarefa"
                    };
                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Programador",
                        Identificador = "vnome__programador",
                        IsKey = false,
                        EhVisivel = true,
                        Tamanho = 60,
                        Titulo = "Programador",
                    };
                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Programa",
                        Identificador = "vnome____programa",
                        IsKey = false,
                        EhVisivel = true,
                        Tamanho = 60,
                        Titulo = "Programa",
                    };
                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Programador",
                        Identificador = "nid____programador",
                        IsKey = false,
                        EhInterno =true,
                        Tamanho = 400,
                        Titulo = "id programador",
                    };
                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Programa",
                        Identificador = "nid____programa",
                        IsKey = false,
                        Tamanho = 200,
                        EhInterno = true,
                        Titulo = "programa"
                    };

                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Descricao",
                        Identificador = "vdescritodolist",
                        IsKey = false,
                        EhVisivel = true,
                        EhInterno = false,
                        Tamanho = 170,
                        Titulo = "Descricao",
                    };
                    _lstColunas.Add(col);
                    col = new BasicoColuna()
                    {
                        Descricao = "Prazo",
                        Identificador = "dprazo_todolist",
                        IsKey = false,
                        EhVisivel = true,
                        EhInterno = false,
                        Tamanho = 100,
                        Titulo = "Prazo",
                    };
                    _lstColunas.Add(col);

                }
                return _lstColunas;
            }
        }
   
    }
}


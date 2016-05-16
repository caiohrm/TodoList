using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class FrmTarefa : Form
    {
        public FrmTarefa()
        {
            InitializeComponent();
            HandleCreated += FrmTarefa_HandleCreated;
            StartPosition = FormStartPosition.CenterScreen;
            Closing += FrmTarefa_Closing;
            BtAdd.Click += BtAdd_Click;
            Inicializa();
        }

        void FrmTarefa_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Reinicializa();
            e.Cancel = true;
            Hide();
        }

        private void Inicializa()
        {
            CbProgramador.DropDownStyle = ComboBoxStyle.DropDownList;
            CbProjeto.DropDownStyle = ComboBoxStyle.DropDownList;
            CbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            DtPrazo.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Reinicializa();
                this.Hide();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Reinicializa()
        {
            CbProgramador.SelectedIndex = 0;
            CbProjeto.SelectedIndex = 0;
            TxTitulo.Text = "";
            TxDescricao.Text = "";
            CbStatus.Enabled = false;
            _tarefa = null;
        }

        void BtAdd_Click(object sender, EventArgs e)
        {
            Programador programador = CbProgramador.SelectedItem as Programador;
            Projetos projeto = CbProjeto.SelectedItem as Projetos;
            Status status = CbStatus.SelectedItem as Status;
            if (programador== null || programador.Id == 0)
            {
                MessageBox.Show("Selecione um programador");
                return;
            }
            if (projeto == null || projeto.Id == 0)
            {
                MessageBox.Show("Selecione um projeto");
                return;
            }
            if (string.IsNullOrEmpty(TxTitulo.Text))
            {
                MessageBox.Show("Defina um titulo para a tarefa");
                return;
            }
            if (string.IsNullOrEmpty(TxDescricao.Text))
            {
                MessageBox.Show("Defina uma descrição para a tarefa");
                return;
            }
            if (DtPrazo.Value < DateTime.Now && _tarefa != null)
            {
                MessageBox.Show("Defina um prazo válido");
                return;
            }

            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                if (_tarefa == null)
                {
                   command.CommandText  = string.Format("INSERT into todolist(nid____programador," +
                                                  "nid____programa," +
                                                  "vtitulotodolist," +
                                                  "vdescritodolist, " +
                                                  "vcreatotodolist," +
                                                  "dprazo_todolist," +
                                                  "nstate_todolist)" +
                                                  "VALUES ({0}," +
                                                  "{1}," +
                                                  "'{2}'," +
                                                  "'{3}'," +
                                                  "'{4}'," +
                                                  "'{5}'," +
                                                  "{6});",
                        programador.Id,
                        projeto.Id,
                        TxTitulo.Text,
                        TxDescricao.Text,
                        FuncaoGlobal.Instance.GetMac().FirstOrDefault(),
                        DtPrazo.Value.ToString("dd/MM/yyyy HH:mm:ss"),
                        "1");
                }
                else
                {
                    command.CommandText =
                    string.Format("UPDATE todolist " +
                                  "SET nid____programador={0}," +
                                        "nid____programa={1}," +
                                        "vtitulotodolist='{2}'," +
                                        "vdescritodolist='{3}'," +
                                        "dprazo_todolist='{4}'," +
                                        "nstate_todolist={5} " +
                                  "WHERE nid____todolist={6}",
                        programador.Id,
                        projeto.Id,
                        TxTitulo.Text,
                        TxDescricao.Text,
                        DtPrazo.Value.ToString("dd/mm/yyyy HH:mm:ss"),
                        status.Indice,
                        _tarefa.Id);
                }
                
                
                 command.ExecuteNonQuery();
            }
            Reinicializa();
            Hide();
        }

        private Tarefa _tarefa = null;
        public void CarregaTarefa(Tarefa tarefa)
        {
            if (tarefa == null)
            {
                MessageBox.Show("Tarefa não pode ser nula");
                return;
            }
            _tarefa = tarefa;
            if (CbStatus.Items.Count != 0)
                CarregaTarefa();
            Show();
        }

        private void CarregaTarefa()
        {
            CbStatus.Enabled = true;
            CbStatus.SelectedItem = CbStatus.Items.Cast<Status>().FirstOrDefault(x => x.Indice == _tarefa.Status);
            CbProjeto.SelectedItem = CbProjeto.Items.Cast<Projetos>().FirstOrDefault(x => x.Id == _tarefa.IdPrograma);
            CbProgramador.SelectedItem = CbProgramador.Items.Cast<Programador>().FirstOrDefault(x => x.Id == _tarefa.IdProgramador);
            TxTitulo.Text = _tarefa.Titulo;
            TxDescricao.Text = _tarefa.DescricaoAcao;

        }
        private delegate object AddToCombo();
        void FrmTarefa_HandleCreated(object sender, EventArgs e)
        {
            Thread thread = new Thread(delegate()
            {
                FuncaoGlobal.Instance.CarregaProgramas(CbProjeto, this);
                FuncaoGlobal.Instance.CarregaProgramadores(CbProgramador, this);
                FuncaoGlobal.Instance.CarregaStatus(CbStatus, this);
                AddToCombo delegateCombo = delegate()
                {
                    CarregaTarefa();
                    return null;
                };
                if (_tarefa != null)
                {
                    Invoke(delegateCombo);
                }
            });
            thread.Start();

            
        }
    }
}


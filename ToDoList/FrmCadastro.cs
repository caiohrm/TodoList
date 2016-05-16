using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
            Incializa();
            Shown+= Form1_HandleCreated;
            
        }
        public static int Programador =1;
        public static int Projetos = 2;
        private int _setCadastro = 1;
        public int SetCadastro
        {
            get { return _setCadastro; }
            set
            {
                _setCadastro = value;
                TxProgramador.Text = "";
            }
        }

        private void Incializa()
        {
            LstProgramadores.MultiSelect = false;
            LstProgramadores.View = View.List;
            LstProgramadores.SelectedIndexChanged += LstProgramadores_SelectedIndexChanged;
            BtAdd.Click += BtAdd_Click;
            BtRemove.Click += BtRemove_Click;
            StartPosition = FormStartPosition.CenterScreen;
        }

        void BtRemove_Click(object sender, EventArgs e)
        {
            if (LstProgramadores.SelectedItems.Count == 0)
                return;
            IItem item =LstProgramadores.SelectedItems[0].Tag as IItem;
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {

                command.CommandText = string.Format("delete from {0} where {1}={2}",
                    SetCadastro == Programador ? "programador" : "programa",
                    SetCadastro == Programador ? "nid____programador" : "nid____programa",
                    item.Id);
                command.ExecuteNonQuery();
            }
            CarregaLista();
        }

       

        void BtAdd_Click(object sender, EventArgs e)
        {
            if (SetCadastro == Programador)
                AddProgramador();
            else if (SetCadastro == Projetos)
                AddProjetos();
            CarregaLista();
        }

        void LstProgramadores_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LstProgramadores.SelectedItems.Count == 0)
                return;
            TxProgramador.Text = LstProgramadores.SelectedItems[0].Text;

        }

        private delegate object AddToCombo();

        private void Form1_HandleCreated(object sender, EventArgs e)
        {
            CarregaLista(); 
        }

        private void CarregaLista()
        {
            if(SetCadastro== Programador)
                CarregaProgramador();
            else if (SetCadastro == Projetos)
                CarregaProgramas();
        }

#region programador

        private void AddProgramador()
        {

            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
             
           
                command.CommandText = string.Format("select * from programador where vnome__programador = '{0}'",
                    TxProgramador.Text);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Já existe um programador com esse nome");
                        return;
                    }
                    reader.Close();
                    reader.Dispose();
                }   
            }
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = string.Format("insert into programador(vnome__programador) values ('{0}')",
                    TxProgramador.Text);
                command.ExecuteNonQuery();
            }
            TxProgramador.Text = "";

        }
        private void CarregaProgramador()
        {
            Thread thread = new Thread(delegate()
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
                    }
                    AddToCombo delegateCombo = delegate()
                    {
                        LbTexto.Text = "Programador";
                        LstProgramadores.Items.Clear();
                        foreach (Programador item in lstProgramador)
                        {
                            LstProgramadores.Items.Add(new ListViewItem() {Text = item.Nome, Tag = item});
                        }
                        //LstProgramadores.Items.AddRange(lstProgramador.ToArray());
                        return null;
                    };

                    Invoke(delegateCombo);
                }
            });
            thread.Start();

        }
#endregion


#region Projetos


        private void AddProjetos()
        {
            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = string.Format("select * from programa where vnome____programa = '{0}'",
                    TxProgramador.Text);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Já existe um programa com esse nome");
                        return;
                    }
                    reader.Close();
                }
            }

            using (IDbCommand command = DbSessao.Instance.CreateComand())
            {
                command.CommandText = string.Format("insert into programa(vnome____programa) values ('{0}')",
                    TxProgramador.Text);
                command.ExecuteNonQuery();
            }
            TxProgramador.Text = "";

        }

        private void CarregaProgramas()
        {
            Thread thread = new Thread(delegate()
            {

                List<Projetos> lstprojetos = new List<Projetos>();
                using (IDbCommand command = DbSessao.Instance.CreateComand())
                {
                    command.CommandText = "select * from programa";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstprojetos.Add(new Projetos(reader.GetInt32(reader.GetOrdinal("nid____programa")),
                                reader.GetString(reader.GetOrdinal("vnome____programa"))));
                        }
                    }
                }
                AddToCombo delegateCombo = delegate()
                {
                    LbTexto.Text = "Projetos";
                    LstProgramadores.Items.Clear();
                    foreach (Projetos item in lstprojetos)
                    {
                        LstProgramadores.Items.Add(new ListViewItem() { Text = item.Nome, Tag = item });
                    }
                    //LstProgramadores.Items.AddRange(lstProgramador.ToArray());
                    return null;
                };

                Invoke(delegateCombo);
            });
            thread.Start();


        }

#endregion


    }
}

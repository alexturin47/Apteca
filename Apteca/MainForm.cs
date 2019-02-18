using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Apteca
{
    public partial class MainForm : Form
    {
        //public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=apteca.accdb;";
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=apteca.accdb";

        public OleDbConnection myConnect;

        public MainForm()
        {
            InitializeComponent();
            myConnect = new OleDbConnection(connectString);
            myConnect.Open();            
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshComboCat();
            refreshGrid();
        }

        private void refreshComboCat()
        {
            string query = "SELECT * FROM тип_медикаментов ORDER BY ID";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBoxCategory.DataSource = dt;
            comboBoxCategory.DisplayMember = "type";
            comboBoxCategory.ValueMember = "ID";
            comboBoxCategory.SelectedIndex = 0;
        }

        private void refreshGrid()
        {
            DataRowView item = (DataRowView)comboBoxCategory.SelectedItem;
            string id = item["ID"].ToString();
            string query = "SELECT * FROM медикаменты WHERE [ID_type] = " + id +  " ORDER BY NAME_MED";
            OleDbCommand command = new OleDbCommand(query, myConnect);

            OleDbDataAdapter da = new OleDbDataAdapter(query, myConnect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["ID_type"].Visible = false;
            dataGridView1.Columns["arrival"].Visible = false;
            dataGridView1.Columns["sell"].Visible = false;
            dataGridView1.Columns["NAME_MED"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["NAME_MED"].HeaderText = "Наименование";

            dataGridView1.Columns["count"].HeaderText = "В наличии";
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ПКМ на строке таблицы - контекстное меню действий");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string item = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var result = MessageBox.Show("Вы собираетесь безвозвратно удалить из базы \n" + item + "\n Вы уверены ? ", "Удаление из базы", MessageBoxButtons.YesNo);


            if ( result == DialogResult.Yes)
            {
                // удаляем из таблицы "Медикаменты"  текущую строку
                if (dataGridView1.CurrentRow != null)
                {
                    string id  = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    string query = "DELETE FROM медикаменты WHERE ID =" + id;
                    OleDbCommand command = new OleDbCommand(query, myConnect);
                    command.ExecuteNonQuery();
                    refreshGrid();
                }
            }
            
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // правка строки с медикаментом
            
            editForm EditForm = new editForm();
            EditForm.Owner = this;
            if (EditForm.ShowDialog() == DialogResult.OK) refreshGrid();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.Owner = this;
            if (formAdd.ShowDialog() == DialogResult.OK) refreshGrid();
        }

        private void поступлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArrival formArrival = new FormArrival();
            formArrival.Owner = this;
            if (formArrival.ShowDialog() == DialogResult.OK) refreshGrid();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnect.Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void продажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSell formSell = new FormSell();
            formSell.Owner = this;
            if(formSell.ShowDialog() == DialogResult.OK) refreshGrid();
        }

        private void категориюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddCat formAddCat = new FormAddCat();
            formAddCat.Owner = this;
            if(formAddCat.ShowDialog() == DialogResult.OK)
            {
                refreshComboCat();
                refreshGrid();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for( int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string str = dataGridView1.Rows[i].Cells["NAME_MED"].Value.ToString().ToLower();

                if(str.Contains(textBox1.Text) == true)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView1.Rows[i].Selected = false;
                }

                if (textBox1.Text == "") dataGridView1.Rows[i].Selected = false;

            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Учет медикаментов v 1.0");
        }

        private void медикаментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myConnect.Close();
            Application.Exit();
        }
    }
}


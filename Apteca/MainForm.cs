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
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=apteca.accdb;";
        //public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=apteca.accdb";

        private OleDbConnection myConnect;

        public MainForm()
        {
            InitializeComponent();
            myConnect = new OleDbConnection(connectString);
            myConnect.Open();            
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aptecaDataSet.медикаменты". При необходимости она может быть перемещена или удалена.
            //this.медикаментыTableAdapter.Fill(this.aptecaDataSet.медикаменты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aptecaDataSet.тип_медикаментов". При необходимости она может быть перемещена или удалена.
            //this.тип_медикаментовTableAdapter.Fill(this.aptecaDataSet.тип_медикаментов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aptecaDataSet.медикаменты". При необходимости она может быть перемещена или удалена.
            //this.медикаментыTableAdapter.Fill(this.aptecaDataSet.медикаменты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aptecaDataSet.тип_медикаментов". При необходимости она может быть перемещена или удалена.
            //this.тип_медикаментовTableAdapter.Fill(this.aptecaDataSet.тип_медикаментов);
        }

        private void refreshGrid()
        {
            int id = (Int32)comboBoxCategory.SelectedValue;
            string query = "SELECT * FROM медикаменты WHERE [ID_type] = id ORDER BY NAME_MED";
            OleDbCommand command = new OleDbCommand(query, myConnect);
            OleDbDataReader reader = command.ExecuteReader();

            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                string namemed = reader["NAME_MED"].ToString();
                string count = reader["count"].ToString();
                string arrival = reader["arrival"].ToString();
                string sell = reader["sell"].ToString();
            }
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
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //медикаментыTableAdapter.Update(aptecaDataSet);
                }
            }
            
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // правка строки с медикаментом
            
            editForm EditForm = new editForm();
            EditForm.Owner = this;
            EditForm.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.Owner = this;
            formAdd.ShowDialog();
        }

        private void поступлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArrival formArrival = new FormArrival();
            formArrival.Owner = this;
            formArrival.ShowDialog();
        }
    }
}


// TODO  закончил на добавлении нового препарата в базу
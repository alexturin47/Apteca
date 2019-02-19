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
    public partial class FormArrival : Form
    {
        public FormArrival()
        {
            InitializeComponent();
        }

        private void FormArrival_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            DataRowView row = (DataRowView)main.comboBoxCategory.SelectedItem;

            labelCategory.Text = "Категория: \t" + row["type"].ToString();
            labelName.Text = "Наименование: \t" + main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Необходимо ввести количество поступивших медикаментов");
                return;
            }

            MainForm main = this.Owner as MainForm;
            string id = main.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            int old_arrival =Convert.ToInt32(main.dataGridView1.CurrentRow.Cells["arrival"].Value);
            string query = "UPDATE медикаменты SET [arrival] = " + (old_arrival+numericUpDown1.Value) + " WHERE ID=" + id;
            OleDbCommand command = new OleDbCommand(query, main.myConnect);
            command.ExecuteNonQuery();
            MessageBox.Show(query);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

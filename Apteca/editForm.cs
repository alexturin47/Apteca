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
    public partial class editForm : Form
    {
        public editForm()
        {
            InitializeComponent();
        }

        private void editForm_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            textBox1.Text = main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;

            string id = main.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            string query = "UPDATE медикаменты SET [NAME_MED] = '" + textBox1.Text + "' WHERE ID = " + id;
            OleDbCommand command = new OleDbCommand( query, main.myConnect);
            command.ExecuteNonQuery();
            Close();
        }
    }
}

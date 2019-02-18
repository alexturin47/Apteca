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
    public partial class FormAddCat : Form
    {
        public FormAddCat()
        {
            InitializeComponent();
        }

        private void FormAddCat_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Сначала введите название новой категории медикаментов");
                return;
            }

            MainForm main = this.Owner as MainForm;

            string query = "INSERT INTO тип_медикаментов ([type]) VALUES ('" + textBox1.Text + "')";

            OleDbCommand command = new OleDbCommand(query, main.myConnect);
            command.ExecuteNonQuery();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

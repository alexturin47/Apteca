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
    public partial class FormSell : Form
    {
        public FormSell()
        {
            InitializeComponent();
            MainForm main = this.Owner as MainForm;
        }

        private void FormSell_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            DataRowView row = (DataRowView)main.comboBoxCategory.SelectedItem;
            labelCat.Text = "Категория: " + row["type"].ToString();
            labelName.Text = "Наименование: " + main.dataGridView1.CurrentRow.Cells["NAME_MED"].Value.ToString();
            string count_nal = main.dataGridView1.CurrentRow.Cells["count"].Value.ToString();
            labelNal.Text = "В наличии: " + count_nal.ToString();
            numericSell.Maximum = Convert.ToInt32(count_nal);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            string id = main.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            int old_sell = Convert.ToInt32(main.dataGridView1.CurrentRow.Cells["sell"].Value);
            string query = "UPDATE медикаменты SET [sell] = " + (old_sell+numericSell.Value) + " WHERE ID = " + id;

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

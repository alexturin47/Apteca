using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            labelCategory.Text = "Категория: " + row["type"].ToString();
            labelName.Text = "Наименование: " + main.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Необходимо ввести количество поступивших медикаментов");
                return;
            }

            MainForm main = this.Owner as MainForm;
            //DataTable dt = main.aptecaDataSet.Tables["медикаменты"];
            //DataRowView row = (DataRowView)main.comboBoxCategory.SelectedItem;
            //DataRow row = main.dataGridView1.CurrentRow;
            MessageBox.Show(main.dataGridView1.CurrentRow.Cells["arrival"].Value.ToString());
            //main.dataGridView1.CurrentRow.Cells["arrival"].Value
            //main.типмедикаментовмедикаментыBindingSource.EndEdit();

            //main.медикаментыTableAdapter.Update(main.aptecaDataSet.медикаменты);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            
            MainForm main = this.Owner as MainForm;

            // проверка на совпадение наименования
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT [NAME_MED] FROM медикаменты ORDER BY NAME_MED", main.myConnect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataView custView = new DataView(dt, "", "NAME_MED", DataViewRowState.CurrentRows);
            int rowIndex = custView.Find(textBox1.Text);

            if (rowIndex != -1)
            {
                MessageBox.Show("Препарат с таким наименованием уже есть в базе!");
                return;
            }


            DataRowView rv = (DataRowView)main.comboBoxCategory.SelectedItem;
            int cat_id = (Int32)rv["ID"];

            string query = "INSERT INTO медикаменты ([NAME_MED],[ID_type], [arrival]) VALUES ('" + textBox1.Text + "', "+ 
                cat_id +", " + counter.Value + ")";
            OleDbCommand command = new OleDbCommand(query, main.myConnect);
            command.ExecuteNonQuery();
            Close();            
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            DataRowView row = (DataRowView)main.comboBoxCategory.SelectedItem;

            labelCategory.Text = "Категория: " + row["type"].ToString();
        }
    }
}

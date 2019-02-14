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
            DataTable dt = main.aptecaDataSet.Tables[0];

            // проверка на совпадение наименования
            DataView custView = new DataView(dt, "", "NAME_MED", DataViewRowState.CurrentRows);

            int rowIndex = custView.Find(textBox1.Text);

            if (rowIndex != -1)
            {
                MessageBox.Show("Препарат с таким наименованием уже есть в базе!");
                return;
            }

            DataRow row = dt.NewRow();
            row["NAME_MED"] = textBox1.Text;
            row["arrival"] = counter.Value;
            row["sell"] = 0;
            row["ID_type"] = main.comboBoxCategory.SelectedValue;
            dt.Rows.Add(row);
            main.типмедикаментовмедикаментыBindingSource.EndEdit();
            main.медикаментыTableAdapter.Update(main.aptecaDataSet);
            main.медикаментыTableAdapter.Fill(main.aptecaDataSet.медикаменты);
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

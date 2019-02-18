namespace Apteca
{
    partial class FormSell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCat = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.numericSell = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelNal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSell)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCat
            // 
            this.labelCat.AutoSize = true;
            this.labelCat.Location = new System.Drawing.Point(13, 13);
            this.labelCat.Name = "labelCat";
            this.labelCat.Size = new System.Drawing.Size(66, 13);
            this.labelCat.TabIndex = 0;
            this.labelCat.Text = "Категория: ";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 39);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(83, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Наименование";
            // 
            // numericSell
            // 
            this.numericSell.Location = new System.Drawing.Point(314, 74);
            this.numericSell.Name = "numericSell";
            this.numericSell.Size = new System.Drawing.Size(42, 20);
            this.numericSell.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Сколько продать?";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(16, 102);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(284, 102);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelNal
            // 
            this.labelNal.AutoSize = true;
            this.labelNal.Location = new System.Drawing.Point(16, 74);
            this.labelNal.Name = "labelNal";
            this.labelNal.Size = new System.Drawing.Size(64, 13);
            this.labelNal.TabIndex = 6;
            this.labelNal.Text = "В наличии: ";
            // 
            // FormSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 145);
            this.Controls.Add(this.labelNal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericSell);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Продажа";
            this.Load += new System.EventHandler(this.FormSell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericSell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCat;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.NumericUpDown numericSell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelNal;
    }
}
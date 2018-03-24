namespace Post
{
    partial class Form1
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cbDetailedMode = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbUploadFile = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.BtnOutput = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbCSV = new System.Windows.Forms.CheckBox();
            this.cbJSON = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Panel1.Controls.Add(this.label7);
            this.Panel1.Controls.Add(this.label6);
            this.Panel1.Controls.Add(this.label5);
            this.Panel1.Controls.Add(this.cbJSON);
            this.Panel1.Controls.Add(this.cbCSV);
            this.Panel1.Controls.Add(this.cbDetailedMode);
            this.Panel1.Controls.Add(this.label3);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.TbUploadFile);
            this.Panel1.Controls.Add(this.BtnBrowse);
            this.Panel1.Controls.Add(this.BtnOutput);
            this.Panel1.Location = new System.Drawing.Point(126, 80);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(703, 285);
            this.Panel1.TabIndex = 9;
            // 
            // cbDetailedMode
            // 
            this.cbDetailedMode.AutoSize = true;
            this.cbDetailedMode.Location = new System.Drawing.Point(481, 82);
            this.cbDetailedMode.Name = "cbDetailedMode";
            this.cbDetailedMode.Size = new System.Drawing.Size(92, 17);
            this.cbDetailedMode.TabIndex = 7;
            this.cbDetailedMode.Text = "detailed mode";
            this.cbDetailedMode.UseVisualStyleBackColor = true;
            this.cbDetailedMode.CheckedChanged += new System.EventHandler(this.cbDetailedMode_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // TbUploadFile
            // 
            this.TbUploadFile.Location = new System.Drawing.Point(36, 39);
            this.TbUploadFile.Name = "TbUploadFile";
            this.TbUploadFile.Size = new System.Drawing.Size(439, 20);
            this.TbUploadFile.TabIndex = 1;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBrowse.Location = new System.Drawing.Point(481, 35);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 31);
            this.BtnBrowse.TabIndex = 2;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnOutput
            // 
            this.BtnOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOutput.Location = new System.Drawing.Point(562, 35);
            this.BtnOutput.Name = "BtnOutput";
            this.BtnOutput.Size = new System.Drawing.Size(75, 31);
            this.BtnOutput.TabIndex = 3;
            this.BtnOutput.Text = "Output";
            this.BtnOutput.UseVisualStyleBackColor = true;
            this.BtnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(164, 98);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(103, 17);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Load a csv file:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbCSV
            // 
            this.cbCSV.AutoSize = true;
            this.cbCSV.Location = new System.Drawing.Point(481, 105);
            this.cbCSV.Name = "cbCSV";
            this.cbCSV.Size = new System.Drawing.Size(47, 17);
            this.cbCSV.TabIndex = 8;
            this.cbCSV.Text = "CSV";
            this.cbCSV.UseVisualStyleBackColor = true;
            this.cbCSV.CheckedChanged += new System.EventHandler(this.cbCSV_CheckedChanged);
            // 
            // cbJSON
            // 
            this.cbJSON.AutoSize = true;
            this.cbJSON.Location = new System.Drawing.Point(481, 128);
            this.cbJSON.Name = "cbJSON";
            this.cbJSON.Size = new System.Drawing.Size(54, 17);
            this.cbJSON.TabIndex = 9;
            this.cbJSON.Text = "JSON";
            this.cbJSON.UseVisualStyleBackColor = true;
            this.cbJSON.CheckedChanged += new System.EventHandler(this.cbJSON_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 500);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox TbUploadFile;
        internal System.Windows.Forms.Button BtnBrowse;
        internal System.Windows.Forms.Button BtnOutput;
        internal System.Windows.Forms.Label Label4;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbDetailedMode;
        private System.Windows.Forms.CheckBox cbJSON;
        private System.Windows.Forms.CheckBox cbCSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}


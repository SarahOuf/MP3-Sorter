namespace FilesProject
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
            this.buttontitle = new System.Windows.Forms.Button();
            this.buttonartist = new System.Windows.Forms.Button();
            this.buttonalbum = new System.Windows.Forms.Button();
            this.buttonyear = new System.Windows.Forms.Button();
            this.buttongenre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.buttonDuration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttontitle
            // 
            this.buttontitle.Location = new System.Drawing.Point(115, 80);
            this.buttontitle.Name = "buttontitle";
            this.buttontitle.Size = new System.Drawing.Size(75, 23);
            this.buttontitle.TabIndex = 0;
            this.buttontitle.Text = "Title";
            this.buttontitle.UseVisualStyleBackColor = true;
            this.buttontitle.Click += new System.EventHandler(this.buttontitle_Click);
            // 
            // buttonartist
            // 
            this.buttonartist.Location = new System.Drawing.Point(202, 80);
            this.buttonartist.Name = "buttonartist";
            this.buttonartist.Size = new System.Drawing.Size(75, 23);
            this.buttonartist.TabIndex = 1;
            this.buttonartist.Text = "Artist";
            this.buttonartist.UseVisualStyleBackColor = true;
            this.buttonartist.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonalbum
            // 
            this.buttonalbum.Location = new System.Drawing.Point(299, 80);
            this.buttonalbum.Name = "buttonalbum";
            this.buttonalbum.Size = new System.Drawing.Size(75, 23);
            this.buttonalbum.TabIndex = 2;
            this.buttonalbum.Text = "Album";
            this.buttonalbum.UseVisualStyleBackColor = true;
            this.buttonalbum.Click += new System.EventHandler(this.buttonalbum_Click);
            // 
            // buttonyear
            // 
            this.buttonyear.Location = new System.Drawing.Point(402, 80);
            this.buttonyear.Name = "buttonyear";
            this.buttonyear.Size = new System.Drawing.Size(75, 23);
            this.buttonyear.TabIndex = 3;
            this.buttonyear.Text = "Year";
            this.buttonyear.UseVisualStyleBackColor = true;
            this.buttonyear.Click += new System.EventHandler(this.buttonyear_Click);
            // 
            // buttongenre
            // 
            this.buttongenre.Location = new System.Drawing.Point(494, 80);
            this.buttongenre.Name = "buttongenre";
            this.buttongenre.Size = new System.Drawing.Size(75, 23);
            this.buttongenre.TabIndex = 4;
            this.buttongenre.Text = "Genre";
            this.buttongenre.UseVisualStyleBackColor = true;
            this.buttongenre.Click += new System.EventHandler(this.buttongenre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sort Music By :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(649, 225);
            this.dataGridView1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search by :";
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Artist",
            "Album",
            "Year",
            "Genre"});
            this.comboBoxSort.Location = new System.Drawing.Point(459, 22);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSort.TabIndex = 9;
            // 
            // buttonDuration
            // 
            this.buttonDuration.Location = new System.Drawing.Point(593, 80);
            this.buttonDuration.Name = "buttonDuration";
            this.buttonDuration.Size = new System.Drawing.Size(75, 23);
            this.buttonDuration.TabIndex = 10;
            this.buttonDuration.Text = "Duration";
            this.buttonDuration.UseVisualStyleBackColor = true;
            this.buttonDuration.Click += new System.EventHandler(this.buttonDuration_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 383);
            this.Controls.Add(this.buttonDuration);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttongenre);
            this.Controls.Add(this.buttonyear);
            this.Controls.Add(this.buttonalbum);
            this.Controls.Add(this.buttonartist);
            this.Controls.Add(this.buttontitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.Button buttontitle;
        private System.Windows.Forms.Button buttonartist;
        private System.Windows.Forms.Button buttonalbum;
        private System.Windows.Forms.Button buttonyear;
        private System.Windows.Forms.Button buttongenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Button buttonDuration;
        }
    }


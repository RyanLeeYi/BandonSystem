
namespace WindowsFormsApp1
{
    partial class TotalOrderList
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
            this.label2 = new System.Windows.Forms.Label();
            this.lboxAllOrders = new System.Windows.Forms.ListBox();
            this.btnDelectOne = new System.Windows.Forms.Button();
            this.btnDelectAll = new System.Windows.Forms.Button();
            this.lbTotalPriceAll = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rbtnClass = new System.Windows.Forms.RadioButton();
            this.rbtnStore = new System.Windows.Forms.RadioButton();
            this.cboxAll = new System.Windows.Forms.ComboBox();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(219, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "列印訂購單";
            // 
            // lboxAllOrders
            // 
            this.lboxAllOrders.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxAllOrders.FormattingEnabled = true;
            this.lboxAllOrders.ItemHeight = 19;
            this.lboxAllOrders.Location = new System.Drawing.Point(12, 65);
            this.lboxAllOrders.Margin = new System.Windows.Forms.Padding(2);
            this.lboxAllOrders.Name = "lboxAllOrders";
            this.lboxAllOrders.Size = new System.Drawing.Size(556, 365);
            this.lboxAllOrders.TabIndex = 11;
            // 
            // btnDelectOne
            // 
            this.btnDelectOne.BackColor = System.Drawing.Color.Gray;
            this.btnDelectOne.FlatAppearance.BorderSize = 0;
            this.btnDelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelectOne.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelectOne.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelectOne.Location = new System.Drawing.Point(13, 52);
            this.btnDelectOne.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelectOne.Name = "btnDelectOne";
            this.btnDelectOne.Size = new System.Drawing.Size(166, 39);
            this.btnDelectOne.TabIndex = 12;
            this.btnDelectOne.Text = "刪除訂單";
            this.btnDelectOne.UseVisualStyleBackColor = false;
            this.btnDelectOne.Click += new System.EventHandler(this.btnDelectOne_Click);
            // 
            // btnDelectAll
            // 
            this.btnDelectAll.BackColor = System.Drawing.Color.Gray;
            this.btnDelectAll.FlatAppearance.BorderSize = 0;
            this.btnDelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelectAll.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelectAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelectAll.Location = new System.Drawing.Point(210, 52);
            this.btnDelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelectAll.Name = "btnDelectAll";
            this.btnDelectAll.Size = new System.Drawing.Size(166, 39);
            this.btnDelectAll.TabIndex = 13;
            this.btnDelectAll.Text = "全部刪除";
            this.btnDelectAll.UseVisualStyleBackColor = false;
            this.btnDelectAll.Click += new System.EventHandler(this.btnDelectAll_Click);
            // 
            // lbTotalPriceAll
            // 
            this.lbTotalPriceAll.AutoSize = true;
            this.lbTotalPriceAll.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbTotalPriceAll.Location = new System.Drawing.Point(9, 18);
            this.lbTotalPriceAll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotalPriceAll.Name = "lbTotalPriceAll";
            this.lbTotalPriceAll.Size = new System.Drawing.Size(101, 22);
            this.lbTotalPriceAll.TabIndex = 19;
            this.lbTotalPriceAll.Text = "總價xx元";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.Location = new System.Drawing.Point(402, 52);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(166, 39);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "全部印出";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // rbtnClass
            // 
            this.rbtnClass.AutoSize = true;
            this.rbtnClass.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnClass.Location = new System.Drawing.Point(277, 15);
            this.rbtnClass.Name = "rbtnClass";
            this.rbtnClass.Size = new System.Drawing.Size(87, 23);
            this.rbtnClass.TabIndex = 21;
            this.rbtnClass.TabStop = true;
            this.rbtnClass.Text = "依班級";
            this.rbtnClass.UseVisualStyleBackColor = true;
            this.rbtnClass.CheckedChanged += new System.EventHandler(this.rbtnClass_CheckedChanged);
            // 
            // rbtnStore
            // 
            this.rbtnStore.AutoSize = true;
            this.rbtnStore.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnStore.Location = new System.Drawing.Point(184, 15);
            this.rbtnStore.Name = "rbtnStore";
            this.rbtnStore.Size = new System.Drawing.Size(87, 23);
            this.rbtnStore.TabIndex = 22;
            this.rbtnStore.TabStop = true;
            this.rbtnStore.Text = "依店家";
            this.rbtnStore.UseVisualStyleBackColor = true;
            this.rbtnStore.CheckedChanged += new System.EventHandler(this.rbtnStore_CheckedChanged);
            // 
            // cboxAll
            // 
            this.cboxAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAll.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboxAll.FormattingEnabled = true;
            this.cboxAll.Location = new System.Drawing.Point(388, 11);
            this.cboxAll.Margin = new System.Windows.Forms.Padding(2);
            this.cboxAll.Name = "cboxAll";
            this.cboxAll.Size = new System.Drawing.Size(172, 30);
            this.cboxAll.TabIndex = 23;
            this.cboxAll.SelectedIndexChanged += new System.EventHandler(this.cboxAll_SelectedIndexChanged);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnAll.Location = new System.Drawing.Point(111, 15);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(67, 23);
            this.rbtnAll.TabIndex = 24;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "全部";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lboxAllOrders);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 442);
            this.panel1.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(191)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.rbtnAll);
            this.panel3.Controls.Add(this.cboxAll);
            this.panel3.Controls.Add(this.rbtnStore);
            this.panel3.Controls.Add(this.rbtnClass);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 49);
            this.panel3.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "訂單分類：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(150)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(-2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 63);
            this.panel2.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnPrint);
            this.panel4.Controls.Add(this.lbTotalPriceAll);
            this.panel4.Controls.Add(this.btnDelectAll);
            this.panel4.Controls.Add(this.btnDelectOne);
            this.panel4.Location = new System.Drawing.Point(12, 519);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 112);
            this.panel4.TabIndex = 27;
            // 
            // TotalOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(607, 640);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TotalOrderList";
            this.Text = "列印訂單";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lboxAllOrders;
        private System.Windows.Forms.Button btnDelectOne;
        private System.Windows.Forms.Button btnDelectAll;
        private System.Windows.Forms.Label lbTotalPriceAll;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rbtnClass;
        private System.Windows.Forms.RadioButton rbtnStore;
        private System.Windows.Forms.ComboBox cboxAll;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

namespace WindowsFormsApp1
{
    partial class MenuTextVer
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboxStore2 = new System.Windows.Forms.ComboBox();
            this.lboxMenu2 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lblPriceEach = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtboxAmount2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalPrice2 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOrder2 = new System.Windows.Forms.Button();
            this.btnOpCart = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picbox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picbox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxStore2
            // 
            this.cboxStore2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStore2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboxStore2.FormattingEnabled = true;
            this.cboxStore2.Location = new System.Drawing.Point(111, 51);
            this.cboxStore2.Name = "cboxStore2";
            this.cboxStore2.Size = new System.Drawing.Size(172, 29);
            this.cboxStore2.TabIndex = 20;
            this.cboxStore2.SelectedIndexChanged += new System.EventHandler(this.cboxStore2_SelectedIndexChanged);
            // 
            // lboxMenu2
            // 
            this.lboxMenu2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxMenu2.FormattingEnabled = true;
            this.lboxMenu2.ItemHeight = 21;
            this.lboxMenu2.Location = new System.Drawing.Point(13, 136);
            this.lboxMenu2.Name = "lboxMenu2";
            this.lboxMenu2.Size = new System.Drawing.Size(270, 130);
            this.lboxMenu2.TabIndex = 21;
            this.lboxMenu2.SelectedIndexChanged += new System.EventHandler(this.lboxMenu2_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(347, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 21);
            this.label9.TabIndex = 24;
            this.label9.Text = "目前所選商品";
            // 
            // lblPriceEach
            // 
            this.lblPriceEach.AutoSize = true;
            this.lblPriceEach.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPriceEach.Location = new System.Drawing.Point(311, 324);
            this.lblPriceEach.Name = "lblPriceEach";
            this.lblPriceEach.Size = new System.Drawing.Size(76, 21);
            this.lblPriceEach.TabIndex = 27;
            this.lblPriceEach.Text = "xxxx元";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(311, 299);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 21);
            this.label12.TabIndex = 28;
            this.label12.Text = "單價";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(9, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 21);
            this.label13.TabIndex = 31;
            this.label13.Text = "品項";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(9, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 21);
            this.label14.TabIndex = 32;
            this.label14.Text = "數量";
            // 
            // txtboxAmount2
            // 
            this.txtboxAmount2.Location = new System.Drawing.Point(13, 323);
            this.txtboxAmount2.Name = "txtboxAmount2";
            this.txtboxAmount2.Size = new System.Drawing.Size(101, 22);
            this.txtboxAmount2.TabIndex = 33;
            this.txtboxAmount2.TextChanged += new System.EventHandler(this.txtboxAmount2_TextChanged);
            this.txtboxAmount2.Leave += new System.EventHandler(this.txtboxAmount2_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(414, 299);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 21);
            this.label15.TabIndex = 34;
            this.label15.Text = "總價";
            // 
            // lblTotalPrice2
            // 
            this.lblTotalPrice2.AutoSize = true;
            this.lblTotalPrice2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalPrice2.Location = new System.Drawing.Point(414, 324);
            this.lblTotalPrice2.Name = "lblTotalPrice2";
            this.lblTotalPrice2.Size = new System.Drawing.Size(76, 21);
            this.lblTotalPrice2.TabIndex = 35;
            this.lblTotalPrice2.Text = "xxxx元";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblProductName.Location = new System.Drawing.Point(370, 76);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 21);
            this.lblProductName.TabIndex = 36;
            this.lblProductName.Text = "商品名稱";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(9, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "目前所選店家名稱";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStoreName.Location = new System.Drawing.Point(201, 10);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(98, 21);
            this.lblStoreName.TabIndex = 38;
            this.lblStoreName.Text = "店家名稱";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(46, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 68);
            this.button1.TabIndex = 39;
            this.button1.Text = "重新整理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOrder2
            // 
            this.btnOrder2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOrder2.Location = new System.Drawing.Point(229, 412);
            this.btnOrder2.Name = "btnOrder2";
            this.btnOrder2.Size = new System.Drawing.Size(136, 68);
            this.btnOrder2.TabIndex = 42;
            this.btnOrder2.Text = "加入購物車";
            this.btnOrder2.UseVisualStyleBackColor = true;
            this.btnOrder2.Click += new System.EventHandler(this.btnOrder2_Click);
            // 
            // btnOpCart
            // 
            this.btnOpCart.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOpCart.Location = new System.Drawing.Point(393, 412);
            this.btnOpCart.Name = "btnOpCart";
            this.btnOpCart.Size = new System.Drawing.Size(136, 68);
            this.btnOpCart.TabIndex = 47;
            this.btnOpCart.Text = "開啟購物車";
            this.btnOpCart.UseVisualStyleBackColor = true;
            this.btnOpCart.Click += new System.EventHandler(this.btnOpCart_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(256, 256);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picbox1
            // 
            this.picbox1.Location = new System.Drawing.Point(315, 100);
            this.picbox1.Name = "picbox1";
            this.picbox1.Size = new System.Drawing.Size(205, 177);
            this.picbox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox1.TabIndex = 49;
            this.picbox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picbox1);
            this.panel1.Controls.Add(this.btnOpCart);
            this.panel1.Controls.Add(this.btnOrder2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblStoreName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.lblTotalPrice2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtboxAmount2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lblPriceEach);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lboxMenu2);
            this.panel1.Controls.Add(this.cboxStore2);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 512);
            this.panel1.TabIndex = 50;
            // 
            // MenuTextVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 536);
            this.Controls.Add(this.panel1);
            this.Name = "MenuTextVer";
            this.Text = "選單式菜單";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboxStore2;
        private System.Windows.Forms.ListBox lboxMenu2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPriceEach;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtboxAmount2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalPrice2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOrder2;
        private System.Windows.Forms.Button btnOpCart;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picbox1;
        private System.Windows.Forms.Panel panel1;
    }
}


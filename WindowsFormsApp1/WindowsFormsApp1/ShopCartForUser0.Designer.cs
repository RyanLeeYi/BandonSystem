
namespace WindowsFormsApp1
{
    partial class ShopCartForUser0
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
            this.btnDeleteCartOne = new System.Windows.Forms.Button();
            this.btnDeleteAllCart = new System.Windows.Forms.Button();
            this.lboxOnOrderCart = new System.Windows.Forms.ListBox();
            this.btnSendOut = new System.Windows.Forms.Button();
            this.btnPlusAmount1 = new System.Windows.Forms.Button();
            this.btnMinusAmount1 = new System.Windows.Forms.Button();
            this.txtboxAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeAmount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.groupBoxShopCart = new System.Windows.Forms.GroupBox();
            this.txtTotalCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToOrders = new System.Windows.Forms.Button();
            this.groupBoxOrders = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnToShopCart = new System.Windows.Forms.Button();
            this.btnBuyAgain = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lboxOrderDetail = new System.Windows.Forms.ListBox();
            this.lboxOrders = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelShopCart = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxShopCart.SuspendLayout();
            this.groupBoxOrders.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelShopCart.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelOrders.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteCartOne
            // 
            this.btnDeleteCartOne.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteCartOne.FlatAppearance.BorderSize = 0;
            this.btnDeleteCartOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCartOne.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteCartOne.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteCartOne.Location = new System.Drawing.Point(740, 309);
            this.btnDeleteCartOne.Name = "btnDeleteCartOne";
            this.btnDeleteCartOne.Size = new System.Drawing.Size(157, 36);
            this.btnDeleteCartOne.TabIndex = 1;
            this.btnDeleteCartOne.Text = "刪除所選商品";
            this.btnDeleteCartOne.UseVisualStyleBackColor = false;
            this.btnDeleteCartOne.Click += new System.EventHandler(this.btnDeleteCartOne_Click);
            // 
            // btnDeleteAllCart
            // 
            this.btnDeleteAllCart.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteAllCart.FlatAppearance.BorderSize = 0;
            this.btnDeleteAllCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllCart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteAllCart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteAllCart.Location = new System.Drawing.Point(740, 351);
            this.btnDeleteAllCart.Name = "btnDeleteAllCart";
            this.btnDeleteAllCart.Size = new System.Drawing.Size(157, 35);
            this.btnDeleteAllCart.TabIndex = 43;
            this.btnDeleteAllCart.Text = "清空購物車";
            this.btnDeleteAllCart.UseVisualStyleBackColor = false;
            this.btnDeleteAllCart.Click += new System.EventHandler(this.btnDeleteAllCart_Click);
            // 
            // lboxOnOrderCart
            // 
            this.lboxOnOrderCart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxOnOrderCart.FormattingEnabled = true;
            this.lboxOnOrderCart.ItemHeight = 19;
            this.lboxOnOrderCart.Location = new System.Drawing.Point(18, 21);
            this.lboxOnOrderCart.Name = "lboxOnOrderCart";
            this.lboxOnOrderCart.Size = new System.Drawing.Size(685, 365);
            this.lboxOnOrderCart.TabIndex = 44;
            this.lboxOnOrderCart.SelectedIndexChanged += new System.EventHandler(this.lboxOnOrderCartImg_SelectedIndexChanged);
            // 
            // btnSendOut
            // 
            this.btnSendOut.BackColor = System.Drawing.Color.Black;
            this.btnSendOut.FlatAppearance.BorderSize = 0;
            this.btnSendOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOut.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSendOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSendOut.Location = new System.Drawing.Point(740, 32);
            this.btnSendOut.Name = "btnSendOut";
            this.btnSendOut.Size = new System.Drawing.Size(157, 39);
            this.btnSendOut.TabIndex = 45;
            this.btnSendOut.Text = "送出訂單";
            this.btnSendOut.UseVisualStyleBackColor = false;
            this.btnSendOut.Click += new System.EventHandler(this.btnSendOut_Click);
            // 
            // btnPlusAmount1
            // 
            this.btnPlusAmount1.BackColor = System.Drawing.Color.Gray;
            this.btnPlusAmount1.FlatAppearance.BorderSize = 0;
            this.btnPlusAmount1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusAmount1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPlusAmount1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPlusAmount1.Location = new System.Drawing.Point(864, 101);
            this.btnPlusAmount1.Name = "btnPlusAmount1";
            this.btnPlusAmount1.Size = new System.Drawing.Size(37, 35);
            this.btnPlusAmount1.TabIndex = 46;
            this.btnPlusAmount1.Text = "+";
            this.btnPlusAmount1.UseVisualStyleBackColor = false;
            this.btnPlusAmount1.Click += new System.EventHandler(this.btnPlusAmount1_Click);
            // 
            // btnMinusAmount1
            // 
            this.btnMinusAmount1.BackColor = System.Drawing.Color.Gray;
            this.btnMinusAmount1.FlatAppearance.BorderSize = 0;
            this.btnMinusAmount1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinusAmount1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMinusAmount1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMinusAmount1.Location = new System.Drawing.Point(735, 102);
            this.btnMinusAmount1.Name = "btnMinusAmount1";
            this.btnMinusAmount1.Size = new System.Drawing.Size(37, 35);
            this.btnMinusAmount1.TabIndex = 47;
            this.btnMinusAmount1.Text = "-";
            this.btnMinusAmount1.UseVisualStyleBackColor = false;
            this.btnMinusAmount1.Click += new System.EventHandler(this.btnMinusAmount1_Click);
            // 
            // txtboxAmount
            // 
            this.txtboxAmount.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtboxAmount.Location = new System.Drawing.Point(778, 101);
            this.txtboxAmount.Name = "txtboxAmount";
            this.txtboxAmount.Size = new System.Drawing.Size(80, 36);
            this.txtboxAmount.TabIndex = 48;
            this.txtboxAmount.Text = "0";
            this.txtboxAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtboxAmount.Leave += new System.EventHandler(this.txtboxAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(741, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 49;
            this.label1.Text = "訂購商品數量";
            // 
            // btnChangeAmount
            // 
            this.btnChangeAmount.BackColor = System.Drawing.Color.Black;
            this.btnChangeAmount.FlatAppearance.BorderSize = 0;
            this.btnChangeAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeAmount.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChangeAmount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangeAmount.Location = new System.Drawing.Point(759, 143);
            this.btnChangeAmount.Name = "btnChangeAmount";
            this.btnChangeAmount.Size = new System.Drawing.Size(109, 34);
            this.btnChangeAmount.TabIndex = 50;
            this.btnChangeAmount.Text = "更改數量";
            this.btnChangeAmount.UseVisualStyleBackColor = false;
            this.btnChangeAmount.Click += new System.EventHandler(this.btnChangeAmount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 51;
            this.label2.Text = "目前所選商品";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblProductName.Location = new System.Drawing.Point(14, 52);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 21);
            this.lblProductName.TabIndex = 52;
            this.lblProductName.Text = "商品名稱";
            // 
            // groupBoxShopCart
            // 
            this.groupBoxShopCart.BackColor = System.Drawing.Color.White;
            this.groupBoxShopCart.Controls.Add(this.lboxOnOrderCart);
            this.groupBoxShopCart.Controls.Add(this.btnDeleteAllCart);
            this.groupBoxShopCart.Controls.Add(this.btnDeleteCartOne);
            this.groupBoxShopCart.Controls.Add(this.label1);
            this.groupBoxShopCart.Controls.Add(this.txtboxAmount);
            this.groupBoxShopCart.Controls.Add(this.btnMinusAmount1);
            this.groupBoxShopCart.Controls.Add(this.btnChangeAmount);
            this.groupBoxShopCart.Controls.Add(this.btnPlusAmount1);
            this.groupBoxShopCart.Location = new System.Drawing.Point(142, 59);
            this.groupBoxShopCart.Name = "groupBoxShopCart";
            this.groupBoxShopCart.Size = new System.Drawing.Size(931, 396);
            this.groupBoxShopCart.TabIndex = 53;
            this.groupBoxShopCart.TabStop = false;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.AutoSize = true;
            this.txtTotalCost.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTotalCost.Location = new System.Drawing.Point(244, 52);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(131, 21);
            this.txtTotalCost.TabIndex = 56;
            this.txtTotalCost.Text = "總價格xxx元";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(244, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "總價格";
            // 
            // btnToOrders
            // 
            this.btnToOrders.BackColor = System.Drawing.Color.Black;
            this.btnToOrders.FlatAppearance.BorderSize = 0;
            this.btnToOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToOrders.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnToOrders.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnToOrders.Location = new System.Drawing.Point(557, 32);
            this.btnToOrders.Name = "btnToOrders";
            this.btnToOrders.Size = new System.Drawing.Size(146, 40);
            this.btnToOrders.TabIndex = 54;
            this.btnToOrders.Text = "查看過往定單";
            this.btnToOrders.UseVisualStyleBackColor = false;
            this.btnToOrders.Click += new System.EventHandler(this.btnToOrders_Click);
            // 
            // groupBoxOrders
            // 
            this.groupBoxOrders.BackColor = System.Drawing.Color.White;
            this.groupBoxOrders.Controls.Add(this.panel4);
            this.groupBoxOrders.Controls.Add(this.label3);
            this.groupBoxOrders.Controls.Add(this.lboxOrderDetail);
            this.groupBoxOrders.Controls.Add(this.lboxOrders);
            this.groupBoxOrders.Controls.Add(this.label6);
            this.groupBoxOrders.Location = new System.Drawing.Point(21, 62);
            this.groupBoxOrders.Name = "groupBoxOrders";
            this.groupBoxOrders.Size = new System.Drawing.Size(1212, 493);
            this.groupBoxOrders.TabIndex = 54;
            this.groupBoxOrders.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(191)))));
            this.panel4.Controls.Add(this.btnToShopCart);
            this.panel4.Controls.Add(this.btnBuyAgain);
            this.panel4.Location = new System.Drawing.Point(357, 412);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(520, 73);
            this.panel4.TabIndex = 58;
            // 
            // btnToShopCart
            // 
            this.btnToShopCart.BackColor = System.Drawing.Color.Gray;
            this.btnToShopCart.FlatAppearance.BorderSize = 0;
            this.btnToShopCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToShopCart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnToShopCart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnToShopCart.Location = new System.Drawing.Point(18, 11);
            this.btnToShopCart.Name = "btnToShopCart";
            this.btnToShopCart.Size = new System.Drawing.Size(167, 53);
            this.btnToShopCart.TabIndex = 57;
            this.btnToShopCart.Text = "回到購物車";
            this.btnToShopCart.UseVisualStyleBackColor = false;
            this.btnToShopCart.Click += new System.EventHandler(this.btnToShopCart_Click);
            // 
            // btnBuyAgain
            // 
            this.btnBuyAgain.BackColor = System.Drawing.Color.Black;
            this.btnBuyAgain.FlatAppearance.BorderSize = 0;
            this.btnBuyAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyAgain.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBuyAgain.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuyAgain.Location = new System.Drawing.Point(340, 12);
            this.btnBuyAgain.Name = "btnBuyAgain";
            this.btnBuyAgain.Size = new System.Drawing.Size(167, 53);
            this.btnBuyAgain.TabIndex = 56;
            this.btnBuyAgain.Text = "再購買一次";
            this.btnBuyAgain.UseVisualStyleBackColor = false;
            this.btnBuyAgain.Click += new System.EventHandler(this.btnBuyAgain_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(669, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 46;
            this.label3.Text = "訂單內容";
            // 
            // lboxOrderDetail
            // 
            this.lboxOrderDetail.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxOrderDetail.FormattingEnabled = true;
            this.lboxOrderDetail.ItemHeight = 19;
            this.lboxOrderDetail.Location = new System.Drawing.Point(673, 55);
            this.lboxOrderDetail.Name = "lboxOrderDetail";
            this.lboxOrderDetail.Size = new System.Drawing.Size(513, 327);
            this.lboxOrderDetail.TabIndex = 45;
            // 
            // lboxOrders
            // 
            this.lboxOrders.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxOrders.FormattingEnabled = true;
            this.lboxOrders.ItemHeight = 19;
            this.lboxOrders.Location = new System.Drawing.Point(18, 55);
            this.lboxOrders.Name = "lboxOrders";
            this.lboxOrders.Size = new System.Drawing.Size(636, 327);
            this.lboxOrders.TabIndex = 44;
            this.lboxOrders.SelectedIndexChanged += new System.EventHandler(this.lboxOrders_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(14, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "過往已訂訂單";
            // 
            // panelShopCart
            // 
            this.panelShopCart.Controls.Add(this.panel2);
            this.panelShopCart.Controls.Add(this.panel1);
            this.panelShopCart.Controls.Add(this.groupBoxShopCart);
            this.panelShopCart.Location = new System.Drawing.Point(-1, 1);
            this.panelShopCart.Name = "panelShopCart";
            this.panelShopCart.Size = new System.Drawing.Size(1248, 558);
            this.panelShopCart.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnSendOut);
            this.panel2.Controls.Add(this.btnToOrders);
            this.panel2.Controls.Add(this.txtTotalCost);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblProductName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(142, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 95);
            this.panel2.TabIndex = 57;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(150)))));
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 53);
            this.panel1.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(541, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 21);
            this.label16.TabIndex = 42;
            this.label16.Text = "購物車內的產品";
            // 
            // panelOrders
            // 
            this.panelOrders.Controls.Add(this.panel3);
            this.panelOrders.Controls.Add(this.groupBoxOrders);
            this.panelOrders.Location = new System.Drawing.Point(2, 1);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(1248, 561);
            this.panelOrders.TabIndex = 56;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(150)))));
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1242, 53);
            this.panel3.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(550, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 21);
            this.label5.TabIndex = 42;
            this.label5.Text = "查詢過往訂單";
            // 
            // ShopCartForUser0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1247, 581);
            this.Controls.Add(this.panelOrders);
            this.Controls.Add(this.panelShopCart);
            this.Name = "ShopCartForUser0";
            this.Text = "訂單內容";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBoxShopCart.ResumeLayout(false);
            this.groupBoxShopCart.PerformLayout();
            this.groupBoxOrders.ResumeLayout(false);
            this.groupBoxOrders.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panelShopCart.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelOrders.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDeleteCartOne;
        private System.Windows.Forms.Button btnDeleteAllCart;
        private System.Windows.Forms.ListBox lboxOnOrderCart;
        private System.Windows.Forms.Button btnSendOut;
        private System.Windows.Forms.Button btnPlusAmount1;
        private System.Windows.Forms.Button btnMinusAmount1;
        private System.Windows.Forms.TextBox txtboxAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.GroupBox groupBoxShopCart;
        private System.Windows.Forms.Button btnToOrders;
        private System.Windows.Forms.GroupBox groupBoxOrders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lboxOrderDetail;
        private System.Windows.Forms.ListBox lboxOrders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtTotalCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuyAgain;
        private System.Windows.Forms.Button btnToShopCart;
        private System.Windows.Forms.Panel panelShopCart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
    }
}
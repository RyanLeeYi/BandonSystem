
namespace WindowsFormsApp1
{
    partial class TeacherPage
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
            this.txtboxAddStuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.txtBoxAddStudentClassID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSocialSecuritynumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lboxOnDuty = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSearchStuName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxSearchStuID = new System.Windows.Forms.TextBox();
            this.btnSearchStudentByName = new System.Windows.Forms.Button();
            this.btnOnDuty = new System.Windows.Forms.Button();
            this.btnCancelOnDuty = new System.Windows.Forms.Button();
            this.lboxStudentList = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxPickClass = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearchStudentByID = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxAddStuName
            // 
            this.txtboxAddStuName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtboxAddStuName.Location = new System.Drawing.Point(28, 142);
            this.txtboxAddStuName.Name = "txtboxAddStuName";
            this.txtboxAddStuName.Size = new System.Drawing.Size(161, 27);
            this.txtboxAddStuName.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(24, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "學生姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(24, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "學生所屬班級ID";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.Black;
            this.btnAddStudent.FlatAppearance.BorderSize = 0;
            this.btnAddStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStudent.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddStudent.Location = new System.Drawing.Point(28, 428);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(161, 33);
            this.btnAddStudent.TabIndex = 39;
            this.btnAddStudent.Text = "送出";
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // txtBoxAddStudentClassID
            // 
            this.txtBoxAddStudentClassID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBoxAddStudentClassID.Location = new System.Drawing.Point(28, 246);
            this.txtBoxAddStudentClassID.Name = "txtBoxAddStudentClassID";
            this.txtBoxAddStudentClassID.Size = new System.Drawing.Size(161, 27);
            this.txtBoxAddStudentClassID.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.txtSocialSecuritynumber);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtBoxAddStudentClassID);
            this.panel1.Controls.Add(this.btnAddStudent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtboxAddStuName);
            this.panel1.Location = new System.Drawing.Point(49, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 563);
            this.panel1.TabIndex = 41;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(191)))));
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 79);
            this.panel5.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(50, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 24);
            this.label8.TabIndex = 52;
            this.label8.Text = "新增學生";
            // 
            // txtSocialSecuritynumber
            // 
            this.txtSocialSecuritynumber.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSocialSecuritynumber.Location = new System.Drawing.Point(28, 362);
            this.txtSocialSecuritynumber.Name = "txtSocialSecuritynumber";
            this.txtSocialSecuritynumber.Size = new System.Drawing.Size(161, 27);
            this.txtSocialSecuritynumber.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(24, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 21);
            this.label11.TabIndex = 53;
            this.label11.Text = "學生身分證";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(360, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 32);
            this.label3.TabIndex = 42;
            this.label3.Text = "教師管理頁面";
            // 
            // lboxOnDuty
            // 
            this.lboxOnDuty.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxOnDuty.FormattingEnabled = true;
            this.lboxOnDuty.ItemHeight = 24;
            this.lboxOnDuty.Location = new System.Drawing.Point(18, 43);
            this.lboxOnDuty.Name = "lboxOnDuty";
            this.lboxOnDuty.Size = new System.Drawing.Size(413, 76);
            this.lboxOnDuty.TabIndex = 43;
            this.lboxOnDuty.SelectedIndexChanged += new System.EventHandler(this.lboxOnDuty_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(165, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 44;
            this.label4.Text = "本日值日生";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(163, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 45;
            this.label5.Text = "指定值日生";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(449, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 46;
            this.label6.Text = "學生姓名";
            // 
            // txtBoxSearchStuName
            // 
            this.txtBoxSearchStuName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBoxSearchStuName.Location = new System.Drawing.Point(453, 107);
            this.txtBoxSearchStuName.Name = "txtBoxSearchStuName";
            this.txtBoxSearchStuName.Size = new System.Drawing.Size(161, 27);
            this.txtBoxSearchStuName.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(449, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 21);
            this.label7.TabIndex = 48;
            this.label7.Text = "學生ID";
            // 
            // txtBoxSearchStuID
            // 
            this.txtBoxSearchStuID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBoxSearchStuID.Location = new System.Drawing.Point(453, 244);
            this.txtBoxSearchStuID.Name = "txtBoxSearchStuID";
            this.txtBoxSearchStuID.Size = new System.Drawing.Size(161, 27);
            this.txtBoxSearchStuID.TabIndex = 49;
            // 
            // btnSearchStudentByName
            // 
            this.btnSearchStudentByName.BackColor = System.Drawing.Color.Gray;
            this.btnSearchStudentByName.FlatAppearance.BorderSize = 0;
            this.btnSearchStudentByName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStudentByName.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchStudentByName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchStudentByName.Location = new System.Drawing.Point(453, 152);
            this.btnSearchStudentByName.Name = "btnSearchStudentByName";
            this.btnSearchStudentByName.Size = new System.Drawing.Size(161, 33);
            this.btnSearchStudentByName.TabIndex = 50;
            this.btnSearchStudentByName.Text = "姓名搜尋";
            this.btnSearchStudentByName.UseVisualStyleBackColor = false;
            this.btnSearchStudentByName.Click += new System.EventHandler(this.btnSearchStudentByName_Click);
            // 
            // btnOnDuty
            // 
            this.btnOnDuty.BackColor = System.Drawing.Color.Black;
            this.btnOnDuty.FlatAppearance.BorderSize = 0;
            this.btnOnDuty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnDuty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOnDuty.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOnDuty.Location = new System.Drawing.Point(452, 378);
            this.btnOnDuty.Name = "btnOnDuty";
            this.btnOnDuty.Size = new System.Drawing.Size(161, 35);
            this.btnOnDuty.TabIndex = 51;
            this.btnOnDuty.Text = "指定為值日生";
            this.btnOnDuty.UseVisualStyleBackColor = false;
            this.btnOnDuty.Click += new System.EventHandler(this.btnOnDuty_Click);
            // 
            // btnCancelOnDuty
            // 
            this.btnCancelOnDuty.BackColor = System.Drawing.Color.Black;
            this.btnCancelOnDuty.FlatAppearance.BorderSize = 0;
            this.btnCancelOnDuty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOnDuty.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancelOnDuty.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelOnDuty.Location = new System.Drawing.Point(454, 91);
            this.btnCancelOnDuty.Name = "btnCancelOnDuty";
            this.btnCancelOnDuty.Size = new System.Drawing.Size(161, 28);
            this.btnCancelOnDuty.TabIndex = 52;
            this.btnCancelOnDuty.Text = "取消值日生";
            this.btnCancelOnDuty.UseVisualStyleBackColor = false;
            this.btnCancelOnDuty.Click += new System.EventHandler(this.btnCancelOnDuty_Click);
            // 
            // lboxStudentList
            // 
            this.lboxStudentList.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lboxStudentList.FormattingEnabled = true;
            this.lboxStudentList.ItemHeight = 24;
            this.lboxStudentList.Location = new System.Drawing.Point(17, 97);
            this.lboxStudentList.Name = "lboxStudentList";
            this.lboxStudentList.Size = new System.Drawing.Size(413, 316);
            this.lboxStudentList.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(13, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 21);
            this.label9.TabIndex = 54;
            this.label9.Text = "學生名單";
            // 
            // cboxPickClass
            // 
            this.cboxPickClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPickClass.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboxPickClass.FormattingEnabled = true;
            this.cboxPickClass.Location = new System.Drawing.Point(294, 50);
            this.cboxPickClass.Name = "cboxPickClass";
            this.cboxPickClass.Size = new System.Drawing.Size(136, 29);
            this.cboxPickClass.TabIndex = 55;
            this.cboxPickClass.SelectedIndexChanged += new System.EventHandler(this.cboxPickClass_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(196, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 21);
            this.label10.TabIndex = 56;
            this.label10.Text = "班級";
            // 
            // btnSearchStudentByID
            // 
            this.btnSearchStudentByID.BackColor = System.Drawing.Color.Gray;
            this.btnSearchStudentByID.FlatAppearance.BorderSize = 0;
            this.btnSearchStudentByID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStudentByID.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchStudentByID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearchStudentByID.Location = new System.Drawing.Point(453, 289);
            this.btnSearchStudentByID.Name = "btnSearchStudentByID";
            this.btnSearchStudentByID.Size = new System.Drawing.Size(161, 33);
            this.btnSearchStudentByID.TabIndex = 57;
            this.btnSearchStudentByID.Text = "ID搜尋";
            this.btnSearchStudentByID.UseVisualStyleBackColor = false;
            this.btnSearchStudentByID.Click += new System.EventHandler(this.btnSearchStudentByID_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnCancelOnDuty);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lboxOnDuty);
            this.panel2.Location = new System.Drawing.Point(272, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 133);
            this.panel2.TabIndex = 58;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(172)))), ((int)(((byte)(150)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 72);
            this.panel3.TabIndex = 59;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnSearchStudentByID);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.cboxPickClass);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lboxStudentList);
            this.panel4.Controls.Add(this.btnOnDuty);
            this.panel4.Controls.Add(this.btnSearchStudentByName);
            this.panel4.Controls.Add(this.txtBoxSearchStuID);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtBoxSearchStuName);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(274, 218);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(645, 424);
            this.panel4.TabIndex = 58;
            // 
            // TeacherPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(945, 670);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TeacherPage";
            this.Text = "教師頁面";
            this.Load += new System.EventHandler(this.AddPersons_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxAddStuName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.TextBox txtBoxAddStudentClassID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lboxOnDuty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSearchStuName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxSearchStuID;
        private System.Windows.Forms.Button btnSearchStudentByName;
        private System.Windows.Forms.Button btnOnDuty;
        private System.Windows.Forms.Button btnCancelOnDuty;
        private System.Windows.Forms.ListBox lboxStudentList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboxPickClass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearchStudentByID;
        private System.Windows.Forms.TextBox txtSocialSecuritynumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
    }
}
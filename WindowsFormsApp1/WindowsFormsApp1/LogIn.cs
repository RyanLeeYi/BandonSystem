using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<Panel> ListPanel = new List<Panel>();

        string LogInAccountName = "";
        string LogInAccountPassWord = "";
        string checkPassWord = "";

        string getAccountName = "";
        string getAccountPassWord = "";
        string getSocialSecuritynumber = "";
        string getUserName = "";
        int getStudentID = 0;
        int AccessRights = 0;
        int getClassID = 0;
        public LogIn()
        {
            InitializeComponent();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            ListPanel.Add(panelLogIn);
            ListPanel.Add(panelSignUp);
            隱藏Panel();
            ListPanel[0].Visible = true;
        }
        void 註冊資料()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into UserAccount values(@AccountName,@AccountPassWord,@UserName,@Access,@StudentID,@ClassID);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@AccountName", getAccountName);
            cmd.Parameters.AddWithValue("@AccountPassWord", getAccountPassWord);
            cmd.Parameters.AddWithValue("@UserName", getUserName);
            cmd.Parameters.AddWithValue("@Access", AccessRights);
            cmd.Parameters.AddWithValue("@StudentID", getStudentID);
            cmd.Parameters.AddWithValue("@ClassID", getClassID);

            int rows = cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(rows.ToString() + "筆資料新增成功");
            MessageBox.Show("註冊成功，請重新登入");
            隱藏Panel();
            ListPanel[0].Visible = true;
        }
        void 取出ClassID()
        {
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from Student where Student_ID = @SearchByStudentID";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@SearchByStudentID", getStudentID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            while (reader0.Read())
            {
                getClassID += (int)reader0["Class_ID"];
            }
            reader0.Close();
            con0.Close();
        }
        void 取出學生姓名()
        {
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from Student where Student_ID = @SearchByStudentID";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@SearchByStudentID", getStudentID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            while (reader0.Read())
            {
                getUserName += (string)reader0["Student_Name"];
            }
            reader0.Close();
            con0.Close();
        }
        void toPickMenu()
        {
            PickMenu 選擇菜單 = new PickMenu();
            選擇菜單.ShowDialog();
        }
        void 隱藏Panel()
        {
            ListPanel[0].Visible = false;
            ListPanel[1].Visible = false;
        }
        private void btnToSignUp_Click(object sender, EventArgs e)
        {
            隱藏Panel();
            ListPanel[1].Visible = true;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if ((txtBoxLogInAccount.Text != "") && (txtBoxLogInPass.Text != ""))
            {
                //檢查是否有此帳號
                LogInAccountName = txtBoxLogInAccount.Text;
                LogInAccountPassWord = txtBoxLogInPass.Text;
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount where User_ID = @SearchByUserID";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@SearchByUserID", LogInAccountName);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                if (reader0.HasRows)
                {
                    while (reader0.Read())
                    {
                        checkPassWord = (string)reader0["User_Password"];
                        //檢查密碼是否正確
                        if(LogInAccountPassWord == checkPassWord)
                        {
                            GlobalVar.UserName = (string)reader0["User_Name"];
                            GlobalVar.UserID = (string)reader0["User_ID"];
                            GlobalVar.UserAccessRights = (int)reader0["Access_Rights"];
                            GlobalVar.UserClassID = (int)reader0["Class_ID"];
                            if (GlobalVar.UserAccessRights==3)
                            {
                                MessageBox.Show("開發者模式");
                                this.Visible = false;
                                toPickMenu();
                            }
                            else
                            {
                                MessageBox.Show($"{GlobalVar.UserName}歡迎回來");
                                this.Visible = false;
                                toPickMenu();
                            }
                        }
                        else
                        {
                            MessageBox.Show("密碼錯誤");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("無此帳號");
                }
                reader0.Close();
                con0.Close();
            }
            else
            {
                MessageBox.Show("請輸入帳號、密碼");
            }
        }

        private void btnToLogIn_Click(object sender, EventArgs e)
        {
            隱藏Panel();
            ListPanel[0].Visible = true;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if ((txtboxAccountName.Text != "") && (txtboxAccountPass.Text != "") && (txtboxStudentID.Text != "") &&(txtboxSocialSecuritynumber.Text != ""))
            {
                getAccountName = txtboxAccountName.Text;
                getAccountPassWord = txtboxAccountPass.Text;
                getSocialSecuritynumber = txtboxSocialSecuritynumber.Text;
                bool trypas;
                trypas = Int32.TryParse(txtboxStudentID.Text, out getStudentID);
                //檢查學號輸入是否為整數型態
                if (trypas == false)
                {
                    MessageBox.Show("學號為全數字");
                }
                else
                {
                    //檢查帳號名是否重複
                    SqlConnection con0 = new SqlConnection(myDBConnectionString);
                    con0.Open();
                    string strSQL0 = "select * from UserAccount where User_ID = @SearchByUserID";
                    SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                    cmd0.Parameters.AddWithValue("@SearchByUserID", getAccountName);
                    SqlDataReader reader0 = cmd0.ExecuteReader();
                    if (reader0.HasRows)
                    {
                        MessageBox.Show("此帳號名已被使用");
                    }
                    else
                    {
                        //檢查是否有此學號及身分證字號
                        SqlConnection con1 = new SqlConnection(myDBConnectionString);
                        con1.Open();
                        string strSQL1 = "select * from Student where (Student_ID = @SearchByStudentID) and (Social_Securitynumber = @SearchBySSNID)";
                        SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                        cmd1.Parameters.AddWithValue("@SearchByStudentID", getStudentID);
                        cmd1.Parameters.AddWithValue("@SearchBySSNID", getSocialSecuritynumber);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            //檢查此學號有沒有註冊過
                            SqlConnection con2 = new SqlConnection(myDBConnectionString);
                            con2.Open();
                            string strSQL2 = "select * from UserAccount where Student_ID = @SearchByStudentID";
                            SqlCommand cmd2 = new SqlCommand(strSQL2, con2);
                            cmd2.Parameters.AddWithValue("@SearchByStudentID", getStudentID);
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                MessageBox.Show("此學號已有帳號");
                            }
                            else
                            {
                                取出ClassID();
                                取出學生姓名();
                                註冊資料();
                            }
                            reader2.Close();
                            con2.Close();
                        }
                        else
                        {
                            MessageBox.Show("學號或身分證字號錯誤");
                        }
                        reader1.Close();
                        con1.Close();
                    }
                    reader0.Close();
                    con0.Close();
                }
            }
            else
            {
                MessageBox.Show("請輸入帳號、密碼、學號及身分證字號");
            }
        }

    }
}

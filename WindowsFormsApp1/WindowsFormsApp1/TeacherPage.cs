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
    public partial class TeacherPage : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<string> searchOnDutyUserID = new List<string>();
        List<string> searchStuListUserID = new List<string>();
        List<int> searchStudentInClassID = new List<int>();

        int getClassID = 0;
        string getPickOnDutyID = "";
        string getStuName = "";
        string getOnDutyID = "";
        string AllStudent = "所有學生";
        string getSocialSecuritynumber = "";
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void AddPersons_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            載入值日生();
            載入班級();
        }
        void 載入班級()
        {
            cboxPickClass.Items.Clear();
            cboxPickClass.Items.Add(AllStudent);
            SqlConnection conClass = new SqlConnection(myDBConnectionString);
            conClass.Open();
            string strSQLClass = "select * from Class where Class_Name not in ('教職員')";
            SqlCommand cmdClass = new SqlCommand(strSQLClass, conClass);
            SqlDataReader readerClass = cmdClass.ExecuteReader();

            string strClass = "";
            int ClassI = 0;
            while (readerClass.Read())
            {
                strClass = String.Format($"{readerClass["Class_Name"]}");
                cboxPickClass.Items.Add(strClass);
                searchStudentInClassID.Add((int)readerClass["Class_ID"]);
                ClassI += 1;
            }
            if (readerClass.HasRows)
            {
                cboxPickClass.SelectedIndex = 0;
            }
            readerClass.Close();
            conClass.Close();
        }
        void 新增學生資料()
        {
            if ((txtBoxAddStudentClassID.Text!="")&&(txtboxAddStuName.Text != "")&&(txtSocialSecuritynumber.Text !=""))
            {
                getStuName = txtboxAddStuName.Text;
                getSocialSecuritynumber = txtSocialSecuritynumber.Text;
                //轉為int型態
                bool trypa = Int32.TryParse(txtBoxAddStudentClassID.Text, out getClassID);
                if (trypa==false)
                {
                    MessageBox.Show("請輸入班級ID");
                }
                else
                {
                    //查詢是否有班級資料
                    SqlConnection con0 = new SqlConnection(myDBConnectionString);
                    con0.Open();
                    string strSQL0 = "select * from Class where Class_ID = @SearchByClassID";
                    SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                    cmd0.Parameters.AddWithValue("@SearchByClassID", getClassID);
                    SqlDataReader reader0 = cmd0.ExecuteReader();
                    if (reader0.HasRows)
                    {
                        //查詢是否已有學生資料
                        SqlConnection con1 = new SqlConnection(myDBConnectionString);
                        con1.Open();
                        string strSQL1 = "select * from Student where Social_Securitynumber=@SearchBySSN";
                        SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                        cmd1.Parameters.AddWithValue("@SearchBySSN", getSocialSecuritynumber);
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            MessageBox.Show("已有此學生資料");
                        }
                        else
                        {
                            SqlConnection con = new SqlConnection(myDBConnectionString);
                            con.Open();
                            string strSQL = "insert into Student values(@StudentName,@ClassID,@SocialSecuritynumber);";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@StudentName", getStuName);
                            cmd.Parameters.AddWithValue("@ClassID", getClassID);
                            cmd.Parameters.AddWithValue("@SocialSecuritynumber", getSocialSecuritynumber);

                            int rows = cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show(rows.ToString() + "位學生新增成功");
                        }
                        reader1.Close();
                        con1.Close();
                    }
                    else
                    {
                        MessageBox.Show("無此班級ID");
                    }
                    reader0.Close();
                    con0.Close();
                }
            }
            else
            {
                MessageBox.Show("輸入欄不能空白");
            }
        }

        void 載入學生List()
        {
            searchStuListUserID.Clear();
            lboxStudentList.Items.Clear();
            string ClassName = cboxPickClass.Text;
            if (ClassName == AllStudent)
            {
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount AS u join Class as c on c.Class_ID = u.Class_ID where Access_Rights = 1 or Access_Rights = 0;";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                string strStudentList = "";
                if (reader0.HasRows)
                {
                    while (reader0.Read())
                    {
                        strStudentList = String.Format($"班級:{reader0["Class_Name"]} 姓名:{reader0["User_Name"]} 學號:{reader0["Student_ID"]}");
                        lboxStudentList.Items.Add(strStudentList);
                        searchStuListUserID.Add((string)reader0["User_ID"]);
                    }
                }
                reader0.Close();
                con0.Close();
            }
            else
            {
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount AS u join Class as c on c.Class_ID = u.Class_ID " +
                    "where (Access_Rights = 1 or Access_Rights = 0) and Class_Name = @SearchByClassName;";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@SearchByClassName", ClassName);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                string strStudentList = "";
                if (reader0.HasRows)
                {
                    while (reader0.Read())
                    {
                        strStudentList = String.Format($"班級:{reader0["Class_Name"]} 姓名:{reader0["User_Name"]} 學號:{reader0["Student_ID"]}");
                        lboxStudentList.Items.Add(strStudentList);
                        searchStuListUserID.Add((string)reader0["User_ID"]);
                    }
                }
                reader0.Close();
                con0.Close();
            }
        }

        void 載入值日生()
        {
            searchOnDutyUserID.Clear();
            lboxOnDuty.Items.Clear();
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from UserAccount AS u join Class as c on c.Class_ID = u.Class_ID where Access_Rights = 1;";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            string strOnDutyStudent = "";
            if (reader0.HasRows)
            {
                while (reader0.Read())
                {
                    strOnDutyStudent = String.Format($"班級:{reader0["Class_Name"]} 姓名:{reader0["User_Name"]} 學號:{reader0["Student_ID"]}");
                    lboxOnDuty.Items.Add(strOnDutyStudent);
                    searchOnDutyUserID.Add((string)reader0["User_ID"]);
                }
            }
            else
            {
                MessageBox.Show("本日還沒指定值日生");
            }
            reader0.Close();
            con0.Close();
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            新增學生資料();
        }

        private void btnCancelOnDuty_Click(object sender, EventArgs e)
        {
            if (lboxOnDuty.SelectedIndex > -1)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "UPDATE UserAccount SET Access_Rights = 0 WHERE User_ID = @SearchByUserID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchByUserID", getOnDutyID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("請選擇值日生");
            }
            載入值日生();
        }

        private void lboxOnDuty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = lboxOnDuty.SelectedIndex;
            if (selindex > -1)
            {
                getOnDutyID = searchOnDutyUserID[selindex];
            }
        }

        private void cboxPickClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            載入學生List();
        }

        private void btnSearchStudentByName_Click(object sender, EventArgs e)
        {
            if (txtBoxSearchStuName.Text != "")
            {
                cboxPickClass.SelectedIndex = 0;
                searchStuListUserID.Clear();
                lboxStudentList.Items.Clear();
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount AS u join Class as c on c.Class_ID = u.Class_ID " +
                    "where (Access_Rights = 1 or Access_Rights = 0) and (User_Name like @SearchName);";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@SearchName", "%" + txtBoxSearchStuName.Text + "%");
                SqlDataReader reader0 = cmd0.ExecuteReader();
                string strStudentList = "";
                if (reader0.HasRows)
                {
                    while (reader0.Read())
                    {
                        strStudentList = String.Format($"班級:{reader0["Class_Name"]} 姓名:{reader0["User_Name"]} 學號:{reader0["Student_ID"]}");
                        lboxStudentList.Items.Add(strStudentList);
                        searchStuListUserID.Add((string)reader0["User_ID"]);
                    }
                    lboxStudentList.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("無此學生");
                }
                reader0.Close();
                con0.Close();
            }
            else
            {
                MessageBox.Show("請輸入文字");
            }
        }

        private void btnSearchStudentByID_Click(object sender, EventArgs e)
        {
            if (txtBoxSearchStuID.Text != "")
            {
                cboxPickClass.SelectedIndex = 0;
                searchStuListUserID.Clear();
                lboxStudentList.Items.Clear();
                int getStudentID = 0;
                bool trypas = int.TryParse(txtBoxSearchStuID.Text, out getStudentID);
                if (trypas == true)
                {
                    SqlConnection con0 = new SqlConnection(myDBConnectionString);
                    con0.Open();
                    string strSQL0 = "select * from UserAccount AS u join Class as c on c.Class_ID = u.Class_ID " +
                        "where (Access_Rights = 1 or Access_Rights = 0) and (Student_ID = @SearchByID);";
                    SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                    cmd0.Parameters.AddWithValue("@SearchByID", getStudentID);
                    SqlDataReader reader0 = cmd0.ExecuteReader();
                    string strStudentList = "";
                    if (reader0.HasRows)
                    {
                        while (reader0.Read())
                        {
                            strStudentList = String.Format($"班級:{reader0["Class_Name"]} 姓名:{reader0["User_Name"]} 學號:{reader0["Student_ID"]}");
                            lboxStudentList.Items.Add(strStudentList);
                            searchStuListUserID.Add((string)reader0["User_ID"]);
                        }
                        lboxStudentList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("無此ID");
                    }
                    reader0.Close();
                    con0.Close();
                }
                else
                {
                    MessageBox.Show("學生ID為全數字");
                }
            }
            else
            {
                MessageBox.Show("請輸入ID");
            }
        }

        private void btnOnDuty_Click(object sender, EventArgs e)
        {
            if (lboxStudentList.SelectedIndex>-1)
            {
                int selindex = lboxStudentList.SelectedIndex;
                getPickOnDutyID = searchStuListUserID[selindex];
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "UPDATE UserAccount SET Access_Rights = 1 WHERE User_ID = @SearchByUserID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchByUserID", getPickOnDutyID);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                載入值日生();
                載入學生List();
            }
            else
            {
                MessageBox.Show("請選擇學生");
            }
        }
    }
}

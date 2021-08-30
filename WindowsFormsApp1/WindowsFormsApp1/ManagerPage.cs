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
    public partial class ManagerPage : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<string> searchOnDutyUserID = new List<string>();
        List<string> searchListUserID = new List<string>();
        List<int> ChangeAccountInClassID = new List<int>();
        List<int> CreateAccountInClassID = new List<int>();
        List<int> ListAddProductByStoreID = new List<int>();

        string[] ArrayAccessRight = { "教職員","管理者" };

        int getClassID = 0;

        //新增帳號用
        string getCreateAccountName = "";
        string getCreateAccountUserName = "";
        string getCreateAccountPass = "";
        int getCreateAccountAccessRight = 0;
        //lbox列表用
        int getListBoxAccessRight = 0;
        string getUserID = "";
        //更改帳號用
        string getChangeAccountUserName = "";
        string getChangeAccountPass = "";

        int getStoreIDForAddProduct = 0;
        int setTeacherClass = 1004;
        string imageName = "";
        //圖片用
        
        public ManagerPage()
        {
            InitializeComponent();
        }

        private void ManagerPage_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            //載入lbox權限選擇
            cboxPickAccessRight.Items.AddRange(ArrayAccessRight);
            cboxPickAccessRight.SelectedIndex = 0;
            //載入新增帳號權限選擇
            cboxCreateAccountAccessRight.Items.AddRange(ArrayAccessRight);
            cboxCreateAccountAccessRight.SelectedIndex = 0;
            //載入更改帳號權限選擇
            cboxChangeAccountAccessRight.Items.AddRange(ArrayAccessRight);
            cboxChangeAccountAccessRight.SelectedIndex = 0;
            載入店家();
            pictureBox1.Image = null;
            全部隱藏();
            txtChange.Text = "更改帳號";
            panelChangeAccount.Visible = true;
        }
        void 新增帳號()
        {
            if ((txtboxCreateAccountName.Text != "") && (txtboxCreateAccountPass.Text != "") && (txtboxCreateAccountUserName.Text != ""))
            {
                getCreateAccountUserName = txtboxCreateAccountUserName.Text;
                getCreateAccountName = txtboxCreateAccountName.Text;
                getCreateAccountPass = txtboxCreateAccountPass.Text;

                //檢查職員ID是否已註冊
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount where User_ID = @SearchByUserID";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@SearchByUserID", getCreateAccountName);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                if (reader0.HasRows)
                {
                    MessageBox.Show("此ID已被使用");
                }
                else
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "insert into UserAccount values(@AccountName,@AccountPass,@UserName,@Access,NULL,@ClassID);";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@AccountName", getCreateAccountName);
                    cmd.Parameters.AddWithValue("@AccountPass", getCreateAccountPass);
                    cmd.Parameters.AddWithValue("@UserName", getCreateAccountUserName);
                    cmd.Parameters.AddWithValue("@Access", getCreateAccountAccessRight);
                    cmd.Parameters.AddWithValue("@ClassID", setTeacherClass);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(rows.ToString() + "筆員工資料新增成功");
                }
                reader0.Close();
                con0.Close();
            }
            else
            {
                MessageBox.Show("輸入欄不能空白","新增帳號");
            }
        }

        void 載入帳號列表()
        {
            searchListUserID.Clear();
            lboxAccountList.Items.Clear();
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from UserAccount where Access_Rights = @getAccessRight;";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@getAccessRight", getListBoxAccessRight);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            string strAccountList = "";
            string AccessName = "";
            int getAccess = 0;
            if (reader0.HasRows)
            {
                while (reader0.Read())
                {
                    getAccess = (int)reader0["Access_Rights"];
                    if (getAccess == 2)
                    {
                        AccessName = "教職員";
                    }
                    else
                    {
                        AccessName = "管理者";
                    }
                    strAccountList = String.Format($"職員ID:{reader0["User_ID"]} 姓名:{reader0["User_Name"]} 權限:{AccessName}");
                    lboxAccountList.Items.Add(strAccountList);
                    searchListUserID.Add((string)reader0["User_ID"]);
                }
            }
            reader0.Close();
            con0.Close();
        }

        void 載入店家()
        {
            cboxAddProduct.Items.Clear();
            ListAddProductByStoreID.Clear();
            SqlConnection conStore = new SqlConnection(myDBConnectionString);
            conStore.Open();
            string strSQLStore = "select * from Store as s";
            SqlCommand cmdStore = new SqlCommand(strSQLStore, conStore);
            SqlDataReader readerStore = cmdStore.ExecuteReader();

            string strStore = "";
            string strMsgStore = "";
            int StoreI = 0;
            while (readerStore.Read())
            {
                strStore = String.Format($"{readerStore["Store_Name"]}");
                cboxAddProduct.Items.Add(strStore);
                ListAddProductByStoreID.Add((int)readerStore["Store_ID"]);
                StoreI += 1;
            }
            if (readerStore.HasRows)
            {
                cboxAddProduct.SelectedIndex = 0;
            }
            strMsgStore = "已載入店家資料" + StoreI.ToString() + "筆";
            readerStore.Close();
            conStore.Close();
        }

        void 新增店家()
        {
            if ((txtAddStoreName.Text != "") && (txtAddStorePhone.Text != ""))
            {
                string getAddStoreName = txtAddStoreName.Text;
                string getAddStorePhone = txtAddStorePhone.Text;

                //檢查店家是否已在名單中
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from Store where Store_Name = @SearchByStoreName and Store_Phone = @SearchByStorePhone";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@SearchByStoreName", getAddStoreName);
                cmd0.Parameters.AddWithValue("@SearchByStorePhone", getAddStorePhone);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                if (reader0.HasRows)
                {
                    MessageBox.Show("此店家已在名單中");
                }
                else
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "insert into Store values(@StoreName,@StorePhone);";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@StoreName", getAddStoreName);
                    cmd.Parameters.AddWithValue("@StorePhone", getAddStorePhone);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(rows.ToString() + "筆店家資料新增成功");
                }
                reader0.Close();
                con0.Close();
            }
            else
            {
                MessageBox.Show("輸入欄不能空白", "新增店家");
            }
        }

        void 全部隱藏()
        {
            paneladdAccount.Visible = false;
            paneladdMeal.Visible = false;
            paneladdStore.Visible = false;
            panelChangeAccount.Visible = false;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            新增帳號();
        }

        private void cboxCreateAccountAccessRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = cboxCreateAccountAccessRight.SelectedIndex;
            if (selindex > -1)
            {
                switch (selindex)
                {
                    case 0:
                        getCreateAccountAccessRight = 2;
                        break;
                    case 1:
                        getCreateAccountAccessRight = 3;
                        break;
                    default:
                        break;
                }
            }
        }

        private void cboxPickAccessRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = cboxPickAccessRight.SelectedIndex;
            if (selindex > -1)
            {
                switch (selindex)
                {
                    case 0:
                        getListBoxAccessRight = 2;
                        break;
                    case 1:
                        getListBoxAccessRight = 3;
                        break;
                    default:
                        break;
                }
            }
            載入帳號列表();
        }

        private void lboxAccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtboxChangeAccountName.Clear();
            txtboxChangeAccountPass.Clear();
            txtboxChangeUserName.Clear();
            int selindex = lboxAccountList.SelectedIndex;
            if (selindex > -1)
            {
                getUserID = searchListUserID[selindex];
                SqlConnection con0 = new SqlConnection(myDBConnectionString);
                con0.Open();
                string strSQL0 = "select * from UserAccount where User_ID = @searchByUserID;";
                SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
                cmd0.Parameters.AddWithValue("@searchByUserID", getUserID);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                string strAccountList = "";
                string AccessName = "";
                int getAccess = 0;
                if (reader0.HasRows)
                {
                    while (reader0.Read())
                    {
                        getAccess = (int)reader0["Access_Rights"];
                        if (getAccess == 2)
                        {
                            cboxChangeAccountAccessRight.SelectedIndex = 0;
                        }
                        else
                        {
                            cboxChangeAccountAccessRight.SelectedIndex = 1;
                        }
                        txtboxChangeAccountName.Text = (string)reader0["User_ID"];
                        txtboxChangeAccountPass.Text = (string)reader0["User_Password"];
                        txtboxChangeUserName.Text = (string)reader0["User_Name"];
                    }
                }
                reader0.Close();
                con0.Close();
            }
        }

        private void btnChangeAccount_Click(object sender, EventArgs e)
        {
            int selindex = lboxAccountList.SelectedIndex;
            if (selindex > -1)
            {
                if ((txtboxChangeAccountName.Text != "") && (txtboxChangeAccountPass.Text != "") && (txtboxChangeUserName.Text != ""))
                {
                    getChangeAccountUserName = txtboxChangeUserName.Text;
                    getChangeAccountPass = txtboxChangeAccountPass.Text;
                    getUserID = searchListUserID[selindex];
                    int getAccessRight = 0;
                    if (cboxChangeAccountAccessRight.SelectedIndex == 0)
                    {
                        getAccessRight = 2;
                    }
                    else
                    {
                        getAccessRight = 3;
                    }
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "UPDATE UserAccount SET Access_Rights = @Access,User_Name = @UserName,User_Password = @AccountPass WHERE User_ID = @SearchByUserID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@AccountPass", getChangeAccountPass);
                    cmd.Parameters.AddWithValue("@UserName", getChangeAccountUserName);
                    cmd.Parameters.AddWithValue("@Access", getAccessRight);
                    cmd.Parameters.AddWithValue("@SearchByUserID", getUserID);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show(rows.ToString() + "筆員工資料更改成功");
                }
                else
                {
                    MessageBox.Show("輸入欄不能空白", "更改帳號");
                }
            }
            else
            {
                MessageBox.Show("請選擇職員","更改帳號");
            }
            載入帳號列表();
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            新增店家();
        }

        private void btnPickProductImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();//開啟檔案頁面
            f.Filter = "圖檔類型(*.jpg,*.jpeg,*.png)|*.jpg;*.jpeg;*.png";//filter限定儲存格式
            string str預設路徑 = @"C:\Users\User\OneDrive\課程\CODE\個人用\forAddProductImg\";
            f.InitialDirectory = str預設路徑;

            DialogResult R = f.ShowDialog();//獨佔開啟
            if (R == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(f.FileName);//FileName包含路徑的檔案名，取得照片位置。 
                //要用命名空間system.IO
                //SafeFileName不包含路徑的檔案名
                string fileExtension = Path.GetExtension(f.SafeFileName);//取得副檔名
                Random myRnd = new Random();
                imageName = DateTime.Now.ToString("yyyyMMddHHmmss") + myRnd.Next(1000, 9999).ToString() + fileExtension;
            }
        }

        private void cboxAddProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = cboxAddProduct.SelectedIndex;
            getStoreIDForAddProduct = ListAddProductByStoreID[selindex];
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (cboxAddProduct.SelectedIndex > -1)
            {
                if ((pictureBox1.Image != null) && (txtAddProductName.Text !="") && (numericUpDownAddProductPrice.Value > -1))
                {
                    string imageDir = @"images\";
                    //小數轉整數
                    int getProductPrice = decimal.ToInt32(numericUpDownAddProductPrice.Value);
                    pictureBox1.Image.Save(imageDir + imageName);

                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = "insert into Product values(@NewProductName,@NewProductPrice,@ProductStoreID,@NewProductImage)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewProductName", txtAddProductName.Text);
                    cmd.Parameters.AddWithValue("@NewProductPrice", getProductPrice);
                    cmd.Parameters.AddWithValue("@ProductStoreID", getStoreIDForAddProduct);
                    cmd.Parameters.AddWithValue("@NewProductImage", imageName);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("新增" + rows + "項商品成功");
                }
                else
                {
                    MessageBox.Show("請輸入產品圖片、產品名稱及價格");
                }
            }
            else
            {
                MessageBox.Show("請選擇店家","新增餐點");
            }
        }

        private void btnToChangeAccount_Click(object sender, EventArgs e)
        {
            全部隱藏();
            panelChangeAccount.Visible = true;
            txtChange.Text = "更改帳號";
        }

        private void btnToCreateAccount_Click(object sender, EventArgs e)
        {
            全部隱藏();
            paneladdAccount.Visible = true;
            txtChange.Text = "新增帳號";
        }

        private void btnToAddStore_Click(object sender, EventArgs e)
        {
            全部隱藏();
            paneladdStore.Visible = true;
            txtChange.Text = "新增店家";
        }

        private void btnToAddProduct_Click(object sender, EventArgs e)
        {
            全部隱藏();
            paneladdMeal.Visible = true;
            載入店家();
            txtChange.Text = "新增餐點";
        }
    }
}

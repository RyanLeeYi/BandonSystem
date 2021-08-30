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
    public partial class PickMenu : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<Panel> panelPickMenu = new List<Panel>();
        //textVer
        List<int> searchIDsTextVer = new List<int>();//lbox切換用
        List<string> listPicNameTextVer = new List<string>();
        List<int> listPicPriceTextVer = new List<int>();
        List<int> listPicIDTextVer = new List<int>();
        DateTime todaytime = DateTime.Today;

        //點餐用StoreID
        int getOrderStoreID = 0;
        string getOrderStoreName = "";

        int priceEachTextVer;
        int amountTextVer;
        string getProductNameTextVer;
        int intProductIDTextVer;
        string AllStore = "所有店家";
        public PickMenu()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            //店家資料庫--------------
            載入店家();
            //數量初始值----------------
            amountTextVer = 1;
            txtboxAmountTextVer.Text = amountTextVer.ToString();

            panelPickMenu.Add(panelMenuTextVer);
            switch (GlobalVar.UserAccessRights)
            {
                case 0:
                    groupBoxfor1.Visible = false;
                    groupBoxfor2.Visible = false;
                    groupBoxfor3.Visible = false;
                    break;
                case 1:
                    groupBoxfor2.Visible = false;
                    groupBoxfor3.Visible = false;
                    break;
                case 2:
                    groupBoxfor3.Visible = false;
                    break;
            }
        }
        //textVer資料庫方法
        void 載入店家()
        {
            cboxStoreTextVer.Items.Clear();
            cboxStoreTextVer.Items.Add(AllStore);
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
                cboxStoreTextVer.Items.Add(strStore);
                StoreI += 1;
            }
            strMsgStore = "已載入店家資料" + StoreI.ToString() + "筆";
            readerStore.Close();
            conStore.Close();
            cboxStoreTextVer.SelectedIndex = 0;
        }
        void 載入店家菜單()
        {
            lboxMenuTextVer.Items.Clear();
            searchIDsTextVer.Clear();
            string strStoreName = cboxStoreTextVer.SelectedItem.ToString();
            if (strStoreName == AllStore)
            {
                //全部店家印出
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from Product as p inner join Store as s on(p.Store_ID=s.Store_ID);";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@SearchStore", strStoreName);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                string strProduct = "";
                string strMsgProduct = "";
                int ProductI = 0;
                while (reader1.Read())
                {
                    strProduct = String.Format($" 店家 : {reader1["Store_Name"]}  品名 : {reader1["Product_Name"]}  價格 : {reader1["Product_Price"]}");
                    lboxMenuTextVer.Items.Add(strProduct);
                    searchIDsTextVer.Add((int)reader1["Product_ID"]);
                    lblStoreName.Text = AllStore;
                    ProductI += 1;

                }
                lboxMenuTextVer.SelectedIndex = 0;
                strMsgProduct = "已載入品項資料" + ProductI.ToString() + "筆";
                reader1.Close();
                con1.Close();
            }
            else
            {
                //資料庫lbox品項
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from Product as p inner join Store as s on(p.Store_ID=s.Store_ID) where Store_Name = @SearchStore;";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@SearchStore", strStoreName);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                string strProduct = "";
                string strMsgProduct = "";
                int ProductI = 0;
                while (reader1.Read())
                {
                    strProduct = String.Format($"店家:{reader1["Store_Name"]} 品名:{reader1["Product_Name"]} 價格:{reader1["Product_Price"]}");
                    lboxMenuTextVer.Items.Add(strProduct);
                    searchIDsTextVer.Add((int)reader1["Product_ID"]);
                    lblStoreName.Text = (string)reader1["Store_Name"];
                    ProductI += 1;

                }
                if (reader1.HasRows)
                {
                    lboxMenuTextVer.SelectedIndex = 0;
                }
                strMsgProduct = "已載入品項資料" + ProductI.ToString() + "筆";
                reader1.Close();
                con1.Close();
            }
        }
        void 計算總價()
        {
            lblTotalPriceTextVer.Text = (priceEachTextVer * amountTextVer).ToString() + "元";
        }

        void 載入圖片資料()
        {

            string strStoreName = cboxStoreTextVer.SelectedItem.ToString();
            if (strStoreName==AllStore)
            {
                intProductIDTextVer = searchIDsTextVer[lboxMenuTextVer.SelectedIndex];
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from Product where Product_ID = @SearchProductPic";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@SearchProductPic", intProductIDTextVer);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                string image_dir = @"images\";//設定圖檔路徑，這是相對路徑
                                              //string image_dir = @"c:\images\";//設定圖檔路徑，這是絕對路徑
                string image_name = "";
                int i = 0;

                while (reader1.Read())
                {
                    //利用list建立圖片鍵值
                    listPicIDTextVer.Add((int)reader1["Product_ID"]);//(int)是型別提示
                    listPicNameTextVer.Add((string)reader1["Product_Name"]);
                    listPicPriceTextVer.Add((int)reader1["Product_Price"]);
                    image_name = (string)reader1["Product_Image"];//取得檔案名稱
                    picboxTextVer.Image = Image.FromFile(image_dir + image_name);
                    imageList1.Images.Add(Image.FromFile(image_dir + image_name));//Image.FromFile(檔案路徑 + 檔案名稱)
                    i += 1;//計數器可以避免一次讀太多資料，或是可以調整上下頁
                }
                reader1.Close();
                con1.Close();
            }
            else
            {
                //-------con--------
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "select * from Store where Store_Name= @SearchStore";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchStore", strStoreName);
                SqlDataReader reader = cmd.ExecuteReader();
                int strStoreID = 0;
                int s = 0;

                while (reader.Read())
                {
                    strStoreID += (int)reader["Store_ID"];
                    s += 1;
                }
                reader.Close();
                con.Close();

                //-------con1--------
                intProductIDTextVer = searchIDsTextVer[lboxMenuTextVer.SelectedIndex];
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from Product where Store_ID = @SearchStoreProduct and Product_ID = @SearchProductPic";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@SearchStoreProduct", strStoreID);
                cmd1.Parameters.AddWithValue("@SearchProductPic", intProductIDTextVer);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                string image_dir = @"images\";//設定圖檔路徑，這是相對路徑
                                              //string image_dir = @"c:\images\";//設定圖檔路徑，這是絕對路徑
                string image_name = "";
                int i = 0;

                while (reader1.Read())
                {
                    //利用list建立圖片鍵值
                    listPicIDTextVer.Add((int)reader1["Product_ID"]);//(int)是型別提示
                    listPicNameTextVer.Add((string)reader1["Product_Name"]);
                    listPicPriceTextVer.Add((int)reader1["Product_Price"]);
                    image_name = (string)reader1["Product_Image"];//取得檔案名稱
                    picboxTextVer.Image = Image.FromFile(image_dir + image_name);
                    imageList1.Images.Add(Image.FromFile(image_dir + image_name));//Image.FromFile(檔案路徑 + 檔案名稱)
                    i += 1;//計數器可以避免一次讀太多資料，或是可以調整上下頁
                }
                reader1.Close();
                con1.Close();
            }
        }
        void 取出店家名稱()
        {
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from Store where Store_ID = @SearchByStoreID";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@SearchByStoreID", getOrderStoreID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            
            while (reader0.Read())
            {
                getOrderStoreName = (string)reader0["Store_Name"];
            }
            reader0.Close();
            con0.Close();
        }
        void 新增訂單()
        {
            取出店家名稱();
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into ShoppingCartImg values(@ProductID,@StoreID,@StoreName,@ProductName,@quantityOrdered,@ProductPrice,@ClassID,@UserID);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductID", intProductIDTextVer);
            cmd.Parameters.AddWithValue("@StoreID", getOrderStoreID);
            cmd.Parameters.AddWithValue("@StoreName", getOrderStoreName);
            cmd.Parameters.AddWithValue("@ProductName", getProductNameTextVer);
            cmd.Parameters.AddWithValue("@ProductPrice", priceEachTextVer);
            cmd.Parameters.AddWithValue("@ClassID", GlobalVar.UserClassID);
            cmd.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            //點數轉換
            int int數量 = 0;
            Int32.TryParse(txtboxAmountTextVer.Text, out int數量);
            cmd.Parameters.AddWithValue("@quantityOrdered", int數量);

            int rows = cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(rows.ToString() + "筆訂單新增成功");
        }
        void 查詢是否已點並新增更新()
        {
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from ShoppingCartImg where Product_ID = @SearchByProductID and User_ID =@SearchByUserID";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@SearchByProductID", intProductIDTextVer);
            cmd0.Parameters.AddWithValue("@SearchByUserID", GlobalVar.UserID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            int OrderedAmount = 0;
            int s = 0;
            int int數量 = 0;
            Int32.TryParse(txtboxAmountTextVer.Text, out int數量);
            //更新
            if (reader0.HasRows)
            {
                while (reader0.Read())
                {
                    OrderedAmount += (int)reader0["quantityOrdered"];
                    OrderedAmount += int數量;
                    SqlConnection con1 = new SqlConnection(myDBConnectionString);
                    con1.Open();
                    string strSQL1 = "UPDATE ShoppingCartImg SET quantityOrdered = @NewAmount WHERE Product_ID = @ProductID and User_ID = @SearchByUserID;";
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                    cmd1.Parameters.AddWithValue("@ProductID", intProductIDTextVer);
                    cmd1.Parameters.AddWithValue("@SearchByUserID", GlobalVar.UserID);
                    cmd1.Parameters.AddWithValue("@NewAmount", OrderedAmount);

                    int rows = cmd1.ExecuteNonQuery();
                    MessageBox.Show(rows.ToString() + "筆訂單新增成功");
                    con1.Close();
                }
            }
            else
            {
                新增訂單();
            }
            reader0.Close();
            con0.Close();
        }


        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            TeacherPage 新增學生 = new TeacherPage();
            新增學生.ShowDialog();
        }

        private void btnOpCartTextVer_Click(object sender, EventArgs e)
        {
            ShopCartForUser0 購物車頁 = new ShopCartForUser0();
            購物車頁.ShowDialog();
        }

        private void btnOrderTextVer_Click(object sender, EventArgs e)
        {
            if ((intProductIDTextVer != 0) && (txtboxAmountTextVer.Text != ""))
            {
                查詢是否已點並新增更新();
            }
            else
            {
                MessageBox.Show("請確認有輸入數量及選擇商品");
            }
        }

        private void txtboxAmountTextVer_Leave(object sender, EventArgs e)
        {
            if (txtboxAmountTextVer.Text != "")
            {

            }
            else
            {
                txtboxAmountTextVer.Text = "1";
            }
        }

        private void txtboxAmountTextVer_TextChanged(object sender, EventArgs e)
        {
            if (txtboxAmountTextVer.Text != "")
            {
                bool ifNum = Int32.TryParse(txtboxAmountTextVer.Text, out amountTextVer);

                if ((ifNum == true) && (amountTextVer >= 1))
                {

                }
                else
                {
                    MessageBox.Show("輸入數量錯誤");
                    amountTextVer = 1;
                    txtboxAmountTextVer.Text = amountTextVer.ToString();
                }
            }
            else
            {
                amountTextVer = 1;
            }
            計算總價();
        }

        private void lboxMenuTextVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxMenuTextVer.SelectedIndex >= 0)
            {
                intProductIDTextVer = searchIDsTextVer[lboxMenuTextVer.SelectedIndex];

                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();

                string strSQL = "select * from Product as p where p.Product_ID = @SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intProductIDTextVer);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblProductNameTextVer.Text = string.Format("{0}", reader["Product_Name"]);
                    lblPriceEachTextVer.Text = string.Format("{0}元", reader["Product_Price"]);
                    priceEachTextVer = (int)reader["Product_Price"];
                    getProductNameTextVer = (string)reader["Product_Name"];
                    getOrderStoreID = (int)reader["Store_ID"];
                }
                else
                {
                    MessageBox.Show("查無此商品");
                    lblProductNameTextVer.Text = "商品名稱";
                }
                計算總價();
                reader.Close();//關閉reader
                con.Close();//關閉資料庫con
                listPicIDTextVer.Clear();
                listPicNameTextVer.Clear();
                listPicPriceTextVer.Clear();
                imageList1.Images.Clear();
                載入圖片資料();
            }
            else
            {
                MessageBox.Show("查無此資料");
            }
        }

        private void cboxStoreTextVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            載入店家菜單();
        }

        private void btnTotalPrint_Click(object sender, EventArgs e)
        {
            TotalOrderList 訂單總結 = new TotalOrderList();
            訂單總結.ShowDialog();
        }

        private void PickMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogIn backtologin = new LogIn();
            backtologin.Visible = true;
            GlobalVar.UserName = "";
            GlobalVar.UserID = "";
            GlobalVar.UserClassID = 0;
            GlobalVar.UserAccessRights = 0;
        }

        private void btnAddManager_Click(object sender, EventArgs e)
        {
            ManagerPage tomanargerPage = new ManagerPage();
            tomanargerPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            載入店家();
        }
    }
}

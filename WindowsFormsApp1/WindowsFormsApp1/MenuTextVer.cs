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
    public partial class MenuTextVer : Form
    {
        //資料庫
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<int> searchIDs = new List<int>();//lbox切換用

        List<string> listPicName = new List<string>();
        List<int> listPicPrice = new List<int>();
        List<int> listPicID = new List<int>();

        int priceEach;
        int amount2;
        string getProductName;
        int intProductID;

        public MenuTextVer()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
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
            amount2 = 1;
            txtboxAmount2.Text = amount2.ToString();

        }
        //資料庫方法
        void 載入店家()
        {
            cboxStore2.Items.Clear();
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
                cboxStore2.Items.Add(strStore);
                StoreI += 1;
            }
            strMsgStore = "已載入店家資料" + StoreI.ToString() + "筆";
            readerStore.Close();
            conStore.Close();
            MessageBox.Show(strMsgStore);
            cboxStore2.SelectedIndex = 0;
        }
        void 載入店家菜單()
        {
            lboxMenu2.Items.Clear();
            searchIDs.Clear();
            string strStoreName = cboxStore2.SelectedItem.ToString();
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
                    strProduct = String.Format($"品名:{reader1["Product_Name"]} 價格:{reader1["Product_Price"]}");
                    lboxMenu2.Items.Add(strProduct);
                    searchIDs.Add((int)reader1["Product_ID"]);
                    lblStoreName.Text = (string)reader1["Store_Name"];
                    ProductI += 1;
                
            }
            lboxMenu2.SelectedIndex = 0;
            strMsgProduct = "已載入品項資料" + ProductI.ToString() + "筆";
            reader1.Close();
            con1.Close();
        }
        void 計算總價()
        {
            lblTotalPrice2.Text = (priceEach * amount2).ToString() + "元";
        }
        
        void 載入圖片資料()
        {
            //-------con--------
            string strStoreName = cboxStore2.SelectedItem.ToString();
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
            intProductID = searchIDs[lboxMenu2.SelectedIndex];
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Product where Store_ID = @SearchStoreProduct and Product_ID = @SearchProductPic";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchStoreProduct", strStoreID);
            cmd1.Parameters.AddWithValue("@SearchProductPic", intProductID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string image_dir = @"images\";//設定圖檔路徑，這是相對路徑
            //string image_dir = @"c:\images\";//設定圖檔路徑，這是絕對路徑
            string image_name = "";
            int i = 0;

            while (reader1.Read())
            {
                //利用list建立圖片鍵值
                listPicID.Add((int)reader1["Product_ID"]);//(int)是型別提示
                listPicName.Add((string)reader1["Product_Name"]);
                listPicPrice.Add((int)reader1["Product_Price"]);
                image_name = (string)reader1["Product_Image"];//取得檔案名稱
                picbox1.Image = Image.FromFile(image_dir + image_name);
                imageList1.Images.Add(Image.FromFile(image_dir + image_name));//Image.FromFile(檔案路徑 + 檔案名稱)
                i += 1;//計數器可以避免一次讀太多資料，或是可以調整上下頁
            }
            reader1.Close();
            con1.Close();
        }

        void 新增訂單()
        {
            string strStoreName = cboxStore2.Text;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into ShoppingCartImg values(@ProductID,@StoreName,@ProductName,@quantityOrdered,@ProductPrice,@ClassID,@UserID);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductID", intProductID);
            cmd.Parameters.AddWithValue("@StoreName", strStoreName);
            cmd.Parameters.AddWithValue("@ProductName", getProductName);
            cmd.Parameters.AddWithValue("@ProductPrice", priceEach);
            cmd.Parameters.AddWithValue("@ClassID", GlobalVar.UserClassID);
            cmd.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            //點數轉換
            int int數量 = 0;
            Int32.TryParse(txtboxAmount2.Text, out int數量);
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
            cmd0.Parameters.AddWithValue("@SearchByProductID", intProductID);
            cmd0.Parameters.AddWithValue("@SearchByUserID", GlobalVar.UserID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            int OrderedAmount = 0;
            int s = 0;
            int int數量 = 0;
            Int32.TryParse(txtboxAmount2.Text, out int數量);
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
                    cmd1.Parameters.AddWithValue("@ProductID", intProductID);
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

        private void lboxMenu2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxMenu2.SelectedIndex >= 0)
            {
                intProductID = searchIDs[lboxMenu2.SelectedIndex];

                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();

                string strSQL = "select * from Product as p where p.Product_ID = @SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intProductID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblProductName.Text = string.Format("{0}", reader["Product_Name"]);
                    lblPriceEach.Text = string.Format("{0}元", reader["Product_Price"]);
                    priceEach = (int)reader["Product_Price"];
                    getProductName = (string)reader["Product_Name"];
                }
                else
                {
                    MessageBox.Show("查無此商品");
                    lblProductName.Text = "商品名稱";
                }
                計算總價();
                reader.Close();//關閉reader
                con.Close();//關閉資料庫con
                listPicID.Clear();
                listPicName.Clear();
                listPicPrice.Clear();
                imageList1.Images.Clear();
                載入圖片資料();
            }
            else
            {
                MessageBox.Show("查無此資料");
            }
        }
        private void cboxStore2_SelectedIndexChanged(object sender, EventArgs e)
        {
            載入店家菜單();
        }

        private void txtboxAmount2_TextChanged(object sender, EventArgs e)
        {
            if (txtboxAmount2.Text != "")
            {
                bool ifNum = Int32.TryParse(txtboxAmount2.Text, out amount2);

                if ((ifNum == true) && (amount2 >= 1))
                {

                }
                else
                {
                    MessageBox.Show("輸入數量錯誤");
                    amount2 = 1;
                    txtboxAmount2.Text = amount2.ToString();
                }
            }
            else
            {
                amount2 = 1;
            }
            計算總價();
        }

        private void txtboxAmount2_Leave(object sender, EventArgs e)
        {
            if (txtboxAmount2.Text != "")
            {

            }
            else
            {
                txtboxAmount2.Text = "1";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            載入店家();
        }

        private void btnOrder2_Click(object sender, EventArgs e)
        {
            if ((intProductID != 0) && (txtboxAmount2.Text != ""))
            {
                查詢是否已點並新增更新();
            }
            else
            {
                MessageBox.Show("請確認有輸入數量及選擇商品");
            }
        }

        private void btnOpCart_Click(object sender, EventArgs e)
        {
            ShopCartForUser0 購物車頁 = new ShopCartForUser0();
            購物車頁.ShowDialog();
        }
    }
}

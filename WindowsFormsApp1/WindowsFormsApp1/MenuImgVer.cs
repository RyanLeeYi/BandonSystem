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
    public partial class MenuImgVer : Form
    {
        //資料庫
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<int> searchIDs = new List<int>();//lbox切換用
        List<int> searchIDsforOrdered = new List<int>();

        List<string> listPicName = new List<string>();//儲存list index用
        List<int> listPicPrice = new List<int>();
        List<int> listPicID = new List<int>();
        List<string> listStoreName = new List<string>();
        List<string> listPicForSaveName = new List<string>();

        int priceEach;
        int amount;
        string getProductName;
        int intProductID;

        public MenuImgVer()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            if (GlobalVar.UserAccessRights == 0)
            {
                groupBox2.Visible = false;
            }
            載入店家();
            載入圖片資料();
            加入ListView圖片();

            amount = 1;
            txtboxAmount.Text = amount.ToString();
        }
        void 載入店家()
        {
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
                strStore = (string)readerStore["Store_Name"];
                listStoreName.Add(strStore);
                StoreI += 1;
            }
            strMsgStore = "已載入店家資料" + StoreI.ToString() + "筆";
            readerStore.Close();
            conStore.Close();
        }
        void 載入圖片資料()
        {
            int selidx = tabControl1.SelectedIndex;
            string strStoreName = "";
            if (listStoreName.Count > 0)
            {
                strStoreName = listStoreName[selidx];
            }
            //-------con--------
            //string strStoreName = changeTab.Text;
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
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Product where Store_ID = @SearchStoreProduct";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchStoreProduct", strStoreID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string image_dir = @"images\";//設定圖檔路徑，這是相對路徑
            //string image_dir = @"c:\images\";//設定圖檔路徑，這是絕對路徑
            string image_name = "";
            string NamePlusPrice = "";
            string OnlyProductName = "";
            int i = 0;

            while (reader1.Read())
            {
                //利用list建立圖片鍵值
                listPicID.Add((int)reader1["Product_ID"]);//(int)是型別提示
                NamePlusPrice = (string)reader1["Product_Name"];
                listPicName.Add(NamePlusPrice);
                listPicPrice.Add((int)reader1["Product_Price"]);
                image_name = (string)reader1["Product_Image"];//取得檔案名稱
                imageList1.Images.Add(Image.FromFile(image_dir + image_name));//Image.FromFile(檔案路徑 + 檔案名稱)
                i += 1;//計數器可以避免一次讀太多資料，或是可以調整上下頁
            }
            reader1.Close();
            con1.Close();
        }
        void 加入ListView圖片()
        {
            ListView changePicView = new ListView();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    changePicView = listViewPicPage1;
                    break;
                case 1:
                    changePicView = listViewPicPage2;
                    break;
                case 2:
                    changePicView = listViewPicPage3;
                    break;
                case 3:
                    changePicView = listViewPicPage4;
                    break;
                default:
                    break;
            }
            changePicView.Clear();
            changePicView.View = View.LargeIcon;
            imageList1.ImageSize = new Size(120, 120);
            changePicView.LargeImageList = imageList1;

            for (int i = 0; i < imageList1.Images.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();//顯示物件變數
                item.ImageIndex = i;//指定索引值為i
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);//顯示文字設定
                item.Text = listPicName[i];//指定顯示文字
                item.Tag = listPicID[i];//儲存ID為Tag維持關聯性
                changePicView.Items.Add(item);//加入listview顯示頁
            }
        }
        //---ListView用-----
        void 取出價錢()
        {
            //-------con--------
            //string strStoreName = changeTab.Text;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "select * from Product where Product_ID= @SearchProductID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchProductID", intProductID);
            SqlDataReader reader = cmd.ExecuteReader();
            priceEach = 0;
            int s = 0;

            while (reader.Read())
            {
                priceEach += (int)reader["Product_Price"];
                s += 1;
            }
            lblPriceEach.Text = $"{priceEach}元";
            reader.Close();
            con.Close();
        }
        void 計算總價()
        {
            lblTotalPrice.Text = (priceEach * amount).ToString() + "元";
        }
        void 取出選取餐點圖片()
        {
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Product where Product_ID = @SearchProductPic";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchProductPic", intProductID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string image_dir = @"images\";//設定圖檔路徑，這是相對路徑
            //string image_dir = @"c:\images\";//設定圖檔路徑，這是絕對路徑
            string image_name = "";
            int i = 0;

            while (reader1.Read())
            {
                image_name = (string)reader1["Product_Image"];//取得檔案名稱
                picbox1.Image = Image.FromFile(image_dir + image_name);
                i += 1;//計數器可以避免一次讀太多資料，或是可以調整上下頁
            }
            reader1.Close();
            con1.Close();
        }
        void forItemSelectionChanged()
        {
            取出價錢();
            計算總價();
            取出選取餐點圖片();
        }
        void 新增訂單()
        {
            int selidx = tabControl1.SelectedIndex;
            string strStoreName = "";
            if (listStoreName.Count > 0)
            {
                strStoreName = listStoreName[selidx];
            }
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
            Int32.TryParse(txtboxAmount.Text, out int數量);
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
            Int32.TryParse(txtboxAmount.Text, out int數量);
            //更新
            if (reader0.HasRows)
            {
                while (reader0.Read())
                {
                    OrderedAmount += (int)reader0["quantityOrdered"];
                    OrderedAmount += int數量;
                    SqlConnection con1 = new SqlConnection(myDBConnectionString);
                    con1.Open();
                    string strSQL1 = "UPDATE ShoppingCartImg SET quantityOrdered = @NewAmount WHERE Product_ID = @ProductID and User_ID =@SearchByUserID;";
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listPicID.Clear();
            listPicName.Clear();
            listPicPrice.Clear();
            imageList1.Images.Clear();
            intProductID = 0;
            載入圖片資料();
            加入ListView圖片();
        }

        private void listViewPicPage1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            intProductID = (int)e.Item.Tag;
            getProductName = (string)e.Item.Text;
            forItemSelectionChanged();
        }

        private void listViewPicPage2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            intProductID = (int)e.Item.Tag;
            getProductName = (string)e.Item.Text;
            forItemSelectionChanged();
        }

        private void listViewPicPage3_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            intProductID = (int)e.Item.Tag;
            getProductName = (string)e.Item.Text;
            forItemSelectionChanged();
        }

        private void listViewPicPage4_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            intProductID = (int)e.Item.Tag;
            getProductName = (string)e.Item.Text;
            forItemSelectionChanged();
        }

        private void txtboxAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtboxAmount.Text != "")
            {
                bool ifNum = Int32.TryParse(txtboxAmount.Text, out amount);

                if ((ifNum == true) && (amount >= 1))
                {

                }
                else
                {
                    MessageBox.Show("輸入數量錯誤");
                    amount = 1;
                    txtboxAmount.Text = amount.ToString();
                }
            }
            else
            {
                amount = 1;
            }
            計算總價();
        }

        private void txtboxAmount_Leave(object sender, EventArgs e)
        {
            if (txtboxAmount.Text != "")
            {

            }
            else
            {
                txtboxAmount.Text = "1";
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if ((intProductID != 0)&&(txtboxAmount.Text!=""))
            {
                查詢是否已點並新增更新();
            }
            else
            {
                MessageBox.Show("請確認有輸入數量及選擇商品");
            }
        }

        private void btnToShopCart_Click(object sender, EventArgs e)
        {
            ShopCartForUser0 購物車頁 = new ShopCartForUser0();
            購物車頁.ShowDialog();
        }
    }
}

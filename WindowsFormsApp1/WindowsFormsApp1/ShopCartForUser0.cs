using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class ShopCartForUser0 : Form
    {
        //資料庫
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        //購物車
        List<int> searchShopCartIDsforDelete = new List<int>();
        //已訂訂單
        List<int> searchOrdersIDForShowDetail = new List<int>();
        //更改數量
        List<int> ListforChangeAmount = new List<int>();
        List<string> ListforlboxProductName = new List<string>();
        //再買一次
        string strGetProductName = "";
        string strGetStoreName = "";
        int intGetProductID = 0;
        int intGetStoreID = 0;
        int intGetProductPriceEach = 0;
        int intGetProductquantityOrdered = 0;

        int priceEach;
        int ChangeAmount;
        string getProduct;
        int getShopCartID;
        int getNewOrderID;
        int totalShopCartCost = 0;
        int getOrdersID = 0;
        public ShopCartForUser0()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            載入購物車資料();
            計算總價格();
            載入Orders();
            hideOrdersShowShopCart();
        }
        void 載入購物車資料()
        {
            lboxOnOrderCart.Items.Clear();
            searchShopCartIDsforDelete.Clear();
            ListforChangeAmount.Clear();
            ListforlboxProductName.Clear();
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from ShoppingCartImg where User_ID = @UserID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strOrderedImgVer = "";
            string strMsgOrderedImgVer = "";
            int OrderedI = 0;
            while (reader1.Read())
            {
                strOrderedImgVer = String.Format($"店家:{reader1["Store_Name"]} 品名:{reader1["Product_Name"]} 數量:{reader1["quantityOrdered"]} 單價:{reader1["priceEach"]}");
                lboxOnOrderCart.Items.Add(strOrderedImgVer);
                searchShopCartIDsforDelete.Add((int)reader1["ShopCartImg_ID"]);
                ListforChangeAmount.Add((int)reader1["quantityOrdered"]);
                ListforlboxProductName.Add((string)reader1["Store_Name"] +"  "+(string)reader1["Product_Name"]);
                OrderedI += 1;
            }
            if (reader1.HasRows)
            {
                lboxOnOrderCart.SelectedIndex = 0;
            }
            else
            {
                ChangeAmount = 1;
                txtboxAmount.Text = ChangeAmount.ToString();
            }
            strMsgOrderedImgVer = "已載入購物車資料" + OrderedI.ToString() + "筆";
            reader1.Close();
            con1.Close();
        }
        void 清空購物車()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "delete from ShoppingCartImg where User_ID = @UserID;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
            }
            else
            {
                lboxOnOrderCart.Items.Clear();
                計算總價格();
            }
            reader.Close();
            con.Close();
        }
        void 計算總價格()
        {
            totalShopCartCost = 0;
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from ShoppingCartImg where User_ID = @UserID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    totalShopCartCost += (int)reader1["quantityOrdered"] * (int)reader1["priceEach"];
                }
                txtTotalCost.Text = $"{totalShopCartCost}元";
            }
            else
            {
                txtTotalCost.Text = "0元";
            }
            reader1.Close();
            con1.Close();
        }
        void 建立Orders並取得OrdersID()
        {
            int sendClassID = GlobalVar.UserClassID;
            string sendUserID = GlobalVar.UserID;
            string sendUserName = GlobalVar.UserName;
            int totalCost = totalShopCartCost;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into Orders output inserted.Order_ID values(@ClassID,@UserID,@UserName,@OrderDate,@totalCost,0);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ClassID", sendClassID);
            cmd.Parameters.AddWithValue("@UserID", sendUserID);
            cmd.Parameters.AddWithValue("@UserName", sendUserName);
            cmd.Parameters.AddWithValue("@OrderDate", GlobalVar.LogInDate);
            cmd.Parameters.AddWithValue("@totalCost", totalCost);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                getNewOrderID = (int)reader["Order_ID"];
            }
            reader.Close();
            con.Close();
        }
        string 訂單狀態(int OrderStatus)
        {
            string strOrderStatus = "";
            switch (OrderStatus)
            {
                case 0:
                    strOrderStatus = "已收到訂單";
                    break;
                case 1:
                    strOrderStatus = "訂單處理中";
                    break;
                case 2:
                    strOrderStatus = "訂購完成";
                    break;
                case 3:
                    strOrderStatus = "訂單完成";
                    break;
                default:
                    strOrderStatus = "狀態錯誤";
                    break;
            }
            return strOrderStatus;
        }
        void 載入Orders()
        {
            lboxOrders.Items.Clear();
            lboxOrderDetail.Items.Clear();
            searchOrdersIDForShowDetail.Clear();
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Orders where User_ID = @UserID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            string strOrders = "";
            string strGetDate = "";
            string strGetOrderStatus = "";
            DateTime getDate = new DateTime();
            while (reader1.Read())
            {
                //更改日期顯示形式
                getDate = (DateTime)reader1["Order_Date"];
                strGetDate = String.Format("{0:d}", getDate);
                //訂單狀態
                strGetOrderStatus = 訂單狀態((int)reader1["Order_Status"]);
                strOrders = String.Format($"訂單編號:{reader1["Order_ID"]} 訂購日期:{strGetDate} 總價格:{reader1["TotalCost"]} 訂單狀態:{strGetOrderStatus}");
                lboxOrders.Items.Add(strOrders);
                searchOrdersIDForShowDetail.Add((int)reader1["Order_ID"]);
            }
            if (reader1.HasRows)
            {
                lboxOrders.SelectedIndex = 0;
            }
            reader1.Close();
            con1.Close();
        }
        void 載入OrderDetail()
        {
            lboxOrderDetail.Items.Clear();
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from OrderDetail as o join Store as s on o.Store_ID =s.Store_ID where Order_ID = @OrderID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@OrderID", getOrdersID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strOrderDetail = "";
            while (reader1.Read())
            {
                strOrderDetail = String.Format($"店家:{reader1["Store_Name"]} 品名:{reader1["Product_Name"]} 數量:{reader1["quantityOrdered"]} 單價:{reader1["priceEach"]}");
                lboxOrderDetail.Items.Add(strOrderDetail);
            }
            reader1.Close();
            con1.Close();
        }
        void 新增訂單()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into ShoppingCartImg values(@ProductID,@StoreID,@StoreName,@ProductName,@quantityOrdered,@ProductPrice,@ClassID,@UserID);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductID", intGetProductID);
            cmd.Parameters.AddWithValue("@StoreID", intGetStoreID);
            cmd.Parameters.AddWithValue("@StoreName", strGetStoreName);
            cmd.Parameters.AddWithValue("@ProductName", strGetProductName);
            cmd.Parameters.AddWithValue("@ProductPrice", intGetProductPriceEach);
            cmd.Parameters.AddWithValue("@ClassID", GlobalVar.UserClassID);
            cmd.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
            cmd.Parameters.AddWithValue("@quantityOrdered", intGetProductquantityOrdered);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
        }
        void 查詢是否已點並新增更新()
        {
            SqlConnection con0 = new SqlConnection(myDBConnectionString);
            con0.Open();
            string strSQL0 = "select * from ShoppingCartImg where Product_ID = @SearchByProductID and User_ID =@SearchByUserID";
            SqlCommand cmd0 = new SqlCommand(strSQL0, con0);
            cmd0.Parameters.AddWithValue("@SearchByProductID", intGetProductID);
            cmd0.Parameters.AddWithValue("@SearchByUserID", GlobalVar.UserID);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            int OrderedAmount = 0;
            //更新
            if (reader0.HasRows)
            {
                while (reader0.Read())
                {
                    OrderedAmount += (int)reader0["quantityOrdered"];
                    OrderedAmount += intGetProductquantityOrdered;
                    SqlConnection con1 = new SqlConnection(myDBConnectionString);
                    con1.Open();
                    string strSQL1 = "UPDATE ShoppingCartImg SET quantityOrdered = @NewAmount WHERE Product_ID = @ProductID and User_ID = @SearchByUserID;";
                    SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                    cmd1.Parameters.AddWithValue("@ProductID", intGetProductID);
                    cmd1.Parameters.AddWithValue("@SearchByUserID", GlobalVar.UserID);
                    cmd1.Parameters.AddWithValue("@NewAmount", OrderedAmount);

                    int rows = cmd1.ExecuteNonQuery();
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
        void hideShopCartShowOrders()
        {
            panelShopCart.Visible = false;
            panelOrders.Visible = true;
        }
        void hideOrdersShowShopCart()
        {
            panelShopCart.Visible = true;
            panelOrders.Visible = false;
        }
        private void btnDeleteAllCart_Click(object sender, EventArgs e)
        {
            const string message = "你確定要刪除所有訂單?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                清空購物車();
                載入購物車資料();
                MessageBox.Show("購物車清空完畢");
            }
        }

        private void btnDeleteCartOne_Click(object sender, EventArgs e)
        {
            int selIdx = lboxOnOrderCart.SelectedIndex;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "delete from ShoppingCartImg where ShopCartImg_ID = @DeleteID ;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@DeleteID", searchShopCartIDsforDelete[selIdx]);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(rows.ToString() + "筆訂單刪除成功");
            載入購物車資料();
            計算總價格();
        }

        private void lboxOnOrderCartImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = lboxOnOrderCart.SelectedIndex;
            if (selindex > -1)
            {
                getShopCartID = searchShopCartIDsforDelete[selindex];
                ChangeAmount = ListforChangeAmount[selindex];
                txtboxAmount.Text = ListforChangeAmount[selindex].ToString();
                lblProductName.Text = ListforlboxProductName[selindex];
            }
        }

        private void btnPlusAmount1_Click(object sender, EventArgs e)
        {
            int plus = 0;
            bool tryp = Int32.TryParse(txtboxAmount.Text, out plus);
            if (tryp == true)
            {
                plus += 1;
                ChangeAmount = plus;
                txtboxAmount.Text = plus.ToString();
            }
            else
            {
                MessageBox.Show("請輸入正整數數字");
            }
        }

        private void btnMinusAmount1_Click(object sender, EventArgs e)
        {
            int minus = 0;
            bool tryp = Int32.TryParse(txtboxAmount.Text, out minus);
            if (tryp == true)
            {
                if (minus > 1)
                {
                    minus -= 1;
                    ChangeAmount = minus;
                    txtboxAmount.Text = minus.ToString();
                }
                else
                {
                    MessageBox.Show("訂購數不可為0或負數");
                }
            }
            else
            {
                MessageBox.Show("請輸入正整數數字");
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtboxAmount.Text != "")
            {
                bool ifNum = Int32.TryParse(txtboxAmount.Text, out ChangeAmount);

                if ((ifNum == true) && (ChangeAmount >= 1))
                {
                }
                else
                {
                    MessageBox.Show("輸入數量錯誤");
                    ChangeAmount = 1;
                    txtboxAmount.Text = ChangeAmount.ToString();
                }
            }
            else
            {
                ChangeAmount = 1;
            }
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

        private void btnChangeAmount_Click(object sender, EventArgs e)
        {
            Int32.TryParse(txtboxAmount.Text, out ChangeAmount);
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "UPDATE ShoppingCartImg SET quantityOrdered = @NewAmount WHERE ShopCartImg_ID = @SearchByCartID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchByCartID", getShopCartID);
            cmd1.Parameters.AddWithValue("@NewAmount", ChangeAmount);

            int rows = cmd1.ExecuteNonQuery();
            MessageBox.Show(rows.ToString() + "筆訂單數量更改成功");
            con1.Close();
            載入購物車資料();
            計算總價格();
        }

        private void btnSendOut_Click(object sender, EventArgs e)
        {
            const string message = "確定送出訂單?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from ShoppingCartImg where User_ID = @UserID;";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    建立Orders並取得OrdersID();
                    int irow = 0;
                    while (reader1.Read()) 
                    {
                        int sendProductID = (int)reader1["Product_ID"];
                        string sendProductName = (string)reader1["Product_Name"];
                        int sendStoreID = (int)reader1["Store_ID"];
                        int sendquantityOrdered = (int)reader1["quantityOrdered"];
                        int sendPriceEach = (int)reader1["priceEach"];
                        //建立OrderDetail
                        SqlConnection con = new SqlConnection(myDBConnectionString);
                        con.Open();
                        string strSQL = "insert into OrderDetail values(@OrderID,@ProductID,@ProductName,@StoreID,@quantityOrdered,@priceEach);";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@OrderID", getNewOrderID);
                        cmd.Parameters.AddWithValue("@ProductID", sendProductID);
                        cmd.Parameters.AddWithValue("@ProductName", sendProductName);
                        cmd.Parameters.AddWithValue("@StoreID", sendStoreID);
                        cmd.Parameters.AddWithValue("@quantityOrdered", sendquantityOrdered);
                        cmd.Parameters.AddWithValue("@priceEach", sendPriceEach);

                        int rows = cmd.ExecuteNonQuery();
                        irow += rows;
                        con.Close();
                    }
                    MessageBox.Show(irow.ToString() + "筆訂單數量送出成功");
                    清空購物車();
                    載入Orders();
                }
                else
                {
                    MessageBox.Show("購物車內無商品");
                }
                reader1.Close();
                con1.Close();
            }
        }

        private void lboxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = lboxOrders.SelectedIndex;
            if (selindex > -1)
            {
                getOrdersID = searchOrdersIDForShowDetail[selindex];
                載入OrderDetail();
            }
        }

        private void btnBuyAgain_Click(object sender, EventArgs e)
        {
            int selindex = lboxOrders.SelectedIndex;
            if (selindex>-1)
            {
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "select * from OrderDetail as o join Store as s on o.Store_ID =s.Store_ID where Order_ID = @OrderID;";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@OrderID", getOrdersID);
                SqlDataReader reader1 = cmd1.ExecuteReader();


                while (reader1.Read())
                {
                    strGetProductName = (string)reader1["Product_Name"];
                    strGetStoreName = (string)reader1["Store_Name"];
                    intGetProductID = (int)reader1["Product_ID"];
                    intGetStoreID = (int)reader1["Store_ID"];
                    intGetProductPriceEach = (int)reader1["priceEach"];
                    intGetProductquantityOrdered = (int)reader1["quantityOrdered"];
                    查詢是否已點並新增更新();
                }
                reader1.Close();
                con1.Close();
                載入購物車資料();
                hideOrdersShowShopCart();
            }
            else
            {
                MessageBox.Show("請選擇過往訂單");
            }
        }

        private void btnToShopCart_Click(object sender, EventArgs e)
        {
            hideOrdersShowShopCart();
        }

        private void btnToOrders_Click(object sender, EventArgs e)
        {
            hideShopCartShowOrders();
        }
    }
}

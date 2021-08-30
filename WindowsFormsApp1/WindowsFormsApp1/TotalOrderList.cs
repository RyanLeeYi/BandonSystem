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

namespace WindowsFormsApp1
{
    public partial class TotalOrderList : Form
    {
        //資料庫
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        List<int> searchOrderedIDsInStore = new List<int>();//lbox切換用
        List<int> searchOrderedIDsInClass = new List<int>();

        List<RadioButton> ListForRadioButtons = new List<RadioButton>();

        List<string> forOrderStoreProductName = new List<string>();
        List<int> forOrderStoreProductAmount = new List<int>();
        List<string> forOrderClassProductName = new List<string>();
        List<int> forOrderClassProductAmount = new List<int>();

        List<string> listClass2 = new List<string>();
        List<string> listStore2 = new List<string>();
        List<string> orderName = new List<string>();
        List<int> orderAmount = new List<int>();
        List<int> searchOrderIDsforDelete = new List<int>();
        List<int> searchProductIDsforDelete = new List<int>();
        int getClassID = 0;
        int totalPriceInClass = 0;
        int totalPriceInStore = 0;
        int totalPriceAll = 0;
        public TotalOrderList()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //資料庫
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "BANDON";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
            ListForRadioButtons.Add(rbtnAll);
            ListForRadioButtons.Add(rbtnStore);
            ListForRadioButtons.Add(rbtnClass);
            hidebutton();
        }
        void rbtnChange()
        {
            if (rbtnAll.Checked == true)
            {
                cboxAll.Items.Clear();
                cboxAll.Enabled = false;
                hidebutton();
                btnDelectAll.Visible = true;
                btnDelectOne.Visible = true;
                載入所有訂單();
                btnPrint.Text = "全部列印";
            }
            else if (rbtnClass.Checked == true)
            {
                cboxAll.Enabled = true;
                hidebutton();
                載入班級();
                btnPrint.Text = "依班級列印";
            }
            else if (rbtnStore.Checked == true)
            {
                cboxAll.Enabled = true;
                hidebutton();
                載入店家();
                btnPrint.Text = "依店家列印";
            }
        }
        void hidebutton()
        {
            btnDelectOne.Visible = false;
            btnDelectAll.Visible = false;
        }
        void 載入店家()
        {
            cboxAll.Items.Clear();
            searchOrderedIDsInStore.Clear();
            SqlConnection conStore = new SqlConnection(myDBConnectionString);
            conStore.Open();
            string strSQLStore = "select * from Store";
            SqlCommand cmdStore = new SqlCommand(strSQLStore, conStore);
            SqlDataReader readerStore = cmdStore.ExecuteReader();

            string strStore = "";
            string strMsgStore = "";
            int StoreI = 0;
            while (readerStore.Read())
            {
                strStore = String.Format($"{readerStore["Store_Name"]}");
                cboxAll.Items.Add(strStore);
                searchOrderedIDsInStore.Add((int)readerStore["Store_ID"]);
                StoreI += 1;
            }
            strMsgStore = "已載入店家資料" + StoreI.ToString() + "筆";
            readerStore.Close();
            conStore.Close();
            cboxAll.SelectedIndex = 0;
        }
        void 載入班級()
        {
            cboxAll.Items.Clear();
            searchOrderedIDsInClass.Clear();
            SqlConnection conClass = new SqlConnection(myDBConnectionString);
            conClass.Open();
            string strSQLClass = "select * from Class";
            SqlCommand cmdClass = new SqlCommand(strSQLClass, conClass);
            SqlDataReader readerClass = cmdClass.ExecuteReader();

            string strClass = "";
            string strMsgClass = "";
            int ClassI = 0;
            while (readerClass.Read())
            {
                strClass = String.Format($"{readerClass["Class_Name"]}");
                cboxAll.Items.Add(strClass);
                searchOrderedIDsInClass.Add((int)readerClass["Class_ID"]);
                ClassI += 1;
            }
            strMsgClass = "已載入班級資料" + ClassI.ToString() + "筆";
            readerClass.Close();
            conClass.Close();
            cboxAll.SelectedIndex = 0;
        }
        void 載入店家已訂訂單()
        {
            totalPriceInStore = 0;
            lboxAllOrders.Items.Clear();
            int selindex = cboxAll.SelectedIndex;
            int StoreID = searchOrderedIDsInStore[selindex];
            //資料庫lbox品項
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select od.Product_ID,sum(od.quantityOrdered)as totalOrder,AVG(od.priceEach) as priceEach,max(od.Product_Name) as productName " +
                            "from Orders as o join OrderDetail as od on o.Order_ID = od.Order_ID join Store as s on od.Store_ID = s.Store_ID "+
                            "where od.Store_ID = @SearchStoreByID " +
                            "group by od.Product_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchStoreByID", StoreID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strStoreOrder = "";
            int getPrice1 = 0;
            while (reader1.Read())
            {
                strStoreOrder = String.Format($"品名:{reader1["productName"]} " +
                    $"價格:{reader1["priceEach"]} 數量:{reader1["totalOrder"]}");
                lboxAllOrders.Items.Add(strStoreOrder);
                getPrice1 = (int)reader1["priceEach"] * (int)reader1["totalOrder"];
                totalPriceInStore += getPrice1;
            }
            if (reader1.HasRows)
            {
                lboxAllOrders.SelectedIndex = 0;
            }
            TotalPriceInStore();
            reader1.Close();
            con1.Close();
        }
        void 取出班級ID()
        {
            int selindex = cboxAll.SelectedIndex;
            getClassID = searchOrderedIDsInClass[selindex];
        }
        void 載入班級已訂訂單()
        {
            totalPriceInClass = 0;
            lboxAllOrders.Items.Clear();
            //取出總數及產品ID
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select od.Product_ID,sum(od.quantityOrdered) as totalOrder,AVG(od.priceEach) as priceEach " +
                "from Orders as o join OrderDetail as od on o.Order_ID=od.Order_ID " +
                            "where Class_ID = @SearchClassByID " +
                            "group by od.Product_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchClassByID", getClassID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strClassOrder = "";
            int getProductID = 0;
            string strStoreName = "";
            string strProductName = "";
            int ProductI = 0;
            int getPrice1 = 0;
            while (reader1.Read())
            {
                //取出產品名稱、店家名稱、商品價格。
                getProductID = (int)reader1["Product_ID"];
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "select * from Store as s join Product as p on (s.Store_ID=p.Store_ID) where Product_ID = @SearchByProductID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchByProductID", getProductID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    strStoreName = (string)reader["Store_Name"];
                    strProductName = (string)reader["Product_Name"];
                }
                reader.Close();
                con.Close();
                strClassOrder = String.Format($"店家:{strStoreName} 品名:{strProductName}" +
                    $" 價格:{(int)reader1["priceEach"]} 數量:{reader1["totalOrder"]}");
                lboxAllOrders.Items.Add(strClassOrder);
                getPrice1 = (int)reader1["priceEach"] * (int)reader1["totalOrder"];
                totalPriceInClass += getPrice1;
                ProductI += 1;
            }
            if (reader1.HasRows)
            {
                lboxAllOrders.SelectedIndex = 0;
            }
            TotalPriceInClass();
            reader1.Close();
            con1.Close();
        }
        void 載入所有訂單()
        {
            totalPriceAll = 0;
            lboxAllOrders.Items.Clear();
            searchOrderIDsforDelete.Clear();
            //資料庫lbox品項
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Orders as o join OrderDetail as od on o.Order_ID=od.Order_ID join Store as s on od.Store_ID=s.Store_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strAllOrder = "";
            string strMsgAllOrder = "";
            int ProductI = 0;
            int getPrice1 = 0;
            while (reader1.Read())
            {
                strAllOrder = String.Format($"店家:{reader1["Store_Name"]} 品名:{reader1["Product_Name"]} " +
                    $"價格:{reader1["PriceEach"]} 數量:{reader1["quantityOrdered"]} 訂購人:{reader1["User_Name"]}");
                lboxAllOrders.Items.Add(strAllOrder);
                searchProductIDsforDelete.Add((int)reader1["Product_ID"]);
                searchOrderIDsforDelete.Add((int)reader1["Order_ID"]);
                getPrice1 = (int)reader1["priceEach"] * (int)reader1["quantityOrdered"];
                totalPriceAll += getPrice1;
                ProductI += 1;
            }
            strMsgAllOrder = "已載入全部資料" + ProductI.ToString() + "筆";
            TotalPriceAll();
            reader1.Close();
            con1.Close();
        }

        void TotalPriceInStore()
        {
            lbTotalPriceAll.Text = $"總計 {totalPriceInStore} 元";
        }
        void TotalPriceInClass()
        {
            lbTotalPriceAll.Text = $"總計 {totalPriceInClass} 元";
        }
        void TotalPriceAll()
        {
            lbTotalPriceAll.Text = $"總計 {totalPriceAll} 元";
        }

        private void btnDelectOne_Click(object sender, EventArgs e)
        {
            int selIdx = lboxAllOrders.SelectedIndex;
            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "delete from OrderDetail where Order_ID = @DeleteByOrderID and Product_ID=@DeleteProductByID;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@DeleteByOrderID", searchOrderIDsforDelete[selIdx]);
            cmd.Parameters.AddWithValue("@DeleteProductByID", searchProductIDsforDelete[selIdx]);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(rows.ToString() + "筆訂單刪除成功");
            載入所有訂單();
        }

        private void btnDelectAll_Click(object sender, EventArgs e)
        {
            const string message ="你確定要刪除所有訂單?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //清空Orders
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from Orders;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                }
                else
                {
                    MessageBox.Show("清空完成");
                }
                reader.Close();
                con.Close();
                //清空OrderDetail
                SqlConnection con1 = new SqlConnection(myDBConnectionString);
                con1.Open();
                string strSQL1 = "delete from OrderDetail;";
                SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
                cmd1.Parameters.AddWithValue("@UserID", GlobalVar.UserID);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.HasRows)
                {
                }
                else
                {
                    MessageBox.Show("清空完成");
                }
                reader1.Close();
                con1.Close();
                載入所有訂單();
            }
        }
        void PrintByClass()
        {
            string ClassName = cboxAll.Text;
            取出班級ID();
            //指定輸出存儲的路徑，用複製時要注意加上最後一條\
            string str檔案路徑 = @"C:\Users\User\OneDrive\課程\CODE\個人用\WindowsFormsApp1\printOut\";

            //指定輸出名稱
            Random myRnd = new Random();
            int myNum = myRnd.Next(1000, 9999);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + myNum.ToString() + ClassName + @".txt";
            string str完整路徑檔 = str檔案路徑 + str檔名; //預設檔名+路徑

            //使用者自行決定輸出檔名，若沒有則直接使用預設檔名+路徑
            SaveFileDialog sfd = new SaveFileDialog(); //跳出檔案存儲視窗
            sfd.InitialDirectory = str檔案路徑; //設定預設儲存目錄
            sfd.FileName = str檔名; //設定預設檔名
            sfd.Filter = "Txt File|*.txt";// |左邊為對檔案的描述，|右邊為限定存儲的檔案類型
            //可以改為網頁版HTML輸出，編碼需要為UTF-8

            DialogResult R = sfd.ShowDialog();//接收使用者在儲存視窗的動作，若按確定則會回傳DialogResult.OK

            //按下確定或取消之後的動作
            if (R == DialogResult.OK)
            {
                //按下確定
                str完整路徑檔 = sfd.FileName;//存取user的設定，同時會存取USER的指定名稱及路徑。
            }
            else
            {
                //按下取消
                return;
            }

            //將資料轉化為list來輸出
            List<string> lines訂購資訊 = new List<string>();
            lines訂購資訊.Add("****----------III便當訂單------------*****");
            lines訂購資訊.Add("==========================================");
            lines訂購資訊.Add(DateTime.Now.ToString() + "  訂購班級:" + ClassName);
            lines訂購資訊.Add("------------------------------------------");
            lines訂購資訊.Add("<<訂購品項>>");

            totalPriceInClass = 0;
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select od.Product_ID,sum(od.quantityOrdered) as totalOrder,AVG(od.priceEach) as priceEach " +
                "from Orders as o join OrderDetail as od on o.Order_ID=od.Order_ID " +
                            "where Class_ID = @SearchClassByID " +
                            "group by od.Product_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchClassByID", getClassID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strClassOrder = "";
            int getProductID = 0;
            string strStoreName = "";
            string strProductName = "";
            int ProductI = 0;
            int getPrice1 = 0;
            while (reader1.Read())
            {
                //取出產品名稱、店家名稱、商品價格。
                getProductID = (int)reader1["Product_ID"];
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "select * from Store as s join Product as p on (s.Store_ID=p.Store_ID) where Product_ID = @SearchByProductID;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchByProductID", getProductID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    strStoreName = (string)reader["Store_Name"];
                    strProductName = (string)reader["Product_Name"];
                }
                reader.Close();
                con.Close();
                strClassOrder = String.Format($"店家:{strStoreName} 品名:{strProductName}" +
                    $" 價格:{(int)reader1["priceEach"]} 數量:{reader1["totalOrder"]}");
                lines訂購資訊.Add(strClassOrder);
                getPrice1 = (int)reader1["priceEach"] * (int)reader1["totalOrder"];
                totalPriceInClass += getPrice1;
                ProductI += 1;
            }
            if (reader1.HasRows)
            {
                lboxAllOrders.SelectedIndex = 0;
            }
            TotalPriceInClass();
            reader1.Close();
            con1.Close();
            lines訂購資訊.Add("-------------------------------------------");
            lines訂購資訊.Add("總價:" + totalPriceInClass.ToString());//計算訂單總價要有return語法，才有回傳值才能轉化為字串。
            lines訂購資訊.Add("===========================================");

            //儲存
            //參數System.IO.File.WriteAllLines(輸出路徑,輸出資料,語言編碼)
            //WriteAllLines會將list的內容分行印出
            System.IO.File.WriteAllLines(str完整路徑檔, lines訂購資訊, Encoding.UTF8);
            MessageBox.Show("存檔成功");
        }

        void PrintByStore()
        {
            string StoreName = cboxAll.Text;
            //指定輸出存儲的路徑，用複製時要注意加上最後一條\
            string str檔案路徑 = @"C:\Users\User\OneDrive\課程\CODE\個人用\WindowsFormsApp1\printOut\";

            //指定輸出名稱
            Random myRnd = new Random();
            int myNum = myRnd.Next(1000, 9999);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + myNum.ToString() + StoreName + @"訂單.txt";
            string str完整路徑檔 = str檔案路徑 + str檔名; //預設檔名+路徑

            //使用者自行決定輸出檔名，若沒有則直接使用預設檔名+路徑
            SaveFileDialog sfd = new SaveFileDialog(); //跳出檔案存儲視窗
            sfd.InitialDirectory = str檔案路徑; //設定預設儲存目錄
            sfd.FileName = str檔名; //設定預設檔名
            sfd.Filter = "Txt File|*.txt";// |左邊為對檔案的描述，|右邊為限定存儲的檔案類型
            //可以改為網頁版HTML輸出，編碼需要為UTF-8

            DialogResult R = sfd.ShowDialog();//接收使用者在儲存視窗的動作，若按確定則會回傳DialogResult.OK

            //按下確定或取消之後的動作
            if (R == DialogResult.OK)
            {
                //按下確定
                str完整路徑檔 = sfd.FileName;//存取user的設定，同時會存取USER的指定名稱及路徑。
            }
            else
            {
                //按下取消
                return;
            }

            //將資料轉化為list來輸出
            List<string> lines訂購資訊 = new List<string>();
            lines訂購資訊.Add("****----------III便當訂單------------*****");
            lines訂購資訊.Add("==========================================");
            lines訂購資訊.Add(DateTime.Now.ToString() + "  店家:" + StoreName);
            lines訂購資訊.Add("------------------------------------------");
            lines訂購資訊.Add("<<訂購品項>>");

            totalPriceInStore = 0;
            int selindex = cboxAll.SelectedIndex;
            int StoreID = searchOrderedIDsInStore[selindex];
            //資料庫lbox品項
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select od.Product_ID,sum(od.quantityOrdered)as totalOrder,AVG(od.priceEach) as priceEach,max(od.Product_Name) as productName " +
                            "from Orders as o join OrderDetail as od on o.Order_ID = od.Order_ID join Store as s on od.Store_ID = s.Store_ID " +
                            "where od.Store_ID = @SearchStoreByID " +
                            "group by od.Product_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            cmd1.Parameters.AddWithValue("@SearchStoreByID", StoreID);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strStoreOrder = "";
            int getPrice1 = 0;
            while (reader1.Read())
            {
                strStoreOrder = String.Format($"品名:{reader1["productName"]} " +
                    $"價格:{reader1["priceEach"]} 數量:{reader1["totalOrder"]}");
                lines訂購資訊.Add(strStoreOrder);
                getPrice1 = (int)reader1["priceEach"] * (int)reader1["totalOrder"];
                totalPriceInStore += getPrice1;
            }
            if (reader1.HasRows)
            {
                lboxAllOrders.SelectedIndex = 0;
            }
            TotalPriceInStore();
            reader1.Close();
            con1.Close();
            lines訂購資訊.Add("-------------------------------------------");
            lines訂購資訊.Add("總價:" + totalPriceInStore.ToString());//計算訂單總價要有return語法，才有回傳值才能轉化為字串。
            lines訂購資訊.Add("===========================================");

            //儲存
            //參數System.IO.File.WriteAllLines(輸出路徑,輸出資料,語言編碼)
            //WriteAllLines會將list的內容分行印出
            System.IO.File.WriteAllLines(str完整路徑檔, lines訂購資訊, Encoding.UTF8);
            MessageBox.Show("存檔成功");
        }
        void PrintAll()
        {
            //指定輸出存儲的路徑，用複製時要注意加上最後一條\
            string str檔案路徑 = @"C:\Users\User\OneDrive\課程\CODE\個人用\WindowsFormsApp1\printOut\";

            //指定輸出名稱
            Random myRnd = new Random();
            int myNum = myRnd.Next(1000, 9999);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + myNum.ToString() + @"全部訂單.txt";
            string str完整路徑檔 = str檔案路徑 + str檔名; //預設檔名+路徑

            //使用者自行決定輸出檔名，若沒有則直接使用預設檔名+路徑
            SaveFileDialog sfd = new SaveFileDialog(); //跳出檔案存儲視窗
            sfd.InitialDirectory = str檔案路徑; //設定預設儲存目錄
            sfd.FileName = str檔名; //設定預設檔名
            sfd.Filter = "Txt File|*.txt";// |左邊為對檔案的描述，|右邊為限定存儲的檔案類型
            //可以改為網頁版HTML輸出，編碼需要為UTF-8

            DialogResult R = sfd.ShowDialog();//接收使用者在儲存視窗的動作，若按確定則會回傳DialogResult.OK

            //按下確定或取消之後的動作
            if (R == DialogResult.OK)
            {
                //按下確定
                str完整路徑檔 = sfd.FileName;//存取user的設定，同時會存取USER的指定名稱及路徑。
            }
            else
            {
                //按下取消
                return;
            }

            //將資料轉化為list來輸出
            List<string> lines訂購資訊 = new List<string>();
            lines訂購資訊.Add("****----------III便當訂單------------*****");
            lines訂購資訊.Add("==========================================");
            lines訂購資訊.Add(DateTime.Now.ToString() + "  全部訂單");
            lines訂購資訊.Add("------------------------------------------");
            lines訂購資訊.Add("<<訂購品項>>");

            totalPriceAll = 0;
            //資料庫lbox品項
            SqlConnection con1 = new SqlConnection(myDBConnectionString);
            con1.Open();
            string strSQL1 = "select * from Orders as o join OrderDetail as od on o.Order_ID=od.Order_ID join Store as s on od.Store_ID=s.Store_ID;";
            SqlCommand cmd1 = new SqlCommand(strSQL1, con1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            string strAllOrder = "";
            int ProductI = 0;
            int getPrice1 = 0;

            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    strAllOrder = String.Format($"店家:{reader1["Store_Name"]}品名:{reader1["Product_Name"]} " +
                        $"價格:{reader1["PriceEach"]} 數量:{reader1["quantityOrdered"]} 訂購人:{reader1["User_Name"]}");
                    lines訂購資訊.Add(strAllOrder);
                    getPrice1 = (int)reader1["priceEach"] * (int)reader1["quantityOrdered"];
                    totalPriceInStore += getPrice1;
                    ProductI += 1;
                }
            }
            reader1.Close();
            con1.Close();
            lines訂購資訊.Add("-------------------------------------------");
            lines訂購資訊.Add("總價:" + totalPriceAll.ToString());//計算訂單總價要有return語法，才有回傳值才能轉化為字串。
            lines訂購資訊.Add("===========================================");

            //儲存
            //參數System.IO.File.WriteAllLines(輸出路徑,輸出資料,語言編碼)
            //WriteAllLines會將list的內容分行印出
            System.IO.File.WriteAllLines(str完整路徑檔, lines訂購資訊, Encoding.UTF8);
            MessageBox.Show("存檔成功");
        }
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked == true)
            {
                PrintAll();
            }
            else if (rbtnClass.Checked == true)
            {
                取出班級ID();
                PrintByClass();
            }
            else if (rbtnStore.Checked == true)
            {
                PrintByStore();
            }
            else
            {
                MessageBox.Show("請選擇分類");
            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            rbtnChange();
        }

        private void rbtnStore_CheckedChanged(object sender, EventArgs e)
        {
            rbtnChange();
        }

        private void rbtnClass_CheckedChanged(object sender, EventArgs e)
        {
            rbtnChange();
        }

        private void cboxAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked == true)
            {
            }
            else if (rbtnClass.Checked == true)
            {
                取出班級ID();
                載入班級已訂訂單();
            }
            else if (rbtnStore.Checked == true)
            {
                載入店家已訂訂單();
            }
        }
    }
}

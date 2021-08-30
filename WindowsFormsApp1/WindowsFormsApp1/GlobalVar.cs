using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApp1
{
    class GlobalVar
    {
        public static List<ArrayList> OnOrderList = new List<ArrayList>();

        //使用者名稱及權限
        public static string UserName = "";
        public static string UserID = "";
        public static int UserClassID = 0;
        public static int UserAccessRights = 0;
        public static DateTime LogInDate = DateTime.Today;

        public enum AccessRights
        {
            學生 = 0,
            值日生 = 1,
            教職員 = 2,
            管理者 = 3
        }
        public enum OrderStatus
        {
            已收到訂單 = 0,
            訂單處理中 = 1,
            訂購完成 = 2,
            訂單完成 = 3
        }
    }
}

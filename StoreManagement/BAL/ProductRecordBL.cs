namespace StoreManagement.BAL
{
    public class ProductRecordBL
    {
        public static bool IsInputValidAndReturnNoti(int productID, int productCount, out string[] notifications)
        {
            notifications = new string[2];
            bool res = true;

            if(productID <= 0)
            {
                notifications[0] = "Mã sản phẩm không được trống. (Nhập sản phẩm nếu chưa có sản phẩm nào trong danh sách)";
                res = false;
            }    
            if(productCount < 1)
            {
                notifications[1] = "Số lượng sản phẩm không được để trống hoặc nhỏ hơn 1.";
                res = false;
            }
            return res;
        }
    }
}

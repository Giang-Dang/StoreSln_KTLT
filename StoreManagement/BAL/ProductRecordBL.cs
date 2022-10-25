using StoreManagement.Entities;

namespace StoreManagement.BAL
{
    public class ProductRecordBL
    {
        public static bool IsInputValidAndReturnNoti(int productID, int productCount, bool isReceipt, out string[] notifications)
        {
            notifications = new string[3];
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

            if(isReceipt)
            {
                int productLeftCount = ProductBL.CountInInvoices(productID) - ProductBL.CountInReceipts(productID);
                var products = ProductBL.ReadData();
                var productName = ProductBL.FindByID(productID).Name;
                if (productCount > productLeftCount)
                {
                    notifications[2] = $"Số lượng xuất kho của sản phẩm {productName} không được lớn số lượng tồn kho ({productLeftCount}).";
                    res = false;
                }
            }    
            
            return res;
        }

        public static ProductRecord FindByID(bool isReceipt, int invoiceOrReceiptID, int recordID)
        {
            if(isReceipt)
            {
                return ReceiptBL.FindByID(invoiceOrReceiptID).ProductRecords.FirstOrDefault(pr => pr.ID == recordID);  
            }
            return InvoiceBL.FindByID(invoiceOrReceiptID).ProductRecords.FirstOrDefault(pr => pr.ID == recordID);
        }

        public static bool CanDeleteInInvoice(int invoiceID, int recordID)
        {
            var productRecord = FindByID(false, invoiceID, recordID);
            var productLeftCount = ProductBL.CountInInvoices(productRecord.ProductID) - ProductBL.CountInReceipts(productRecord.ProductID);
            return productLeftCount - productRecord.ProductCount >= 0;
        }    
    }
}

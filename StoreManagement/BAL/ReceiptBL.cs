using StoreManagement.DAL;
using StoreManagement.Entities;

namespace StoreManagement.BAL
{
    public class ReceiptBL
    {
        public static List<Receipt> ReadData()
        {
            return ReceiptDA.ReadData();
        }

        public static int GetNextID()
        {
            var receipts = ReceiptDA.ReadData();
            int res = 1;
            if (receipts.Any())
            {
                res = receipts.Max(i => i.ID) + 1;
            }
            return res;
        }

        public static bool AddProductRecord(int receiptID, int productID, int productCount)
        {
            var products = ProductDA.ReadData();
            var receipts = ReceiptDA.ReadData();

            var receipt = receipts.FirstOrDefault(i => i.ID == receiptID);

            int recordID = 1;
            if (receipt.ProductRecords == null)
            {
                receipt.ProductRecords = new List<ProductRecord>();
            }
            if (receipt.ProductRecords.Any())
            {
                recordID = receipt.ProductRecords.Max(r => r.ID) + 1;
            }
            ProductRecord record = new ProductRecord(recordID, productID, productCount);
            receipt.ProductRecords.Add(record);

            ReceiptDA.Edit(receipt);

            return true;
        }

        public static bool Add(int id, DateTime creationDateTime)
        {
            var receipt = new Receipt(id, creationDateTime);
            return ReceiptDA.Add(receipt);
        }

        public static bool Edit(int id, DateTime creationDateTime, List<ProductRecord> productRecords)
        {
            var receipt = new Receipt(id, creationDateTime, productRecords);
            return ReceiptDA.Edit(receipt);
        }

        public static bool RemoveAtID(int id)
        {
            return ReceiptDA.RemoveAtID(id);
        }
        public static bool AnyMatchID(int id)
        {
            var receipts = ReceiptDA.ReadData();
            return receipts.Any(i => i.ID == id);
        }

        public static Receipt FindByID(int id)
        {
            var receipts = ReceiptDA.ReadData();
            return receipts.SingleOrDefault(i => i.ID == id);
        }

        public static bool AnyProductMatchID(int productID)
        {
            var receipts = ReadData();
            var res = false;
            foreach (var receipt in receipts)
            {
                foreach (var productRecord in receipt.ProductRecords)
                {
                    if (productRecord.ProductID == productID)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }
    }
}

using StoreManagement.DAL;
using StoreManagement.Entities;

namespace StoreManagement.BAL
{
    public class InvoiceBL
    {

        public static List<Invoice> ReadData()
        {
            return InvoiceDA.ReadData();
        }

        public static int GetNextID()
        {
            var invoices = InvoiceDA.ReadData();
            int res = 1;
            if(invoices.Any())
            {
                res = invoices.Max(i => i.ID);
            }
            return res;
        }

        public static bool AddProductRecord(int invoiceID, int productID, int productCount)
        {
            var products = ProductDA.ReadData();
            var invoices = InvoiceDA.ReadData();

            var invoice = invoices.FirstOrDefault(i => i.ID == invoiceID);
            var product = products.FirstOrDefault(i => i.ID == productID);

            int recordID = 1;
            if(invoice.ProductRecords == null)
            {
                invoice.ProductRecords = new List<ProductRecord>();
            }    
            if (invoice.ProductRecords.Any())
            {
                recordID = invoice.ProductRecords.Max(r => r.ID);
            }
            ProductRecord record = new ProductRecord(recordID, product, productCount);
            invoice.ProductRecords.Add(record);

            InvoiceDA.Edit(invoice);

            return true;
        }

        public static bool Add(int id, DateTime creationDateTime)
        {
            var invoice = new Invoice(id, creationDateTime);
            return InvoiceDA.Add(invoice);
        }

    }
}

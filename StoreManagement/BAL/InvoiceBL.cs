using StoreManagement.DAL;
using StoreManagement.Entities;
using System.Globalization;
using System.Net.WebSockets;

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
                res = invoices.Max(i => i.ID) + 1;
            }
            return res;
        }

        public static bool AddProductRecord(int invoiceID, int productID, int productCount)
        {
            var products = ProductDA.ReadData();
            var invoices = InvoiceDA.ReadData();

            var invoice = invoices.FirstOrDefault(i => i.ID == invoiceID);

            int recordID = 1;
            if(invoice.ProductRecords == null)
            {
                invoice.ProductRecords = new List<ProductRecord>();
            }    
            if (invoice.ProductRecords.Any())
            {
                recordID = invoice.ProductRecords.Max(r => r.ID) + 1;
            }
            ProductRecord record = new ProductRecord(recordID, productID, productCount);
            invoice.ProductRecords.Add(record);

            InvoiceDA.Edit(invoice);

            return true;
        }

        public static bool Add(int id, DateTime creationDateTime)
        {
            var invoice = new Invoice(id, creationDateTime);
            return InvoiceDA.Add(invoice);
        }

        public static bool Edit(int id, DateTime creationDateTime, List<ProductRecord> productRecords)
        {
            var invoice = new Invoice(id, creationDateTime, productRecords);
            return InvoiceDA.Edit(invoice);
        }

        public static bool RemoveAtID(int id)
        {
            return InvoiceDA.RemoveAtID(id);
        }
        public static bool AnyMatchID(int id)
        {
            var invoices = InvoiceDA.ReadData();
            return invoices.Any(i => i.ID == id);
        }

        public static Invoice FindByID(int id)
        {
            var invoices = InvoiceDA.ReadData();
            return invoices.SingleOrDefault(i => i.ID == id);
        }

        public static bool AnyProductMatchID(int productID)
        {
            var invoices = ReadData();
            var res = false;
            foreach(var invoice in invoices)
            {
                foreach(var productRecord in invoice.ProductRecords)
                {
                    if(productRecord.ProductID == productID)
                    {
                        res = true;
                    }    
                }    
            }
            return res;
        }

        public static List<Invoice> Filter(string str_MinCreationDateTime, string str_MaxCreationDateTime)
        {
            List<Invoice> queryInvoices = ReadData();

            if (str_MinCreationDateTime != null)
            {
                DateTime minCreationDateTime;
                if (DateTime.TryParseExact(str_MinCreationDateTime, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out minCreationDateTime))
                {
                    queryInvoices = queryInvoices.Where(i => i.CreationDateTime >= minCreationDateTime).ToList();
                }
            }

            if (str_MaxCreationDateTime != null)
            {
                DateTime maxCreationDateTime;
                if (DateTime.TryParseExact(str_MaxCreationDateTime, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out maxCreationDateTime))
                {
                    queryInvoices = queryInvoices.Where(i => i.CreationDateTime <= maxCreationDateTime).ToList();
                }
            }

            return queryInvoices;
        }

        public static bool CanDelete(int invoiceID)
        {
            var invoice = FindByID(invoiceID);
            foreach(var record in invoice.ProductRecords)
            {
                if(!ProductRecordBL.CanDeleteInInvoice(invoiceID, record.ID))
                {
                    return false;
                }    
            }    
            return true;
        }
    }
}

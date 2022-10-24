using Newtonsoft.Json;
using StoreManagement.BAL;
using StoreManagement.Entities;

namespace StoreManagement.DAL
{
    public class InvoiceDA
    {
        private static readonly string _dataFilePath = $@"{Global.DATA_DIRECTORY}/Invoices.json";
        public static List<Invoice> ReadData()
        {
            var res = new List<Invoice>();
            string jsonData = String.Empty;

            if (File.Exists(_dataFilePath))
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    jsonData = sr.ReadLine();
                }
                res = JsonConvert.DeserializeObject<List<Invoice>>(jsonData);
            }

            return res;
        }

        public static bool SaveData(List<Invoice> invoices)
        {

            string jsonData = JsonConvert.SerializeObject(invoices);
            if (!Directory.Exists(Global.DATA_DIRECTORY))
            {
                Directory.CreateDirectory(Global.DATA_DIRECTORY);
            }
            using (StreamWriter sw = new StreamWriter(_dataFilePath, false))
            {
                sw.WriteLine(jsonData);
            }
            return true;
        }

        public static bool Add(Invoice invoice)
        {

            var invoices = ReadData();
            int maxID = 0;
            if (invoices.Any())
            {
                maxID = invoices.Max(p => p.ID);
            }
            invoice.ID = maxID + 1;
            invoices.Add(invoice);
            SaveData(invoices);

            return true;
        }

        public static bool Edit(Invoice invoice)
        {
            var invoices = ReadData();
            var index = invoices.FindIndex(c => c.ID == invoice.ID);
            if (index == -1)
            {
                return false;
            }
            invoices[index] = invoice;
            SaveData(invoices);
            return true;
        }

        public static bool RemoveAtID(int id)
        {
            var invoices = ReadData();
            var index = invoices.FindIndex(c => c.ID == id);
            invoices.RemoveAt(index);
            SaveData(invoices);
            return true;
        }
    }
}

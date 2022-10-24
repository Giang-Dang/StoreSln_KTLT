using Newtonsoft.Json;
using StoreManagement.Entities;

namespace StoreManagement.DAL
{
    public class ReceiptDA
    {
        private static readonly string _dataFilePath = $@"{Global.DATA_DIRECTORY}/Receipts.json";
        public static List<Receipt> ReadData()
        {
            var res = new List<Receipt>();
            string jsonData = String.Empty;

            if (File.Exists(_dataFilePath))
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    jsonData = sr.ReadLine();
                }
                res = JsonConvert.DeserializeObject<List<Receipt>>(jsonData);
            }

            return res;
        }

        public static bool SaveData(List<Receipt> receipts)
        {

            string jsonData = JsonConvert.SerializeObject(receipts);
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

        public static bool Add(Receipt receipt)
        {

            var receipts = ReadData();
            int maxID = 0;
            if (receipts.Any())
            {
                maxID = receipts.Max(p => p.ID);
            }
            receipt.ID = maxID + 1;
            receipts.Add(receipt);
            SaveData(receipts);

            return true;
        }

        public static bool Edit(Receipt receipt)
        {
            var receipts = ReadData();
            var index = receipts.FindIndex(c => c.ID == receipt.ID);
            if (index == -1)
            {
                return false;
            }
            receipts[index] = receipt;
            SaveData(receipts);
            return true;
        }

        public static bool RemoveAtID(int id)
        {
            var receipts = ReadData();
            var index = receipts.FindIndex(c => c.ID == id);
            receipts.RemoveAt(index);
            SaveData(receipts);
            return true;
        }
    }
}

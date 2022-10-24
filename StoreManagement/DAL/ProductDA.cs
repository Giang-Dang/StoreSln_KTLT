using Newtonsoft.Json;
using StoreManagement.BAL;
using StoreManagement.Entities;


namespace StoreManagement.DAL
{
    public class ProductDA
    {
        private static readonly string _dataFilePath = $@"{Global.DATA_DIRECTORY}/Products.json";

        public static bool Add(Product product)
        {
            try
            {
                var products = ReadData();
                int maxID = 0;
                if (products.Any())
                {
                    maxID = products.Max(p => p.ID);
                }       
                product.ID = maxID + 1;
                products.Add(product);
                SaveData(products);
            }
            catch (Exception)
            {
                throw;
            }
            
            return true;
        }

        public static void SaveData(List<Product> products)
        {
            string jsonData = JsonConvert.SerializeObject(products);
            if (!Directory.Exists(Global.DATA_DIRECTORY))
            {
                Directory.CreateDirectory(Global.DATA_DIRECTORY);
            }
            using (StreamWriter sw = new StreamWriter(_dataFilePath, false))
            {
                sw.WriteLine(jsonData);
            }
        }

        public static List<Product> ReadData()
        {
            var res = new List<Product>();
            string jsonData = String.Empty;

            if(File.Exists(_dataFilePath))
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    jsonData = sr.ReadLine();
                }
                res = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            }    
            
            return res;
        }


        public static bool Remove(Product product)
        {
            var products = ReadData();
            products.Remove(product);
            SaveData(products);
            return true;
        }

        public static bool Edit(Product product)
        {
            var products = ReadData();
            var index = products.FindIndex(c => c.ID == product.ID);
            if (index == -1)
            {
                return false;
            }
            products[index] = product;
            SaveData(products);
            return true;
        }
    }
}

using Newtonsoft.Json;
using StoreManagement.BAL;
using StoreManagement.Entities;


namespace StoreManagement.DAL
{
    public class ProductDA
    {
        private static readonly string _dataFilePath = $@"{Global.DATA_DIRECTORY}/Products.json";

        public static void Add(Product product)
        {
            var products = ReadData();
            int maxID = 0;
            foreach (var p in products)
            {
                maxID = maxID > p.ID ? maxID : p.ID;
            }
            product.ID = maxID;
            products.Add(product);
            SaveData(products);
        }

        public static void SaveData(List<Product> products)
        {
            string jsonData = JsonConvert.SerializeObject(products, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(_dataFilePath))
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

        public static bool AnyProductInCategory(Category category)
        {
            var products = ReadData();
            return products.Any(p => p.Category.Equals(category));
        }
    }
}

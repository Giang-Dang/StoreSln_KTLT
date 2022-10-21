using Newtonsoft.Json;
using StoreManagement.Entities;


namespace StoreManagement.DAL
{
    public class ProductDA
    {
        public static bool SaveProduct(Product product)
        {
            string filePath = $@"{Global.DATA_DIRECTORY}/Product.json";
            string json = JsonConvert.SerializeObject(product);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(json);
            }

            return true;
        }
    }
}

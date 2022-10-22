using Newtonsoft.Json;
using StoreManagement.BAL;
using StoreManagement.Entities;

namespace StoreManagement.DAL
{
    public class CategoryDA
    {
        private static readonly string _dataFilePath = $@"{Global.DATA_DIRECTORY}/Categories.json";
   
        public static void Add(Category category)
        {
            var categories = ReadData();
            int maxID = 1;
            foreach (var c in categories)
            {
                maxID = maxID > c.ID ? maxID : c.ID;
            }
            category.ID = maxID + 1;
            categories.Add(category);
            SaveData(categories);
        }

        public static void SaveData(List<Category> categories)
        {
            string jsonData = JsonConvert.SerializeObject(categories);

            if(!Directory.Exists(Global.DATA_DIRECTORY))
            {
                Directory.CreateDirectory(Global.DATA_DIRECTORY);
            }    
            using (StreamWriter sw = new StreamWriter(_dataFilePath, false))
            { 
                sw.WriteLine(jsonData);
            }

        }

        public static List<Category> ReadData()
        {
            var res = new List<Category>();
            string jsonData = String.Empty;

            if (File.Exists(_dataFilePath))
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    jsonData = sr.ReadLine();
                }
                res = JsonConvert.DeserializeObject<List<Category>>(jsonData);
            }                

            return res;
        }

        public static Category FindByID(int id)
        {
            var categories = ReadData();
            return categories.First(c => c.ID == id);
        }
        public static List<Category> FindByName(string name)
        {
            var categories = ReadData();
            return categories.Where(c => c.Name.Contains(name)).ToList();
        }
        
        public static bool Edit(Category category)
        {
            var categories = ReadData();
            var index = categories.FindIndex(c => c.ID == category.ID);
            if (index == -1)
            {
                return false;
            }
            categories[index] = category;
            SaveData(categories);
            return true;
        }

        public static bool Delete(Category category)
        {
            var categories = ReadData();
            categories.Remove(category);
            SaveData(categories);
            return true;
        }
    }
}

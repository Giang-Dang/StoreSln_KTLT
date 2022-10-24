using StoreManagement.DAL;
using StoreManagement.Entities;

namespace StoreManagement.BAL
{
    public class CategoryBL
    {
        public static List<Category> ReadData()
        {
            return CategoryDA.ReadData();
        }

        public static void Add(int id, string name)
        {
            Category category = new Category(id, name);
            CategoryDA.Add(category);
        }

        public static Category FindByID(int id)
        {
            var categories = ReadData();
            return categories.First(c => c.ID == id);
        }
        public static Category FindByName(string name)
        {
            var categories = ReadData();
            return categories.First(c => c.Name == name);
        }
        public static List<Category> FindByStringInName(string sname)
        {
            var categories = ReadData();
            return categories.Where(c => c.Name.Contains(sname ?? "")).ToList();
        }

        public static bool Edit(Category category)
        {
            return CategoryDA.Edit(category);
        }

        public static bool Delete(Category category)
        {
            return CategoryDA.Delete(category);
        }

        public static bool IsInputValidAndReturnNoti(string name, out string[] notifications)
        {
            var res = true;
            notifications = new string[1];
            
            if(name == null)
            {
                notifications[0] = "Tên loại hàng không được để trống.";
                res = false;
            }

            return res;
        }
    }
}

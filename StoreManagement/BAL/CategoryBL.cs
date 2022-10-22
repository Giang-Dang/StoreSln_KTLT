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
            return CategoryDA.FindByID(id);
        }

        public static List<Category> FindByName(string name)
        {
            return CategoryDA.FindByName(name);
        }

        public static bool Edit(Category category)
        {
            return CategoryDA.Edit(category);
        }

        public static string Delete(Category category)
        {
            if(ProductDA.AnyProductInCategory(category))
            {
                return "Xóa thất bại. Do có mặt hàng thuộc loại hàng này.";
            }
            if(CategoryDA.Delete(category))
            {
                return "Xóa loại hàng thành công.";
            }
            return "Xóa thất bại. Không rõ lỗi";
        }
    }
}

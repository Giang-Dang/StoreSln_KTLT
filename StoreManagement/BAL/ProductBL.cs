using System.Xml.Linq;
using StoreManagement.Entities;
using StoreManagement.DAL;
using System.Globalization;

namespace StoreManagement.BAL
{
    public class ProductBL
    {
        

        public static Product FindByID(int id)
        {
            var products = ReadData();
            return products.FirstOrDefault(p => p.ID == id);
        }
        public static bool AnyProductInCategory(Category category)
        {
            var products = ReadData();
            return products.Any(p => p.Category.Equals(category));
        }
        public static List<Product> ReadData()
        {
            return ProductDA.ReadData();
        }

        public static bool Add(Product product)
        {
            return ProductDA.Add(product);
        }
        public static string Delete(Product product)
        {
            if (ProductDA.Delete(product))
            {
                return "Xóa loại hàng thành công.";
            }
            return "Xóa thất bại. Không rõ lỗi";
        }

        public static bool Edit(Product product)
        {
            return ProductDA.Edit(product);
        }

        public static List<Product> Filter(
            string name,
            string str_CategoryID, 
            string manufacturer, 
            string str_MinExpiryDate, 
            string str_MaxExpiryDate, 
            string str_MinManufacturingDate, 
            string str_MaxManufacturingDate, 
            string str_MinPrice, 
            string str_MaxPrice)
        {
            var queryProducts = ReadData();

            if (name != null)
            {
                queryProducts = queryProducts.Where(p => p.Name.Contains(name)).ToList();
            }    

            if (str_CategoryID != null)
            {
                int categoryID = -1;
                if(Int32.TryParse(str_CategoryID, out categoryID))
                {
                    queryProducts = queryProducts.Where(p => p.Category.ID == categoryID).ToList();
                }    
            }

            if (manufacturer != null)
            {
                queryProducts = queryProducts.Where(p => p.Manufacturer.Contains(manufacturer)).ToList();
            }

            if (str_MinExpiryDate != null)
            {
                DateTime minExpiryDate;
                if (DateTime.TryParseExact(str_MinExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out minExpiryDate))
                {
                    queryProducts = queryProducts.Where(p => p.ExpiryDate >= minExpiryDate).ToList();
                }
            }

            if (str_MaxExpiryDate != null)
            {
                DateTime maxExpiryDate;
                if (DateTime.TryParseExact(str_MaxExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out maxExpiryDate))
                {
                    queryProducts = queryProducts.Where(p => p.ExpiryDate <= maxExpiryDate).ToList();
                }
            }

            if (str_MinManufacturingDate != null)
            {
                DateTime minManufacturingDate;
                if (DateTime.TryParseExact(str_MinManufacturingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out minManufacturingDate))
                {
                    queryProducts = queryProducts.Where(p => p.ManufacturingDate >= minManufacturingDate).ToList();
                }
            }

            if (str_MaxManufacturingDate != null)
            {
                DateTime maxManufacturingDate;
                if (DateTime.TryParseExact(str_MaxManufacturingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out maxManufacturingDate))
                {
                    queryProducts = queryProducts.Where(p => p.ManufacturingDate <= maxManufacturingDate).ToList();
                }
            }

            if (str_MinPrice != null)
            {
                decimal minPrice;
                if (Decimal.TryParse(str_MinPrice, out minPrice))
                {
                    queryProducts = queryProducts.Where(p => p.Price >= minPrice).ToList();
                }    
            }

            if (str_MaxPrice != null)
            {
                decimal maxPrice;
                if (Decimal.TryParse(str_MaxPrice, out maxPrice))
                {
                    queryProducts = queryProducts.Where(p => p.Price <= maxPrice).ToList();
                }
            }

            return queryProducts;
        }
    }
}

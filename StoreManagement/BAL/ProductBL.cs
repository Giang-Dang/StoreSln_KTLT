using System.Xml.Linq;
using StoreManagement.Entities;
using StoreManagement.DAL;

namespace StoreManagement.BAL
{
    public class ProductBL
    {
        public static List<Product> ReadData()
        {
            return ProductDA.ReadData();
        }

    }
}

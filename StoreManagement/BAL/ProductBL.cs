using System.Xml.Linq;
using StoreManagement.Entities;
using StoreManagement.DAL;

namespace StoreManagement.BAL
{
    public class ProductBL
    {
        public static string AddProduct(Product product)
        {
            if(product.Price < 0)
            {
                return "Giá không được nhỏ hơn 0.";
            }

            if(product.ExpiryDate <= product.ManufacturingDate)
            {
                return "Hạn sử dụng phải sau ngày sản xuất.";
            }
            
            if(!ProductDA.SaveProduct(product))
            {
                return "Lỗi lưu tập tin. Lưu sản phẩm thất bại.";
            }
            
            return "Lưu sản phẩm thành công";
        }
    }
}

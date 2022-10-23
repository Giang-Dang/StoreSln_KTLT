namespace StoreManagement.Entities
{
    public struct ProductRecord
    {
        public int ID;
        public Product Product;
        public int ProductCount;
        public ProductRecord(int id, Product product, int productCount)
        {
            ID = id;
            Product = product;
            ProductCount = productCount;  
        }
    }
}

namespace StoreManagement.Entities
{
    public struct ProductRecord
    {
        public int ID;
        public int ProductID;
        public int ProductCount;
        public ProductRecord(int id, int productID, int productCount)
        {
            ID = id;
            ProductID = productID;
            ProductCount = productCount;  
        }
    }
}

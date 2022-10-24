namespace StoreManagement.Entities
{
    public struct Product
    {
        public int ID;
        public string Name;
        public int CategoryID;
        public decimal Price;
        public DateTime ExpiryDate;
        public DateTime ManufacturingDate;
        public string Manufacturer;
        
        public Product(
            int id, 
            string name,
            decimal price,
            int categoryID,
            DateTime expiryDate,
            DateTime manufacturingDate,
            string manufacturer
            )
        {
            ID = id;
            Name = name;
            ExpiryDate = expiryDate;
            Price = price;
            ManufacturingDate = manufacturingDate;
            Manufacturer = manufacturer;
            CategoryID = categoryID;
        }
    }
}

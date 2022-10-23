namespace StoreManagement.Entities
{
    public struct Product
    {
        public int ID;
        public string Name;
        public Category Category;
        public decimal Price;
        public DateTime ExpiryDate;
        public DateTime ManufacturingDate;
        public string Manufacturer;
        
        public Product(
            int id, 
            string name,
            decimal price,
            Category category,
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
            Category = category;
        }
    }
}

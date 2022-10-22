namespace StoreManagement.Entities
{
    public struct Product
    {
        public int ID;
        public string Name;
        public DateOnly ExpiryDate;
        public DateOnly ManufacturingDate;
        public string Manufacturer;
        public decimal Price;
        public Category Category;
    }
}

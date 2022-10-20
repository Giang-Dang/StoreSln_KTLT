namespace StoreManagement.Entities
{
    public struct Product
    {
        public string ID;
        public string Name;
        public DateOnly ExpiryDate;
        public DateOnly ManufacturingDate;
        public string Manufacturer;
        public string Price;
        public Category Category;
    }
}

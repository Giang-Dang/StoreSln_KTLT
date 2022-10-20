namespace StoreManagement.Entities
{
    public struct Invoice
    {
        public string ID;
        public DateTime CreationDateTime;
        public List<ProductRecord> ProductRecords;
    }
}

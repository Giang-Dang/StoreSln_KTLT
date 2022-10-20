namespace StoreManagement.Entities
{
    public struct Receipt
    {
        public string ID;
        public DateTime CreationDateTime;
        public List<ProductRecord> ProductRecords;
    }
}

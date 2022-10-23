namespace StoreManagement.Entities
{
    public struct Invoice
    {
        public int ID;
        public DateTime CreationDateTime;
        public List<ProductRecord> ProductRecords;

        public Invoice(int id, DateTime creationDateTime)
        {
            ID = id;
            CreationDateTime = creationDateTime;
            ProductRecords = new List<ProductRecord>();
        }

        public Invoice(int id, DateTime creationDateTime, List<ProductRecord> productRecords)
        {
            ID = id;
            CreationDateTime = creationDateTime;
            ProductRecords = productRecords;
        }
    }
}

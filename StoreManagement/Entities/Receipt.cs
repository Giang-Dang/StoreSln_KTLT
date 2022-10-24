namespace StoreManagement.Entities
{
    public struct Receipt
    {
        public int ID;
        public DateTime CreationDateTime;
        public List<ProductRecord> ProductRecords;

        public Receipt(int id, DateTime creationDateTime)
        {
            ID = id;
            CreationDateTime = creationDateTime;
            ProductRecords = new List<ProductRecord>();
        }

        public Receipt(int id, DateTime creationDateTime, List<ProductRecord> productRecords)
        {
            ID = id;
            CreationDateTime = creationDateTime;
            ProductRecords = productRecords;
        }
    }
}

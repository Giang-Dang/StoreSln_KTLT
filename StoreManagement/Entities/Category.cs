namespace StoreManagement.Entities
{
    public struct Category
    {
        public int ID;
        public string Name;
        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

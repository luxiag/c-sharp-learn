namespace EFCore_SQLServer
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public DateTime PublicTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}

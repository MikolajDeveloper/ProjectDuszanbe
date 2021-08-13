namespace ProjectDuszanbe.Domain.Model
{
    public class Translation
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public Word Word { get; set; }
        public string Name { get; set; }
    }
}
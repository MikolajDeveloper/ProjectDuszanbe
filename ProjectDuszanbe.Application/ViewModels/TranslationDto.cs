using ProjectDuszanbe.Domain.Model;

namespace ProjectDuszanbe.Application.ViewModels
{
    public class TranslationDto
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public Word Word { get; set; }
        public string Name { get; set; }
    }
}
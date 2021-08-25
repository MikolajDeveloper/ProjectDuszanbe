using System.ComponentModel.DataAnnotations;

namespace ProjectDuszanbe.Domain.Model
{
    public class Translation
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Language Language { get; set; }
        public Word Word { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
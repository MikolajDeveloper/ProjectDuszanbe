using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDuszanbe.Domain.Model
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public List<Translation> Translations { get; set; }
    }
}
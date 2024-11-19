using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Method_Library.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Languages Languages { get; set; }
    }
}

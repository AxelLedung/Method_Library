using System.ComponentModel.DataAnnotations;

namespace Method_Library.Models
{
    public class Languages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name {  get; set; }

    }
}

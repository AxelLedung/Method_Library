using Method_Library.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Method_Library.ViewModels
{
    public class SnippetsViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code snippet is required.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "You must select a category.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid category selected.")]
        public int SelectedCategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
        [ValidateNever]
        public Languages Language {  get; set; }
    }
}

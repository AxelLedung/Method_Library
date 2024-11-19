using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Method_Library.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must select a language.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid language selected.")]
        public int SelectedLanguageId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}

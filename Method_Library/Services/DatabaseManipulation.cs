using Method_Library.Data;
using Method_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Method_Library.Services
{
    public class DatabaseManipulation
    {
        private readonly AppDbContext _context;

        public DatabaseManipulation(AppDbContext context)
        {
            _context = context;
        }
        public virtual Languages GetSnippetLanguage(Snippets snippet)
        {

            // Ensure snippet is attached to context and include related data
            var snippetWithCategory = _context.Snippets
                .Include(s => s.Categories) // Include the Category
                .ThenInclude(c => c.Languages) // Include the Language from the Category
                .FirstOrDefault(s => s.Id == snippet.Id);

            if (snippetWithCategory?.Categories?.Languages != null)
            {
                return snippetWithCategory.Categories.Languages; // Return the associated Language
            }

            return null; // Return null if no language is found
        }
    }
}

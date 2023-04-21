using GuestBook.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuestBook.Pages;

public class IndexModel : PageModel
{
    private GuestBookContext _db;
    [BindProperty]
    public Review? Review { get; set; }
    public IEnumerable<Review>? Reviews { get; set; }
    
    public IndexModel(GuestBookContext injectedContext)
    {
        _db = injectedContext;
    }

    public void OnGet()
    {
        Reviews = _db.Reviews.OrderByDescending(r => r.DateOfCreation);
    }
    
    public IActionResult OnPost()
    {
        if ((Review is not null) && ModelState.IsValid)
        {
            var review = new Review()
            {
                UserName = Review.UserName,
                Message = Review.Message,
                DateOfCreation = DateTime.Now
            };
            
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToPage("/index");
        }
        else
        {
            return Page();
        }
    }
}
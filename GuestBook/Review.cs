using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook;

public partial class Review
{
    [Key]
    public int ReviewId { get; set; }
    
    [Required]
    [StringLength(40)]
    public string UserName { get; set; } = null!;

    public string? Message { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfCreation { get; set; }
}

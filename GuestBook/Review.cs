using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook;

[Table("reviews")]
public partial class Review
{
    [Key]
    [Column("reviewId")]
    public long ReviewId { get; set; }
    
    [Required]
    [StringLength(40)]
    [Column("userName", TypeName = "varchar(40)")]
    public string? UserName { get; set; }

    [Column("message")]
    public string Message { get; set; } = null!;

    [Column("dateOfCreation", TypeName = "DATETIME")]
    public DateTime DateOfCreation { get; set; }
}

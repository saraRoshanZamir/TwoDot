using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    // [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Gender { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    public string LookingFor { get; set; }
    
    [MaxLength(180)]
    public string Bio { get; set; }
    
    [Required]
    public string Profile_Picture { get; set; }
    
    public bool IsDeleted { get; set; }
    
}
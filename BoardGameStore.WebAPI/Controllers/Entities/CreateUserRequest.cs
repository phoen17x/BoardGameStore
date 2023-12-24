using System.ComponentModel.DataAnnotations;

namespace BoardGameStore.WebAPI.Controllers.Entities;

public class CreateUserRequest
{
    [Required]
    [MinLength(2)]
    public string Username { get; set; }
    
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(2)]
    public string LastName { get; set; }
    
    [Required]
    [MinLength(8)]
    public string PasswordHash { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [Phone]
    public string Phone { get; set; }
}
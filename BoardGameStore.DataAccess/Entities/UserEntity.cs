using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    public virtual ICollection<CartItemEntity> CartItems { get; set; }
    public virtual ICollection<OrderEntity> Orders { get; set; }
}
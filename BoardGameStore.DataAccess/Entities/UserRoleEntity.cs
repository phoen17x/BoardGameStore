using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("user_role")]
public class UserRoleEntity
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual RoleEntity Role { get; set; }
}
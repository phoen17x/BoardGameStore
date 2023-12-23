using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("roles")]
public class RoleEntity : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
}
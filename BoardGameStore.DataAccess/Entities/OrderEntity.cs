using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("orders")]
public class OrderEntity : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual ICollection<OrderItemEntity> OrderItems { get; set; }
}
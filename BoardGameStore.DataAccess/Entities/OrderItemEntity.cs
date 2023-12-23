using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("order_items")]
public class OrderItemEntity : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int GameId { get; set; }
    public int OrderId { get; set; }
    
    public virtual BoardGameEntity BoardGame { get; set; }
    public virtual OrderEntity Order { get; set; }
}
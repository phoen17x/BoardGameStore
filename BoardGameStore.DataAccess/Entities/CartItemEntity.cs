using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("cart_items")]
public class CartItemEntity : BaseEntity
{
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    
    public virtual UserEntity User { get; set; }
    public virtual BoardGameEntity BoardGame { get; set; }
}
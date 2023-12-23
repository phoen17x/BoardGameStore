using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("store_info")]
public class StoreInfoEntity : BaseEntity
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}
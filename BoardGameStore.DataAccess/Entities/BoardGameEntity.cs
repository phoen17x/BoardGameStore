using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("board_games")]
public class BoardGameEntity : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int AgeLimit { get; set; }
    public int PlayersMin { get; set; }
    public int PlayersMax { get; set; }
    
    public virtual ICollection<GameGenreEntity> GameGenres { get; set; }
}
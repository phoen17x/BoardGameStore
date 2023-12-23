using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("game_genre")]
public class GameGenreEntity
{
    public int GameId { get; set; }
    public int GenreId { get; set; }
    public virtual BoardGameEntity BoardGame { get; set; }
    public virtual GenreEntity Genre { get; set; }
}
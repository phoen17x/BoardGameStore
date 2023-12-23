using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameStore.DataAccess.Entities;

[Table("genres")]
public class GenreEntity : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<GameGenreEntity> GameGenres { get; set; }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GSF0DD_HFT_2022231.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Publisher Publisher { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        public override bool Equals(object obj)
        {
            Game game = obj as Game;

            if (game is null)
            {
                return false;
            }
            else
            {
                return game.GameId == this.GameId && game.Name == this.Name && game.ReleaseDate == this.ReleaseDate;
            }
        }
    }
}

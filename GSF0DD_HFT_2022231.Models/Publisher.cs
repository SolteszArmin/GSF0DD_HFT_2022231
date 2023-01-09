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
    [Table("Publishers")]
    public class Publisher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }

        public Publisher()
        {
            this.Games = new HashSet<Game>();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

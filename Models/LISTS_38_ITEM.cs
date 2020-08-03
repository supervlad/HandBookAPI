using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swagger.Models
{
    public class LISTS_38_ITEM
    {
        [Required]
        [ForeignKey("LISTS_38_CATALOG")]
        public int LIST_ID { get; set; }

        [Key]
        [Required]
        [MaxLength(500)]
        public string ITEM_KEY { get; set; }

        [Required]
        [MaxLength(500)]
        public string ITEM_VALUE { get; set; }

        public LISTS_38_CATALOG LISTS_38_CATALOG { get; set; }
    }
}

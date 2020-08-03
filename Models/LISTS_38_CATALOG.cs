using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Swagger.Models
{
    public class LISTS_38_CATALOG
    {
        [Key]
        [Required]
        public int LIST_ID { get; set; }

        [Required]
        public int TASK_ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string LIST_NAME { get; set; }

        [Required]
        [MaxLength(200)]
        public string LIST_DESCRIPTION { get; set; }

        public List<LISTS_38_ITEM> LISTS_38_ITEMS { get; set; }
    }
}

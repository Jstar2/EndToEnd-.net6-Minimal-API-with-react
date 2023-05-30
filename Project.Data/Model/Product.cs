using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Required]
        [Column("Products_names")]
        public string ProductName { get; set; }

        [Required]
        [Column("Products_design")]
        public string ProductDescription { get; set; }
    }
}

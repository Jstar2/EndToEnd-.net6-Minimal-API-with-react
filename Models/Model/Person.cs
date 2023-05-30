using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("FirstName")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(18, int.MaxValue)]
        [Column("Age")]
        public int Age { get; set; }

        [Required]
        [Column("Tile")]
        public string Title { get; set; }

        [Required]
        [Column("Gender")]
        public string Gender { get; set; }

        [Required]
        [Column("FirstLineOfAddress")]
        public string FistLineOfAddress { get; set; }

        [Required]
        [Column("City")]
        public string City { get; set; }

        [Required]
        [Column("PostCode")]
        public string PostCode { get; set; }

        [Required]
        [Column("Country")]
        public string Country { get; set; }

        [Required]
        [Column("Phone")]
        public string Phone { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }
    }
}

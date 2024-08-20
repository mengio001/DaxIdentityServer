using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizTower.IDP.Entities
{
    [Table("AspNetUserClaims", Schema = "Identity")]
    public class AspNetUserClaim : IConcurrencyAware
    {
        [ConcurrencyCheck]
        [Column("ConcurrencyStamp", Order = 0)]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Type { get; set; }

        [MaxLength(250)]
        [Required]
        public string Value { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Claims")]
        public AspNetUser? AspNetUser { get; set; }
    }
}

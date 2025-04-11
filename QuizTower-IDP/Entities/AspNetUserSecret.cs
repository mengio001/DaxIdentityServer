using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizTower.IDP.Entities
{
    [Table("AspNetUserSecrets", Schema = "Identity")]
    public class AspNetUserSecret : IConcurrencyAware
    {
        [ConcurrencyCheck]
        [Column("ConcurrencyStamp", Order = 0)]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Secrets")]
        public AspNetUser? AspNetUser { get; set; }
    }
}

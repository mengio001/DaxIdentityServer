using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizTower.IDP.Entities
{
    [Table("AspNetUserLogins", Schema = "Identity")]
    public class AspNetUserLogin : IConcurrencyAware
    {
        [ConcurrencyCheck]
        [Column("ConcurrencyStamp", Order = 0)]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Provider { get; set; }

        [MaxLength(200)]
        [Required]
        public string ProviderIdentityKey { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logins")]
        public AspNetUser? AspNetUser { get; set; }
    }
}

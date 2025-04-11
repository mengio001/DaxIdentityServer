using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizTower.IDP.Entities
{
    [Table("AspNetUsers", Schema = "Identity")]
    public class AspNetUser : IConcurrencyAware
    {
        [ConcurrencyCheck]
        [Column("ConcurrencyStamp", Order = 0)]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string? UserName { get; set; }

        [MaxLength(200)]
        public string? Password { get; set; }

        [Required]
        public bool Active { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? SecurityCode { get; set; }

        public DateTime SecurityCodeExpirationDate { get; set; }

        [InverseProperty("AspNetUser")]
        public ICollection<AspNetUserClaim> Claims { get; set; } = new List<AspNetUserClaim>();
        [InverseProperty("AspNetUser")]
        public ICollection<AspNetUserLogin> Logins { get; set; } = new List<AspNetUserLogin>();
        [InverseProperty("AspNetUser")]
        public ICollection<AspNetUserSecret> Secrets { get; set; } = new List<AspNetUserSecret>();
    }
}

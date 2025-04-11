using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizTower.IDP.Entities
{
    public interface IConcurrencyAware
    {
        [ConcurrencyCheck]
        [Column("ConcurrencyStamp", Order = 0)]
        string ConcurrencyStamp { get; set; }
    }
}

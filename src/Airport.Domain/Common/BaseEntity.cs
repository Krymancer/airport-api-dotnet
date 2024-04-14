using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airport.Domain.Common;

public class BaseEntity: IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = new Guid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt  { get; set; }
}
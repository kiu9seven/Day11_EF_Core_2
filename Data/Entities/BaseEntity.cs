using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day11.Data.Entities;

public class BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}
    public DateTime? CreatedTime { get; set; }
    public DateTime? Creator { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public string? Modifier { get; set; }

}
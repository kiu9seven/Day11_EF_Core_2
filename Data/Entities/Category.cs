using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace  Day11.Data.Entities;

// [Table("Category")]

public class Category:BaseEntity
{

    [Required, MaxLength(50)]
    public string? Name {get;set;}

    public ICollection<Product>? Products {get;set;}
    

}
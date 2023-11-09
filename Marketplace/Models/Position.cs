using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Models
{
    [Table("Position")]
    public class Position
    {
     public int Id { get; set; }
    [Required]
    [MaxLength(50)]
     public string Name { get; set; }
    public int CategoryId { get; set; } 
    public Category Category { get; set; }
    }

}

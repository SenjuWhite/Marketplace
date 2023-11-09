using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}

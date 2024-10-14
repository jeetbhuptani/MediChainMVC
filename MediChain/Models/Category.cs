using System.ComponentModel.DataAnnotations;

namespace MediChain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }
    }
}

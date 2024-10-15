using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MediChain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(40)]
        public string CategoryName { get; set; }
        [DisplayName("Display Order")]
        [Range(1,50)]
        public int DisplayOrder { get; set; }
    }
}

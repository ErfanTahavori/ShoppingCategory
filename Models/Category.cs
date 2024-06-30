using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Shopping_Project.Models
{
    public class Category
    {
      
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        //[AllowedValues(typeof(string))]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        //[AllowedValues(typeof(int))]
        public int DisplayOrder { get; set; }
    }
}

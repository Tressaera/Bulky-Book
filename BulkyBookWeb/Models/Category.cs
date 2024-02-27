using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage = "Görüntüleme sırası yalnızca 1 ile 100 arasında olmalıdır")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; }=DateTime.Now;
    }
}

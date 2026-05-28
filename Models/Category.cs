using System.ComponentModel.DataAnnotations;

namespace BookDB.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên chủ đề không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên chủ đề")]
        public string CategoryName { get; set; } = "";

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

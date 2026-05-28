using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookDB.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [StringLength(200)]
        [Display(Name = "Tên sách")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [StringLength(150)]
        [Display(Name = "Tác giả")]
        public string Author { get; set; } = "";

        [Required(ErrorMessage = "Giá bán không được để trống")]
        [Range(0, 999999999, ErrorMessage = "Giá phải lớn hơn 0")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn chủ đề")]
        [Display(Name = "Chủ đề")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}

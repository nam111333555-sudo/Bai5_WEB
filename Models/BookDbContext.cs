using Microsoft.EntityFrameworkCore;

namespace BookDB.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Cuộc sống" },
                new Category { CategoryId = 2, CategoryName = "Lập trình" },
                new Category { CategoryId = 3, CategoryName = "Sức khỏe" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Cuộc Sống Rất Giống Cuộc Đời",
                    Author = "Hải Dờ",
                    Price = 61000,
                    Description = "Đàn ông tuổi 15 mo ước thành đàn ông tuổi 20, đàn ông tuổi 20 mo ước thành đàn ông tuổi 30, đàn ông tuổi 30 mo ước được trở thành đàn ông tuổi 40 và đàn ông tuổi 40 lại mo ước đặt chân lên cỗ máy thời gian để quay lại tuổi 30 với toàn bộ tài sản của mình. Vậy đấy!",
                    Image = "cuocsong.svg",
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Lập Trình Không Khó",
                    Author = "Lê Xuân Viết",
                    Price = 85000,
                    Description = "Hướng dẫn lập trình từ cơ bản đến nâng cao cho người mới bắt đầu.",
                    Image = "laptrinh.svg",
                    CategoryId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Core Java Fundamentals, Volume 1",
                    Author = "Cay Horstmann",
                    Price = 120000,
                    Description = "Sách học Java nền tảng dành cho lập trình viên chuyên nghiệp.",
                    Image = "java.svg",
                    CategoryId = 2
                },
                new Book
                {
                    Id = 4,
                    Title = "Sống Đúng Nghĩa",
                    Author = "Nguyễn An",
                    Price = 55000,
                    Description = "Những câu chuyện truyền cảm hứng về cuộc sống ý nghĩa.",
                    Image = "songdungnghia.svg",
                    CategoryId = 1
                }
            );
        }
    }
}

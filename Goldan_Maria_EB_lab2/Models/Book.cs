using System.ComponentModel.DataAnnotations.Schema;

namespace Goldan_Maria_EB_lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public Author? Author { get; set; }

		[Column(TypeName = "decimal(6, 2)")]
		public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
		public ICollection<PublishedBook> PublishedBooks { get; set; }
	}
}

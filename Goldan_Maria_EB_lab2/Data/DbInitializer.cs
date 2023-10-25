using Goldan_Maria_EB_lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Goldan_Maria_EB_lab2.Data
{
	public class DbInitializer
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
			{
				if (context.Books.Any())
				{
					return; // BD a fost creata anterior
				}

				Author Author1 = new Author
				{
					FirstName = "Mihail",
					LastName = "Sadoveanu"
				};

				Author Author2 = new Author
				{
					FirstName = "George",
					LastName = "Calinescu"
				};

				Author Author3 = new Author
				{
					FirstName = "Mircea",
					LastName = "Eliade"
				};
				context.Authors.AddRange(Author1, Author2, Author3);
				context.SaveChanges();

				context.Books.AddRange(
				new Book
				{
					Title = "Baltagul",
					Author = Author1,
					Price = Decimal.Parse("22")
				},

				new Book
				{
					Title = "Enigma Otiliei",
					Author = Author2,
					Price = Decimal.Parse("18")
				},

				new Book
				{
					Title = "Maytrei",
					Author = Author3,
					Price = Decimal.Parse("27")
				});
				context.SaveChanges();


				context.Customers.AddRange(
				new Customer
				{
					Name = "Popescu Marcela",
					Adress = "Str. Plopilor, nr. 24",
					BirthDate = DateTime.Parse("1979-09-01")
				},
				new Customer
				{
					Name = "Mihailescu Cornel",
					Adress = "Str. Bucuresti, nr. 45, ap. 2",
					BirthDate = DateTime.Parse("1969 - 07 - 08")
				});
                context.SaveChanges();

                var orders = new Order[]
				{
					new Order{BookID=10,CustomerID=5,OrderDate=DateTime.Parse("2021-02-25")},
					new Order{BookID=12,CustomerID=6,OrderDate=DateTime.Parse("2021-09-28")},
					new Order{BookID=10,CustomerID=6,OrderDate=DateTime.Parse("2021-10-28")},
					new Order{BookID=11,CustomerID=5,OrderDate=DateTime.Parse("2021-09-28")},
					new Order{BookID=11,CustomerID=5,OrderDate=DateTime.Parse("2021-09-28")},
					new Order{BookID=12,CustomerID=5,OrderDate=DateTime.Parse("2021-10-28")},
				};
				foreach (Order e in orders)
				{
					context.Orders.Add(e);
				}
				context.SaveChanges();

				var publishers = new Publisher[]
				{
					new Publisher{PublisherName="Humanitas",Adress="Str. Aviatorilor, nr. 40, Bucuresti"},
					new Publisher{PublisherName="Nemira",Adress="Str. Plopilor, nr. 35, Ploiesti"},
					new Publisher{PublisherName="Paralela 45",Adress="Str. Cascadelor, nr. 22, Cluj-Napoca"},
				};
				foreach (Publisher p in publishers)
				{
					context.Publishers.Add(p);
				}
				context.SaveChanges();

				var books = context.Books;
				var publishedbooks = new PublishedBook[]
				{
					new PublishedBook {
					BookID = books.Single(c => c.Title == "Maytrei" ).ID,
					PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
					},
					new PublishedBook {
					BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,
					PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
					},
					new PublishedBook {
					BookID = books.Single(c => c.Title == "Baltagul" ).ID,
					PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
					}
				};
				foreach (PublishedBook pb in publishedbooks)
				{
					context.PublishedBooks.Add(pb);
				}

				context.SaveChanges();
			}
		}
	}
}
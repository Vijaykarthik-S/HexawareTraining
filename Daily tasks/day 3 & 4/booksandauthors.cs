using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace BooksandAuthors
{
    public class Author
    { 
        public string Name { get; set; }
        public string Country { get; set; }
        public int DOB { get; set; }
    }
    public class books
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int year { get; set; }
        public Author Author { get; set; }  
    }
    class program
    {
        static void Main(string[] args)
        {
            var authors = new List<Author>
            {
                new Author{ Name = "Nolan", Country = "UK", DOB = 1989},
                new Author{ Name = "Scorcese", Country = "US", DOB = 1949},
                new Author{ Name = "Tarantino", Country = "US", DOB = 1969},
                new Author{ Name = "Denis", Country = "Aus", DOB = 1959},
                new Author{ Name = "Russo", Country = "US", DOB = 1979}
            };
            var books = new List<books>
            {
                new books{ Title = "Inception", Genre = "Thriller", year = 2010, Author = authors[0]},
                new books{ Title = "Departed", Genre = "Action", year = 2006, Author = authors[1]},
                new books{ Title = "pulp fiction", Genre = "Thriller", year = 2012, Author = authors[2]},
                new books{ Title = "Dune", Genre = "Sci fi", year = 2021, Author = authors[3]},
                new books{ Title = "End game", Genre = "sci fi", year = 2019, Author = authors[4]},
            };

            string booksjson = JsonSerializer.Serialize(books);
            File.WriteAllText("books.json", booksjson);

            string authorsjson = JsonSerializer.Serialize(authors);
            File.WriteAllText("authors.json", authorsjson);

            XmlSerializer xmlSerializerauthors = new XmlSerializer(typeof(List<Author>));
            using (StreamWriter writer = new StreamWriter("authors.xml"))
            {
                xmlSerializerauthors.Serialize(writer, authors);
            }

            XmlSerializer xmlSerializerbooks = new XmlSerializer(typeof(List<books>));
            using (StreamWriter writer = new StreamWriter("books.json"))
            {
                xmlSerializerbooks.Serialize(writer, books);
            }
            Console.WriteLine("Books from JSON:");
            string jsonBooksData = File.ReadAllText("books.json");
            List<books> jsonBooks = JsonSerializer.Deserialize<List<books>>(jsonBooksData);

            foreach (var book in jsonBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author.Name}, Genre: {book.Genre}, Year: {book.year}");
            }

            // Read and display JSON data for Authors
            Console.WriteLine("\nAuthors from JSON:");
            string jsonAuthorsData = File.ReadAllText("authors.json");
            List<Author> jsonAuthors = JsonSerializer.Deserialize<List<Author>>(jsonAuthorsData);
            foreach (var author in jsonAuthors)
            {
                Console.WriteLine($"{author.Name}, Country: {author.Country}, Birth Year: {author.DOB}");
            }

            // Read and display XML data for Books
            Console.WriteLine("\nBooks from XML:");
            using (StreamReader reader = new StreamReader("books.xml"))
            {
                var xmlBooks = (List<books>)xmlSerializerbooks.Deserialize(reader);
                foreach (var book in xmlBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author.Name}, Genre: {book.Genre}, Year: {book.year}");
                }
            }

            // Read and display XML data for Authors
            Console.WriteLine("\nAuthors from XML:");
            using (StreamReader reader = new StreamReader("authors.xml"))
            {
                var xmlAuthors = (List<Author>)xmlSerializerauthors.Deserialize(reader);
                foreach (var author in xmlAuthors)
                {
                    Console.WriteLine($"{author.Name}, Country: {author.Country}, Birth Year: {author.DOB}");
                }
            }
            Console.ReadLine();
        }
    }
    
}

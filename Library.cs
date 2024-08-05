using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CLMS_Exam_Camp4._1.Model
{
    public class Library : ILibrary
    {
        private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();

        #region ListAllBooks
        public void ListAllBooks()
        {
            try
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No books found in the library.");
                    return;
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|    ISBN             |   Title            |               Author             |   Published Date        |");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                foreach (var book in books.Values)
                {
                    Console.WriteLine($"| {book.ISBN,-13} | {book.Title,-20} | {book.Author,-30} | {book.PublishedDate.ToShortDateString(),-22} |");
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion

        #region AddBook
        public void AddBook(string title, string author, DateTime publishedDate)
        {
            try
            {
                string isbn = GenerateISBN();

                // Validate inputs
                if (string.IsNullOrWhiteSpace(title) || Regex.IsMatch(title, @"\d"))
                {
                    throw new ArgumentException("Invalid input for book title. It should not be empty or contain numbers.");
                }

                if (string.IsNullOrWhiteSpace(author) || Regex.IsMatch(author, @"\d"))
                {
                    throw new ArgumentException("Invalid input for book author. It should not be empty or contain numbers.");
                }
                // Validate published date
                if (publishedDate > DateTime.Now)
                {
                    throw new ArgumentException("Published date cannot be in the future.");
                }

                // Create and add book to dictionary
                var book = new Book(isbn, title, author, publishedDate);
                books[book.ISBN] = book;
                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }

        private string GenerateISBN()
        {
            var random = new Random();
            string isbn;
            do
            {
                isbn = random.Next(100000, 1000000000).ToString(); // Generate a 13-digit ISBN
            } while (books.ContainsKey(isbn));
            return isbn;
        }
        #endregion

        #region EditBook
        public void EditBook(string isbn)
        {
            try
            {
                if (!books.ContainsKey(isbn))
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                var book = books[isbn];

                Console.Write("Enter new title: ");
                string newTitle = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newTitle) || Regex.IsMatch(newTitle, @"\d"))
                {
                    Console.WriteLine("Invalid input for book title. It should not be empty or contain numbers.");
                    return;
                }
                book.Title = newTitle;

                Console.Write("Enter new author: ");
                string newAuthor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newAuthor) || Regex.IsMatch(newAuthor, @"\d"))
                {
                    Console.WriteLine("Invalid input for book author. It should not be empty or contain numbers.");
                    return;
                }
                book.Author = newAuthor;

                Console.Write("Enter new published date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newPublishedDate) && newPublishedDate <= DateTime.Now)
                {
                    book.PublishedDate = newPublishedDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format or date is in the future.");
                    return;
                }

                Console.WriteLine("Book details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion

        #region RemoveBook
        public void RemoveBook(string isbn)
        {
            try
            {
                if (!books.ContainsKey(isbn))
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                var book = books[isbn];
                Console.Write($"Are you sure you want to delete the book {isbn} ({book.Title})? (y/n): ");
                char confirmation = Console.ReadLine().Trim().ToLower()[0];

                if (confirmation == 'y')
                {
                    books.Remove(isbn);
                    Console.WriteLine("Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion

        #region SearchByAuthor
        public void SearchByAuthor(string author)
        {
            try
            {
                bool found = false;

                foreach (var book in books.Values)
                {
                    if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!found)
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("|   Title             |   Author          |");
                            Console.WriteLine("-------------------------------------------");
                            found = true;
                        }
                        Console.WriteLine($"| {book.Title,-20} | {book.Author,-20} |");
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No books found by this author.");
                }

                Console.WriteLine("----------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion

        #region SearchByTitle
        public void SearchByTitle(string title)
        {
            try
            {
                bool found = false;

                foreach (var book in books.Values)
                {
                    if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!found)
                        {
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("|   ISBN             |   Title           |   Author       | Published Date |");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            found = true;
                        }
                        Console.WriteLine($"| {book.ISBN,-13} | {book.Title,-15} | {book.Author,-15} | {book.PublishedDate.ToShortDateString(),-15} |");
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No books found with this title.");
                }

                Console.WriteLine("------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        #endregion
    }
}

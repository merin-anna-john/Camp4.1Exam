using System;
using CLMS_Exam_Camp4._1.Model;

namespace CLMS_Exam_Camp4._1
{
    public class CLMSvs2024
    {
        static void Main(string[] args)
        {
            ILibrary library = new Library();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Search By Author");
                Console.WriteLine("6. Search By Title");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid Choice. Please try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        library.ListAllBooks();
                        break;
                    case 2:
                        AddBook(library);
                        break;
                    case 3:
                        EditBook(library);
                        break;
                    case 4:
                        RemoveBook(library);
                        break;
                    case 5:
                        SearchByAuthor(library);
                        break;
                    case 6:
                        SearchByTitle(library);
                        break;
                    case 7:
                        return;
                }
            }
        }

        public static void AddBook(ILibrary library)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Published Date (yyyy-MM-dd): ");

            if (!DateTime.TryParse(Console.ReadLine(), out DateTime publishedDate))
            {
                Console.WriteLine("Invalid date format.");
                Console.ReadKey();
                return;
            }

            library.AddBook(title, author, publishedDate);
        }

        public static void EditBook(ILibrary library)
        {
            Console.Write("Enter ISBN of the book to edit: ");
            string isbn = Console.ReadLine();
            library.EditBook(isbn);
        }

        public static void RemoveBook(ILibrary library)
        {
            Console.Write("Enter ISBN of the book to remove: ");
            string isbn = Console.ReadLine();
            library.RemoveBook(isbn);
        }

        public static void SearchByAuthor(ILibrary library)
        {
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            library.SearchByAuthor(author);
        }

        public static void SearchByTitle(ILibrary library)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            library.SearchByTitle(title);
        }
    }
}

using System;

namespace CLMS_Exam_Camp4._1.Model
{
    // Book class for the details of the book
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }

        public Book() { }

        public Book(string isbn, string title, string author, DateTime publishedDate)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            PublishedDate = publishedDate;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Published Date: {PublishedDate.ToShortDateString()}";
        }
    }
}

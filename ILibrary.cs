namespace CLMS_Exam_Camp4._1.Model
{
    // Interface for managing library operations.
    public interface ILibrary
    {
        void ListAllBooks();
        void AddBook(string title, string author, DateTime publishedDate);
        void EditBook(string isbn);
        void RemoveBook(string isbn);
        void SearchByAuthor(string author);
        void SearchByTitle(string title);
    }
}

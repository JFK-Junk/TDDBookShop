
namespace TDDBookShop;

public class BookCollection
{
    private List<Book> _books = new();
    public void Add(Book book)
    {
        #region Guard clauses
        if (book.Price < 0) { throw new ArgumentException("Price must be non-negative!"); }
        if (String.IsNullOrEmpty(book.Title)) { throw new ArgumentException("Title must be a non-null or empty string"); } 
        #endregion

        _books.Add(book);
    }
}
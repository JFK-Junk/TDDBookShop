namespace TDDBooktests.ClassLibrary.Model;

public class BookCollection
{
    private List<Book> _books = new();
    public void Add(Book book)
    {
        #region Guard clauses
        if (book.Price < 0) { throw new ArgumentException("Price must be non-negative!"); }
        if (string.IsNullOrEmpty(book.Title)) { throw new ArgumentException("Title must be a non-null or empty string"); } 
        #endregion

        _books.Add(book);
    }

    public  void Delete(string isbnNo)
    {
        var book = Get(isbnNo);
        if (book != null)
        {
            book.IsDeleted = true;
        }
    }

    public  Book Get(string isbnNo)
    {
        return _books.Where(b => b.Isbn == isbnNo
        ).FirstOrDefault();
    }
}
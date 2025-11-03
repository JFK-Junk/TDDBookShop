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

    public  bool Delete(string isbnNo)
    {
        var book = Get(isbnNo);
        if (book != null)
        {
            book.IsDeleted = true;
            return true;
        }
        return false;
    }

    public  Book Get(string isbnNo)
    {
        return _books.Where(b => b.Isbn == isbnNo
        ).FirstOrDefault();
    }

    public IEnumerable<Book> FindBooks(SearchParameters parameters)
    {
        IEnumerable<Book> booksFound = _books;
        if (!String.IsNullOrEmpty(parameters.PartOfTitle))
        {
            booksFound = booksFound.Where(book => book.Title.Contains(parameters.PartOfTitle, StringComparison.InvariantCultureIgnoreCase));
        }

        if (!String.IsNullOrEmpty(parameters.PartOfAuthor))
        {
            booksFound = booksFound.Where(book => book.Author.Contains(parameters.PartOfAuthor, StringComparison.InvariantCultureIgnoreCase));
        }
        return booksFound;

    }
    public IEnumerable<Book> FindBooksByPartOfTitleOrAuthorName(string partOfTitleOrAuthorName)
    {
        return  _books.Where(book => book.Title.Contains(partOfTitleOrAuthorName, StringComparison.InvariantCultureIgnoreCase)
        
        &&

        book.Author.Contains(partOfTitleOrAuthorName, StringComparison.InvariantCultureIgnoreCase)

        );
    }

}
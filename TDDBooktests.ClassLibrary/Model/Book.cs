namespace TDDBooktests.ClassLibrary.Model;

public class Book
{
    #region Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }
    public bool IsDeleted { get; set; }
    #endregion

    public Book(string isbn, string title, string author, decimal price, int year)
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        Price = price;
        Year = year;
        
    }


    public override string ToString()
    {
        return $"[Book] ({Isbn}) '{Title}' by '{Author}', costs {Price}";
    }

}
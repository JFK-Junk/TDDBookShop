namespace TDDBookShop;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public decimal Price { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"[Book] ({Isbn}) '{Title}' by '{Author}', costs {Price}";
    }

}
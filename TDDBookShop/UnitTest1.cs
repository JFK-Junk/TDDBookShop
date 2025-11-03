using TDDBooktests.ClassLibrary.Model;

namespace TDDBookShop;

public class Tests
{
    //List<Book> books;
    [SetUp]
   public void BeforeEachTest() {

        //books.Add();
        //books.Add();
    }



    [Test]
    public void WhenAddingABookInAnInvalidStateToTheCollection_TheBookIsRejected()
    {
        //arrange
        Book book = new("098709812345", "C# for beginners", "Code Jockey Nielsen", -249.95m, 2023);
        BookCollection collection = new();
        
        //act and Assert
        Assert.Throws<ArgumentException>(() => collection.Add(book));
    }

    [Test]
    public void WhenDeletingABookRepeatedly_NoExceptionIsThrown() { }

    [Test]
    public void WhenGettingABook_ByIsbn_ItIsReturned()
    {
        //Arrange
        string isbnNo = "098709812345";
        Book book = new(isbnNo, "C# for beginners", "Code Jockey Nielsen", 249.95m, 2023);
        BookCollection collection = new();
        collection.Add(book);

        //Act
        Book refoundBook = collection.Get(isbnNo);

        //Assert
        Assert.That(refoundBook.Isbn, Is.EqualTo(isbnNo));
    }

    [Test]
    public void WhenDeletingABook_ItIsMarkedDeletedNotRemoved() {
        //Arrange
        string isbnNo = "098709812345";
        Book book = new(isbnNo, "C# for beginners", "Code Jockey Nielsen", 249.95m, 2023);
        BookCollection collection = new();
        collection.Add(book);
        Book refoundBook = collection.Get(isbnNo);

        //Act
        collection.Delete(isbnNo);

        //Assert
        Assert.That(refoundBook.IsDeleted, Is.EqualTo(true));
    }

    [Test]
    public void WhenFindingBooks_WithPartOfTitle_ReturnsTwoMatches()
    {
        // Arrange - five books
        Book b1 = new("1111111111111", "C# for beginners", "Author A", 10.00m, 2020);
        Book b2 = new("2222222222222", "Advanced C#", "Author B", 15.00m, 2021);
        Book b3 = new("3333333333333", "Java for beginners", "Author C", 12.00m, 2019);
        Book b4 = new("4444444444444", "Learning Python", "Author D", 20.00m, 2018);
        Book b5 = new("5555555555555", "Rust in Action", "Author E", 25.00m, 2022);

        BookCollection collection = new();
        collection.Add(b1);
        collection.Add(b2);
        collection.Add(b3);
        collection.Add(b4);
        collection.Add(b5);

        // Search for titles containing "beginners" (should match b1 and b3)
        SearchParameters parameters = new() { PartOfTitle = "beginners" };

        // Act
        var found = collection.FindBooks(parameters);

        // Assert - count two and contains expected ISBNs
        int count = 0;
        List<string> foundIsbns = new();
        foreach (var bk in found)
        {
            count++;
            foundIsbns.Add(bk.Isbn);
        }

        Assert.That(count, Is.EqualTo(2));
        Assert.That(foundIsbns, Does.Contain("1111111111111"));
        Assert.That(foundIsbns, Does.Contain("3333333333333"));
    }

    [Test]
    public void WhenFindingBooks_WithTitleAndAuthor_BothFiltersAreApplied()
    {
        // Arrange - five books (same as other test)
        Book b1 = new("1111111111111", "C# for beginners", "Author A", 10.00m, 2020);
        Book b2 = new("2222222222222", "Advanced C#", "Author B", 15.00m, 2021);
        Book b3 = new("3333333333333", "Java for beginners", "Author C", 12.00m, 2019);
        Book b4 = new("4444444444444", "Learning Python", "Author D", 20.00m, 2018);
        Book b5 = new("5555555555555", "Rust in Action", "Author E", 25.00m, 2022);

        BookCollection collection = new();
        collection.Add(b1);
        collection.Add(b2);
        collection.Add(b3);
        collection.Add(b4);
        collection.Add(b5);

        // Search for titles containing "C#" and author containing "Author B"
        // Both filters are applied (logical AND), so only b2 should match.
        SearchParameters parameters = new() { PartOfTitle = "C#", PartOfAuthor = "Author B" };

        // Act
        var found = collection.FindBooks(parameters);

        // Assert - only b2 is returned
        var foundList = found.ToList();
        Assert.That(foundList.Count, Is.EqualTo(1));
        Assert.That(foundList[0].Isbn, Is.EqualTo("2222222222222"));
    }

}
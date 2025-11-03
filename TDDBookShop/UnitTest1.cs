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

}
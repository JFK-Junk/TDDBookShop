namespace TDDBookShop;

public class Tests
{
   

    [Test]
    public void WhenAddingABookInAnInvalidStateToTheCollection_TheBookIsRejected()
    {
        //arrange
        Book book = new("098709812345", "C# for beginners", "Code Jockey Nielsen", -249.95m, 2023);
        BookCollection collection = new();
        
        //act and Assert
        Assert.Throws<ArgumentException>(
        () => collection.Add(book));
    }
}
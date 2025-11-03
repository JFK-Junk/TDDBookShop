namespace TDDBookShop;

public class Tests
{
   

    [Test]
    public void WhenAddingABookInAnInvalidStateToTheCollection_TheBookIsRejected()
    {
        //arrange
        Book book = new("C# for beginners", "Code Jockey Nielsen", 2023, "098709812345", 249.95);
        BookCollection collection = new();
        
        //act and Assert
        Assert.Throws<ArgumentException>(
        collection.Add(book));
    }
}
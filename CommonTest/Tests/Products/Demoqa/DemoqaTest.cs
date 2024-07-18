
namespace Demoqa;

[TestClass]
public class DemoqaTest : DemoqInitialize
{
    [TestMethod]
    public async Task TestMethod()
    {
        var listOfBooks = await CommonApi.BookClient.GetBooksAsync();
    }
}
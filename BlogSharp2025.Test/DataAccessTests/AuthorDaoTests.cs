using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.SqlServer;

namespace BlogSharp2025.Test.DataAccessTests;

public class Tests
{

    private const string connectionString = "Data Source=.;Integrated Security=True;initial catalog=BlogSharp2025";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AuthorDao_GetAll()
    {

        //arrange
        //insert data...
        IAuthorDao authorDao = new AuthorDao(connectionString);
        
        //act

        var authors = authorDao.GetAll();

        //assert

        Assert.That(3, Is.EqualTo(authors.Count()));

    }
}
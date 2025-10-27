using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using Dapper;

namespace BlogSharp2025.DataAccessLibrary.SqlServer;
public class AuthorDao : BaseDao, IAuthorDao
{
    //constructor which passes
    //the connectionstring to BaseDao
    public AuthorDao(string connectionString) : base(connectionString){}


    public int Create(Author author)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetAll()
    {
        var query = "SELECT * FROM Author";
        using var connection = CreateConnection();
        return connection.Query<Author>(query).ToList();
    }

    public Author? GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(Author author)
    {
        throw new NotImplementedException();
    }
}

using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using BlogSharp2025.DataAccessLibrary.Tools;
using Dapper;
using static Dapper.SqlMapper;
using System.Linq;

namespace BlogSharp2025.DataAccessLibrary.SqlServer;
public class AuthorDao : BaseDao, IAuthorDao
{
    //constructor which passes
    //the connectionstring to BaseDao
    public AuthorDao(string connectionString) : base(connectionString){}


    public int Create(Author author)
    {
        var query = "INSERT INTO Author (Email, BlogTitle, PasswordHash) OUTPUT INSERTED.Id VALUES (@Email, @BlogTitle, @PasswordHash);";
        var passwordHash = BCryptTool.HashPassword(author.PasswordHash);
        using var connection = CreateConnection();
        return connection.QuerySingle<int>(query, new { Email = author.Email, BlogTitle = author.BlogTitle, PasswordHash = passwordHash });
    }

    public bool Delete(int id)
    {
        var query = "DELETE FROM Author WHERE Id = @Id;";
        using var connection = CreateConnection();
        var rows = connection.Execute(query, new { Id = id });
        return rows > 0;
    }

    public IEnumerable<Author> GetAll()
    {
        var query = "SELECT * FROM Author";
        using var connection = CreateConnection();
        return connection.Query<Author>(query).ToList();
    }

    public Author? GetOne(int id)
    {
        var query = "SELECT * FROM Author WHERE Id = @Id";
        using var connection = CreateConnection();
        return connection.QuerySingleOrDefault<Author>(query, new { Id = id });
    }

    public bool Update(Author author)
    {
        // Determine password hash to store:
        // - if caller provided a non-empty value, hash it unless it looks already like a bcrypt hash
        // - if caller did not provide a password, keep existing hash
        string passwordHash;
        if (string.IsNullOrWhiteSpace(author.PasswordHash))
        {
            var existing = GetOne(author.Id);
            if (existing == null) return false;
            passwordHash = existing.PasswordHash;
        }
        else
        {
            // bcrypt hashes start with $2a$/$2b$/$2y$ etc.
            passwordHash = author.PasswordHash.StartsWith("$2") ? author.PasswordHash : BCryptTool.HashPassword(author.PasswordHash);
        }

        var query = @"UPDATE Author 
                      SET Email = @Email, BlogTitle = @BlogTitle, PasswordHash = @PasswordHash
                      WHERE Id = @Id;";
        using var connection = CreateConnection();
        var rows = connection.Execute(query, new { Email = author.Email, BlogTitle = author.BlogTitle, PasswordHash = passwordHash, Id = author.Id });
        return rows > 0;
    }
}

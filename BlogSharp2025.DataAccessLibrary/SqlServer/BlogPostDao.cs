using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using Dapper;
using System.Linq;

namespace BlogSharp2025.DataAccessLibrary.SqlServer;
public class BlogPostDao : BaseDao, IBlogPostDao
{
    public BlogPostDao(string connectionString) : base(connectionString) { }

    public int Create(BlogPost blogPost)
    {
        var query = @"INSERT INTO BlogPost (Title, TextBody, CreationDate, FK_Author_Id)
                      OUTPUT INSERTED.Id
                      VALUES (@Title, @TextBody, @CreationDate, @FK_Author_Id);";
        using var connection = CreateConnection();
        return connection.QuerySingle<int>(query, new { blogPost.Title, blogPost.TextBody, blogPost.CreationDate, blogPost.FK_Author_Id });
    }

    public bool Delete(int id)
    {
        var query = "DELETE FROM BlogPost WHERE Id = @Id;";
        using var connection = CreateConnection();
        var rows = connection.Execute(query, new { Id = id });
        return rows > 0;
    }

    public IEnumerable<BlogPost> GetAll()
    {
        var query = "SELECT * FROM BlogPost";
        using var connection = CreateConnection();
        return connection.Query<BlogPost>(query).ToList();
    }

    public IEnumerable<BlogPost> GetByAuthor(int authorId)
    {
        var query = "SELECT * FROM BlogPost WHERE FK_Author_Id = @AuthorId";
        using var connection = CreateConnection();
        return connection.Query<BlogPost>(query, new { AuthorId = authorId }).ToList();
    }

    public BlogPost? GetOne(int id)
    {
        var query = "SELECT * FROM BlogPost WHERE Id = @Id";
        using var connection = CreateConnection();
        return connection.QuerySingleOrDefault<BlogPost>(query, new { Id = id });
    }

    public bool Update(BlogPost blogPost)
    {
        var query = @"UPDATE BlogPost
                      SET Title = @Title,
                          TextBody = @TextBody,
                          CreationDate = @CreationDate,
                          FK_Author_Id = @FK_Author_Id
                      WHERE Id = @Id;";
        using var connection = CreateConnection();
        var rows = connection.Execute(query, new
        {
            Title = blogPost.Title,
            TextBody = blogPost.TextBody,
            CreationDate = blogPost.CreationDate,
            FK_Author_Id = blogPost.FK_Author_Id,
            Id = blogPost.Id
        });
        return rows > 0;
    }
}
using BlogSharp2025.DataAccessLibrary.Model;

namespace BlogSharp2025.DataAccessLibrary.Interfaces;
public interface IBlogPostDao
{
    BlogPost? GetOne(int id);
    IEnumerable<BlogPost> GetAll();
    IEnumerable<BlogPost> GetByAuthor(int authorId);
    bool Delete(int id);
    bool Update(BlogPost blogPost);
    int Create(BlogPost blogPost);
}
using BlogSharp2025.DataAccessLibrary.Model;

namespace BlogSharp2025.DataAccessLibrary.Interfaces;
public interface IBlogPostDao
{
    BlogPost? GetOne(int id);
    IEnumerable<BlogPost> GetAll();
    bool Delete(int id);
    bool Update(BlogPost blogPost);
    int Create(BlogPost blogPost);
}
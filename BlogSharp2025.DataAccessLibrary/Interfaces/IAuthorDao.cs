using BlogSharp2025.DataAccessLibrary.Model;

namespace BlogSharp2025.DataAccessLibrary.Interfaces;

public interface IAuthorDao
{
    Author? GetOne(int id);
    IEnumerable<Author> GetAll();
    bool Delete(int id);
    bool Update(Author author);
    int Create(Author author);
}
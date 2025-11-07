using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSharp2025.DataAccessLibrary.Stub;
public class InMemoryAuthorDaoStub : IAuthorDao
{

    private static List<Author> _authors = new();

    public int Create(Author author)
    {
        var newId = 1;
        if (_authors.Any())
        {
           newId = _authors.Max(author => author.Id) + 1;

        } author.Id = newId;
        _authors.Add(author);
        return newId;
    }

    public bool Delete(int id)
    {
        var foundAuthor = _authors.Where(author => author.Id == id).FirstOrDefault();
        _authors.Remove(foundAuthor);
        return foundAuthor != null;
    }

    public IEnumerable<Author> GetAll() => _authors;

    public Author? GetOne(int id)
    {
       return  _authors.Where(author => author.Id == id).SingleOrDefault();
    }

    public bool Update(Author author)
    {
        var foundAuthor = GetOne(author.Id);
        if(foundAuthor != null)
        {
            foundAuthor.Email = author.Email;
            foundAuthor.BlogTitle = author.BlogTitle;
            foundAuthor.PasswordHash = author.PasswordHash;
        }
        return foundAuthor != null;
    }
}

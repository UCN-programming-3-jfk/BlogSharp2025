using System;
using System.Linq;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using BlogSharp2025.DataAccessLibrary.SqlServer;
using NUnit.Framework;

namespace BlogSharp2025.Test.DataAccessTests;
[TestFixture]
public class BlogPostDaoTests
{
    private const string connectionString = "Data Source=.;Integrated Security=True;initial catalog=BlogSharp2025; trust server certificate=true";

    private IAuthorDao CreateAuthorDao() => new AuthorDao(connectionString);
    private IBlogPostDao CreateBlogPostDao() => new BlogPostDao(connectionString);

    private static Author NewAuthor(string emailSuffix, string password = "Password1234")
    {
        var email = $"test.{emailSuffix}@example.com";
        var blogTitle = $"Blog {emailSuffix}";
        return new Author(0, email, password, blogTitle);
    }

    private static BlogPost NewBlogPost(string suffix, int authorId)
    {
        return new BlogPost($"Title {suffix}", $"Body for {suffix}", DateTime.UtcNow, authorId);
    }

    [Test]
    public void Create_ReturnsNewId_And_GetOne_ReturnsBlogPost()
    {
        var authorDao = CreateAuthorDao();
        var blogDao = CreateBlogPostDao();

        var suffix = Guid.NewGuid().ToString("N");
        var author = NewAuthor(suffix);
        var authorId = authorDao.Create(author);
        Assert.That(authorId, Is.GreaterThan(0));

        int createdId = 0;
        try
        {
            var blog = NewBlogPost(suffix, authorId);
            createdId = blogDao.Create(blog);
            Assert.That(createdId, Is.GreaterThan(0));

            var fetched = blogDao.GetOne(createdId);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched!.Title, Is.EqualTo(blog.Title));
            Assert.That(fetched.TextBody, Is.EqualTo(blog.TextBody));
            Assert.That(fetched.FK_Author_Id, Is.EqualTo(authorId));
        }
        finally
        {
            if (createdId > 0) blogDao.Delete(createdId);
            if (authorId > 0) authorDao.Delete(authorId);
        }
    }

    [Test]
    public void GetAll_IncludesNewlyCreatedBlogPost()
    {
        var authorDao = CreateAuthorDao();
        var blogDao = CreateBlogPostDao();

        var suffix = Guid.NewGuid().ToString("N");
        var authorId = authorDao.Create(NewAuthor(suffix));
        Assert.That(authorId, Is.GreaterThan(0));

        int createdId = 0;
        try
        {
            createdId = blogDao.Create(NewBlogPost(suffix, authorId));
            var all = blogDao.GetAll();
            Assert.That(all.Any(b => b.Id == createdId && b.FK_Author_Id == authorId), Is.True);
        }
        finally
        {
            if (createdId > 0) blogDao.Delete(createdId);
            if (authorId > 0) authorDao.Delete(authorId);
        }
    }

    [Test]
    public void GetByAuthor_ReturnsOnlyThatAuthorsBlogPosts()
    {
        var authorDao = CreateAuthorDao();
        var blogDao = CreateBlogPostDao();

        var suffix = Guid.NewGuid().ToString("N");
        var authorId1 = authorDao.Create(NewAuthor(suffix));
        var authorId2 = authorDao.Create(NewAuthor(suffix + "b"));
        Assert.That(authorId1, Is.GreaterThan(0));
        Assert.That(authorId2, Is.GreaterThan(0));

        int id1 = 0;
        int id2 = 0;
        try
        {
            id1 = blogDao.Create(NewBlogPost(suffix + "1", authorId1));
            id2 = blogDao.Create(NewBlogPost(suffix + "2", authorId2));
            Assert.That(id1, Is.GreaterThan(0));
            Assert.That(id2, Is.GreaterThan(0));

            var postsForAuthor1 = blogDao.GetByAuthor(authorId1).ToList();
            Assert.That(postsForAuthor1.Any(p => p.Id == id1), Is.True, "Expected created post for author1 to be returned");
            Assert.That(postsForAuthor1.All(p => p.FK_Author_Id == authorId1), Is.True, "Expected all returned posts to belong to author1");
            Assert.That(postsForAuthor1.Any(p => p.Id == id2), Is.False, "Expected posts from other authors not to be returned");
        }
        finally
        {
            if (id1 > 0) blogDao.Delete(id1);
            if (id2 > 0) blogDao.Delete(id2);
            if (authorId1 > 0) authorDao.Delete(authorId1);
            if (authorId2 > 0) authorDao.Delete(authorId2);
        }
    }

    [Test]
    public void Update_UpdatesTitleTextAndAuthor()
    {
        var authorDao = CreateAuthorDao();
        var blogDao = CreateBlogPostDao();

        var suffix = Guid.NewGuid().ToString("N");
        var authorId1 = authorDao.Create(NewAuthor(suffix));
        var authorId2 = authorDao.Create(NewAuthor(suffix + "b"));
        Assert.That(authorId1, Is.GreaterThan(0));
        Assert.That(authorId2, Is.GreaterThan(0));

        int id = 0;
        try
        {
            id = blogDao.Create(NewBlogPost(suffix, authorId1));
            Assert.That(id, Is.GreaterThan(0));

            var fetched = blogDao.GetOne(id);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched!.FK_Author_Id, Is.EqualTo(authorId1));

            var updated = new BlogPost(id, "Updated Title", "Updated body text", DateTime.UtcNow.AddDays(1), authorId2);
            var result = blogDao.Update(updated);
            Assert.That(result, Is.True);

            var fetchedAfter = blogDao.GetOne(id);
            Assert.That(fetchedAfter, Is.Not.Null);
            Assert.That(fetchedAfter!.Title, Is.EqualTo("Updated Title"));
            Assert.That(fetchedAfter.TextBody, Is.EqualTo("Updated body text"));
            Assert.That(fetchedAfter.FK_Author_Id, Is.EqualTo(authorId2));
        }
        finally
        {
            if (id > 0) blogDao.Delete(id);
            if (authorId1 > 0) authorDao.Delete(authorId1);
            if (authorId2 > 0) authorDao.Delete(authorId2);
        }
    }

    [Test]
    public void Delete_RemovesBlogPost()
    {
        var authorDao = CreateAuthorDao();
        var blogDao = CreateBlogPostDao();

        var suffix = Guid.NewGuid().ToString("N");
        var authorId = authorDao.Create(NewAuthor(suffix));
        Assert.That(authorId, Is.GreaterThan(0));

        var id = blogDao.Create(NewBlogPost(suffix, authorId));
        Assert.That(id, Is.GreaterThan(0));

        var existsBefore = blogDao.GetOne(id);
        Assert.That(existsBefore, Is.Not.Null);

        var deleted = blogDao.Delete(id);
        Assert.That(deleted, Is.True);

        var existsAfter = blogDao.GetOne(id);
        Assert.That(existsAfter, Is.Null);

        // cleanup author
        if (authorId > 0) authorDao.Delete(authorId);
    }
}
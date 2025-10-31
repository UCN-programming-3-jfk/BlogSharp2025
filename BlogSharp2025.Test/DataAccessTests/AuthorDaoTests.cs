using System;
using System.Linq;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using BlogSharp2025.DataAccessLibrary.SqlServer;
using BlogSharp2025.DataAccessLibrary.Tools;
using NUnit.Framework;

namespace BlogSharp2025.Test.DataAccessTests;
public class AuthorDaoTests
{
    private const string connectionString = "Data Source=.;Integrated Security=True;initial catalog=BlogSharp2025; trust server certificate=true";

    private IAuthorDao CreateDao() => new AuthorDao(connectionString);

    private static Author NewAuthor(string emailSuffix, string password = "Password1234")
    {
        var email = $"test.{emailSuffix}@example.com";
        var blogTitle = $"Blog {emailSuffix}";
        // constructor signature: (int id, string email, string passwordHash, string blogTitle)
        return new Author(0, email, password, blogTitle);
    }

    [Test]
    public void Create_ReturnsNewId_And_GetOne_ReturnsAuthor()
    {
        var dao = CreateDao();
        var suffix = Guid.NewGuid().ToString("N");
        var author = NewAuthor(suffix, "CreatePass!23");

        int createdId = 0;
        try
        {
            createdId = dao.Create(author);
            Assert.That(createdId, Is.GreaterThan(0));

            var fetched = dao.GetOne(createdId);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched!.Email, Is.EqualTo(author.Email));
            Assert.That(fetched.BlogTitle, Is.EqualTo(author.BlogTitle));
            // Password saved as hash; validate using BCryptTool
            Assert.That(BCryptTool.ValidatePassword("CreatePass!23", fetched.PasswordHash), Is.True);
        }
        finally
        {
            if (createdId > 0) dao.Delete(createdId);
        }
    }

    [Test]
    public void GetAll_IncludesNewlyCreatedAuthor()
    {
        var dao = CreateDao();
        var suffix = Guid.NewGuid().ToString("N");
        var author = NewAuthor(suffix);

        int createdId = 0;
        try
        {
            createdId = dao.Create(author);
            var all = dao.GetAll();
            Assert.That(all, Is.Not.Null);
            Assert.That(all.Any(a => a.Id == createdId && a.Email == author.Email), Is.True);
        }
        finally
        {
            if (createdId > 0) dao.Delete(createdId);
        }
    }

    [Test]
    public void Update_UpdatesEmailBlogTitleAndPassword()
    {
        var dao = CreateDao();
        var suffix = Guid.NewGuid().ToString("N");
        var originalPassword = "OrigPass!1";
        var author = NewAuthor(suffix, originalPassword);

        int id = 0;
        try
        {
            id = dao.Create(author);
            Assert.That(id, Is.GreaterThan(0));

            var fetched = dao.GetOne(id);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(BCryptTool.ValidatePassword(originalPassword, fetched!.PasswordHash), Is.True);

            // Prepare update with new plain password
            var newEmail = $"updated.{suffix}@example.com";
            var newBlogTitle = $"Updated Blog {suffix}";
            var newPassword = "NewPass!456";
            var updatedAuthor = new Author(id, newEmail, newPassword, newBlogTitle);

            var updated = dao.Update(updatedAuthor);
            Assert.That(updated, Is.True);

            var fetchedAfter = dao.GetOne(id);
            Assert.That(fetchedAfter, Is.Not.Null);
            Assert.That(fetchedAfter!.Email, Is.EqualTo(newEmail));
            Assert.That(fetchedAfter.BlogTitle, Is.EqualTo(newBlogTitle));
            Assert.That(BCryptTool.ValidatePassword(newPassword, fetchedAfter.PasswordHash), Is.True);

            // Now update without providing a password => should preserve current password
            var emailOnly = $"emailonly.{suffix}@example.com";
            var updateNoPassword = new Author(id, emailOnly, string.Empty, "EmailOnly Blog");
            var updatedNoPass = dao.Update(updateNoPassword);
            Assert.That(updatedNoPass, Is.True);

            var fetchedPreserve = dao.GetOne(id);
            Assert.That(fetchedPreserve, Is.Not.Null);
            Assert.That(fetchedPreserve!.Email, Is.EqualTo(emailOnly));
            // password should still validate with newPassword
            Assert.That(BCryptTool.ValidatePassword(newPassword, fetchedPreserve.PasswordHash), Is.True);
        }
        finally
        {
            if (id > 0) dao.Delete(id);
        }
    }

    [Test]
    public void Delete_RemovesAuthor()
    {
        var dao = CreateDao();
        var suffix = Guid.NewGuid().ToString("N");
        var author = NewAuthor(suffix);

        var id = dao.Create(author);
        Assert.That(id, Is.GreaterThan(0));

        var existsBefore = dao.GetOne(id);
        Assert.That(existsBefore, Is.Not.Null);

        var deleted = dao.Delete(id);
        Assert.That(deleted, Is.True);

        var existsAfter = dao.GetOne(id);
        Assert.That(existsAfter, Is.Null);
    }
}
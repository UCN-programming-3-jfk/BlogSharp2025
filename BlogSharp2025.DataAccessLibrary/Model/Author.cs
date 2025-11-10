using Microsoft.Data.SqlClient.Diagnostics;

namespace BlogSharp2025.DataAccessLibrary.Model;
public class Author
{
    #region Properties
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string BlogTitle { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Necessary (default) constructor for deserialization
    /// </summary>
    public Author(){}
    public Author(int id, string email, string passwordHash, string blogTitle)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        BlogTitle = blogTitle;
    }

    public Author(string email, string blogTitle)
    {
        Email = email;
        BlogTitle = blogTitle;
    }
    #endregion
}
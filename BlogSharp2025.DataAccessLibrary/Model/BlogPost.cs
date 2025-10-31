using System;

namespace BlogSharp2025.DataAccessLibrary.Model;
public class BlogPost
{
    #region Properties
    public int Id { get; internal set; }
    public string Title { get; set; }
    public string TextBody { get; set; }
    public DateTime CreationDate { get; set; }

    // Matches DB column name so Dapper maps without additional configuration
    public int FK_Author_Id { get; set; }
    #endregion

    #region Constructors
    //System.Int32 Id, System.String Title, System.String TextBody, System.DateTime CreationDate, System.Int32 FK_Author_Id
    public BlogPost(int id, string title, string textBody, DateTime creationDate, int fK_Author_Id)
    {
        Id = id;
        Title = title;
        TextBody = textBody;
        CreationDate = creationDate;
        this.FK_Author_Id = fK_Author_Id;
    }

    public BlogPost(string title, string textBody, DateTime creationDate, int fkAuthorId)
    {
        Title = title;
        TextBody = textBody;
        CreationDate = creationDate;
        FK_Author_Id = fkAuthorId;
    }
    #endregion
}
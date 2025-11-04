using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using RestSharp;

namespace BlogSharp2025.ApiClient;

public class ApiClient : IAuthorDao, IBlogPostDao
{
    #region attributes and constructor
    //The address of the API server
    private readonly string _apiUri;

    //the rest client from restsharp to call the server
    private readonly RestClient _restClient;

    public ApiClient(string apiUri)
    {
        _apiUri = apiUri;
        _restClient = new RestClient(apiUri);
    }
    #endregion

    public int Create(Author author)
    {
        var request = new RestRequest("authors", Method.Post);
        request.AddJsonBody(author);

        var response = _restClient.Execute<int>(request);
        if (response == null)
        {
            throw new Exception("NO response from server");
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Server reply: Unsuccessful request");
        }
        return response.Data;
    }

    public int Create(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve all authors from api
    /// </summary>
    /// <returns>All authors</returns>
    public IEnumerable<Author> GetAll()
    {
        //prepare the request with the remainder
        //of the URL (add the "authors")
        //and set the method (GET)
        var request = new RestRequest("authors", Method.Get);

        //in case you only want authorized clients to access
        //request.AddParameter("apikey", "12435+8uqrjpogijn");

        var response = _restClient.Execute<IEnumerable<Author>>(request);
        if (response == null) { 
            throw new Exception("NO response from server"); }
        if (response.IsSuccessStatusCode)
        {
            return response.Data;
        }
        else
        {
            throw new Exception("Server reply: Unsuccessful request");
        }
    }

    public Author? GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(Author author)
    {
        throw new NotImplementedException();
    }

    public bool Update(BlogPost blogPost)
    {
        throw new NotImplementedException();
    }

    IEnumerable<BlogPost> IBlogPostDao.GetAll()
    {
        throw new NotImplementedException();
    }

    BlogPost? IBlogPostDao.GetOne(int id)
    {
        throw new NotImplementedException();
    }
}

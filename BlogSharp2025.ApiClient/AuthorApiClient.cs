using System;
using System.Collections.Generic;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using RestSharp;

namespace BlogSharp2025.ApiClient;

public class AuthorApiClient : IAuthorDao
{
    #region attributes and constructor
    //The address of the API server
    private readonly string _apiUri;

    //the rest client from restsharp to call the server
    private readonly RestClient _restClient;

    public AuthorApiClient(string apiUri)
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
        if (response == null) throw new Exception("NO response from server");
        if (!response.IsSuccessStatusCode) throw new Exception("Server reply: Unsuccessful request");
        return response.Data;
    }

    public bool Delete(int id)
    {
        var request = new RestRequest($"authors/{id}", Method.Delete);

        var response = _restClient.Execute<bool>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public IEnumerable<Author> GetAll()
    {
        var request = new RestRequest("authors", Method.Get);
        var response = _restClient.Execute<IEnumerable<Author>>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public Author? GetOne(int id)
    {
        var request = new RestRequest($"authors/{id}", Method.Get);
        var response = _restClient.Execute<Author>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public bool Update(Author author)
    {
        if (author == null) throw new ArgumentNullException(nameof(author));
        var request = new RestRequest($"authors/{author.Id}", Method.Put);
        request.AddJsonBody(author);

        var response = _restClient.Execute<bool>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
        throw new Exception("Server reply: Unsuccessful request");
    }
}
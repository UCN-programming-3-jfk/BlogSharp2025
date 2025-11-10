using System;
using System.Collections.Generic;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using RestSharp;

namespace BlogSharp2025.ApiClient;

public class BlogPostApiClient : IBlogPostDao
{
    #region attributes and constructor
    //The address of the API server
    private readonly string _apiUri;

    //the rest client from restsharp to call the server
    private readonly RestClient _restClient;

    public BlogPostApiClient(string apiUri)
    {
        _apiUri = apiUri;
        _restClient = new RestClient(apiUri);
    }
    #endregion

    public int Create(BlogPost blogPost)
    {
        var request = new RestRequest("blogposts", Method.Post);
        request.AddJsonBody(blogPost);

        var response = _restClient.Execute<int>(request);
        if (response == null) throw new Exception("NO response from server");
        if (!response.IsSuccessStatusCode) throw new Exception("Server reply: Unsuccessful request");
        return response.Data;
    }

    public bool Delete(int id)
    {
        var request = new RestRequest($"blogposts/{id}", Method.Delete);

        var response = _restClient.Execute<bool>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public IEnumerable<BlogPost> GetAll()
    {
        var request = new RestRequest("blogposts", Method.Get);
        var response = _restClient.Execute<IEnumerable<BlogPost>>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public IEnumerable<BlogPost> GetByAuthor(int authorId)
    {
        var request = new RestRequest($"Authors/{authorId}/BlogPosts", Method.Get);
        var response = _restClient.Execute<IEnumerable<BlogPost>>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public BlogPost? GetOne(int id)
    {
        var request = new RestRequest($"blogposts/{id}", Method.Get);
        var response = _restClient.Execute<BlogPost>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
        throw new Exception("Server reply: Unsuccessful request");
    }

    public bool Update(BlogPost blogPost)
    {
        if (blogPost == null) throw new ArgumentNullException(nameof(blogPost));
        var request = new RestRequest($"blogposts/{blogPost.Id}", Method.Put);
        request.AddJsonBody(blogPost);

        var response = _restClient.Execute<bool>(request);
        if (response == null) throw new Exception("NO response from server");
        if (response.IsSuccessStatusCode) return response.Data;
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return false;
        throw new Exception("Server reply: Unsuccessful request");
    }
}
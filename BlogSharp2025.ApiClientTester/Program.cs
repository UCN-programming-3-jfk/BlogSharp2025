using BlogSharp2025.DataAccessLibrary.Model;
using client = BlogSharp2025.ApiClient;

namespace BlogSharp2025.ApiClientTester;

internal class Program
{
    static void Main(string[] args)
    {
        client.AuthorApiClient apiClient = new ("https://localhost:7249/");

        var authors = apiClient.GetAll();

        Author author = new Author(-1, "newest@author.net", "password1234", $"My bestest blog {DateTime.Now.ToLongTimeString()}");

        apiClient.Create(author);

    }
}
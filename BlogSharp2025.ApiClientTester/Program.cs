using client = BlogSharp2025.ApiClient;

namespace BlogSharp2025.ApiClientTester;

internal class Program
{
    static void Main(string[] args)
    {
        client.ApiClient apiClient = new ("https://localhost:7249/");

        var authors = apiClient.GetAll();

    }
}

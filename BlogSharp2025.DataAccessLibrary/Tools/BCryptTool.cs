using System;

using bcryptPackage = BCrypt.Net;
namespace BlogSharp2025.DataAccessLibrary.Tools;
public class BCryptTool
{
    public static string HashPassword(string password) =>
bcryptPackage.BCrypt.HashPassword(password, GetRandomSalt());
    public static bool ValidatePassword(string password, string correctHash) => bcryptPackage.BCrypt.Verify(password, correctHash);
    private static string GetRandomSalt() => bcryptPackage.BCrypt.GenerateSalt(12);
}


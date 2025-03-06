using AuthApi.Models;

namespace AuthApi.Services;

public class UserService
{
    private static List<User> users = new()
    {
        new User { Username = "testuser", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123") }
    };

    public User? Authenticate(string username, string password)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }
        return user;
    }
}

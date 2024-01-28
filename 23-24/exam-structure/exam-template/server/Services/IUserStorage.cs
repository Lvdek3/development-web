using System.Text.Json;
public interface IUserStorage

{
    Task AddUser(User user);
    Task DeleteUser(String user);
    Task<List<User>> GetUsers(int from, int to);
}

public class UserStorage : IUserStorage
{
    
    public async Task AddUser(User user)
    {
        await System.IO.File.WriteAllTextAsync($"Users/{user.Name}.json", JsonSerializer.Serialize(user));
    }


    public async Task DeleteUser(String userName)
    {
        var path = $"Users/{userName}.json";
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
    }

    public async Task<List<User>> GetUsers(int from, int to)
    {
        var users = new List<User>();
        var files = System.IO.Directory.GetFiles("Users");
        foreach (var file in files)
        {
            var user = JsonSerializer.Deserialize<User>(await System.IO.File.ReadAllTextAsync(file));
            users.Add(user);
        }
        
        var usersInRange = users.Skip(from).Take(to - from + 1).ToList();
        return usersInRange;
    }
}
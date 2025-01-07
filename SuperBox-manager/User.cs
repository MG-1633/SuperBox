namespace SuperBox_manager;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string uuid { get; set; }
    public string admin { get; set; }

    public User(string username, string password, string uuid, string admin)
    {
        Username = username;
        Password = password;
        this.uuid = uuid;
        this.admin = admin;
    }

    
}
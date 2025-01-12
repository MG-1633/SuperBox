namespace SuperBox_manager;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Uuid { get; set; }
    public string Admin { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public User(string username, string password, string uuid, string admin , string email, string phone)
    {
        Username = username;
        Password = password;
        Uuid = uuid;
        Admin = admin;
        Email = email;
        Phone = phone;
        
    }


}
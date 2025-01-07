namespace SuperBox_manager;

public class Comenzi
{
    public string From { get; set; }
    public string To { get; set; }

    public User UserX { get; set; }
    
    public bool IsUrgent { get; set; }
    
    

    public Comenzi(string from, string to , User getUser, bool isUrgent)
    {
        From = from;
        To = to;
        UserX = getUser;
        IsUrgent = isUrgent;
    }
}
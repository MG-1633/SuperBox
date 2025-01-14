namespace SuperBox_manager;

public class Comanda
{
    public string From { get; set; }
    public string To { get; set; }
    
    public string Reciver { get; set; }
    public string Sender { get; set; }
    public User UserX { get; set; }
    
    public bool IsUrgent { get; set; }
    public bool InPregress = true;
    public Random random = new Random();

    public string IdComanda;
    
    

    public Comanda(string from, string to , User getUser, bool isUrgent, string reciver,string sender)
    {
        From = from;
        To = to;
        UserX = getUser;
        IsUrgent = isUrgent;
        IdComanda = random.Next(100,1000).ToString();
        Reciver = reciver;
        
    }
    
    
    
    
    
    
    
}
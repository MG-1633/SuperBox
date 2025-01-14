namespace SuperBox_manager;

public class SuperBox
{
  
    public string Id { get; set; }
    public string Location { get; set; }


    public SuperBox(string id, string location)
    {
        Id = id;
        Location = location;
        
    }
}
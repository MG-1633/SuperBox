namespace SuperBox_manager;

public class SuperBox
{
  
    public int Id { get; set; }
    public string Location { get; set; }


    public SuperBox(int id, string location)
    {
        Id = id;
        Location = location;
        
    }
}
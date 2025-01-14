namespace SuperBox_manager;

public partial class AddSuperBox : ContentPage
{
    public User Uuser { get; set; }
    private readonly FileService _fileService;
    public AddSuperBox(User user)
    {

        InitializeComponent();
        _fileService = new FileService();

        Uuser = user;
    }

   
    Random random = new Random();
    private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
    {

        // string IdComanda = random.Next(100, 999).ToString();
        // string fileNameForId = "MyOrdersId2" + Uuser.Uuid + ".txt";
        string fileNameForSuperBox = "NewSuperBox.txt";

        try
        {
           // string from = fromField.Text;
            //string to = toField.Text;
           // SuperBox superbox = new SuperBox(random, location);

            // await _fileService.SaveMyDeliverysId(fileNameForId, comanda.IdComanda);
           // await _fileService.SaveSuperBox(fileNameForSuperBox, superbox);
           // await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }





    }
}
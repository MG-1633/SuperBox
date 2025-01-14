namespace SuperBox_manager;

public partial class AddSuperBox : ContentPage
{
    public SuperBox superbox { get; set; }
    private readonly FileService _fileService;
  

    public AddSuperBox()
    {

        InitializeComponent();
        _fileService = new FileService();

    }

    Random random = new Random();
    private string Id = "";
    private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
    {
        string fileNameForSuperBox = "AllSuperBoxes.txt";

        try
        {
           Id = random.Next(1000,9999).ToString();

            string locatie = Field.Text;

           SuperBox superbox = new SuperBox(Id,locatie);

            // await _fileService.SaveMyDeliverysId(fileNameForId, comanda.IdComanda);
            await _fileService.SaveSuperBox(fileNameForSuperBox, superbox);
            await DisplayAlert("Succes", $"Datele au fost salvate cu succes.", "OK");

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }





    }
}
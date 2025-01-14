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


    int index = 1;
    private async void ButtonPlace_OnClicked(object? sender, EventArgs e)
    {
        string fileNameForSuperBox = "AllSuperBoxes.txt";

        try
        {
            index = index + 1;

            string locatie = Field.Text;

           SuperBox superbox = new SuperBox(index,locatie);

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